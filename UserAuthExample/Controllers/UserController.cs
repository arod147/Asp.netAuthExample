using Microsoft.AspNetCore.Mvc;
using UserAuthExample.Data;
using UserAuthExample.Models;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;

namespace UserAuthExample.Controllers
{

    public class UserController : Controller
    {
        // Need to not show senstive data
        // Enter your redis details EX. $"localhost:6379,password=myPassword"
        static readonly ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect($"localhost:6379,password=myPassword"); //Here

        private readonly PasswordHasher<User> _passwordHasher = new() { };

        private readonly EmailManager _emailManager;

        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db, EmailManager emailManager)
        {
            _db = db;
            _emailManager = emailManager;
        }
        // Go to Login page
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginInfo obj)
        {

            // Validate our obj
            if (ModelState.IsValid)
            {
                // Check to see if provided username is in our db
                var user = _db.User.SingleOrDefault(user => user.Username == obj.Username);
                if (user != null)
                {
                    //Verify password
                    var hashResult = _passwordHasher.VerifyHashedPassword(user, user.Password, obj.Password);

                    if (hashResult.GetHashCode() == 1)
                    {
                        // Login user
                        // Set cookie in browser we will sessions to store our userID
                        HttpContext.Session.SetInt32("id", user.Id);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "Username or password invalid");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Username or password invalid");
                }
            }
            return View(obj);
        }

        // Go to Register page
        public IActionResult Register()
        {
            return View();
        }
        // Creates new user 
        [HttpPost]
        public IActionResult Register(User obj)
        {
            if (ModelState.IsValid)
            {
                // Is username available ?
                // I would like to use sql exception error unique contraint instead of this solution
                // To reduce exectued sql queries.
                var user = _db.User.SingleOrDefault(user => user.Username == obj.Username);
                // Username taken
                if (user != null)
                {
                    ModelState.AddModelError("Username", "Username already taken");

                }
                // Username available
                else
                {
                    // Hash password and add our new user to DB
                    var hashedPassword = _passwordHasher.HashPassword(obj, obj.Password);
                    obj.Password = hashedPassword;
                    _db.Add(obj);
                    _db.SaveChanges();


                    // Go to login page
                    return RedirectToAction("Login");
                }
            }
            return View(obj);
        }

        public IActionResult Logout()
        {
            //Clear session and delete cookies.
            HttpContext.Session.Clear();
            HttpContext.Response.Cookies.Delete("quid");
            // Go to home page
            return RedirectToAction("Index", "Home");
        }

        // Confirmation page after sending reset password link
        public IActionResult ForgotPasswordEmailSent()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {

            return View();
        }

        // Generate token and send password reset email
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPassword obj)
        {
            if (ModelState.IsValid)
            {
                // Validate if we have provided username in DB
                var user = _db.User.SingleOrDefault(user => user.Username == obj.Username);
                if (user != null)
                {
                    // Create a guid this will be used as a parameter for our route EX. localhost/Controller/Action/?id=GUID
                    // We will also use this to set a key in redis with a value of the users id.
                    // This key value will only be valid for 3 days.
                    // With this we can validate to Guid and update the correct users password
                    Guid myuuid = Guid.NewGuid();
                    string myuuidAsString = myuuid.ToString();
                    var message = new Message(user.Email, "test", myuuidAsString);
                    _emailManager.SendEmail(message);

                    var redis = _redis.GetDatabase();
                    DateTime now = DateTime.Now;
                    // Set key value in redis expires in 3 days
                    redis.StringSet(myuuidAsString, user.Id, expiry: now.AddDays(3) - now);
                    return RedirectToAction("ForgotPasswordEmailSent");
                }
                return RedirectToAction("ForgotPasswordEmailSent");
            }
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        // Reset users password
        [HttpPost]
        public IActionResult ResetPassword(string id, ResetPassword obj)
        {
            if (ModelState.IsValid)
            {
                // Validate that our route id parameter is in redis

                var redis = _redis.GetDatabase();
                var redisValue = redis.StringGet(id);
                //Convert redis value type to Int32
                var userIdString = redisValue.ToString();
                var userId = Int32.Parse(userIdString);
                
                if (userIdString != null)
                {
                    var user = _db.User.Find(userId);
                    if (user != null)
                    {
                        // hash new password and update user in db
                        var hashedPassword = _passwordHasher.HashPassword(user, obj.Password);
                        user.Password = hashedPassword;
                        _db.User.Update(user);
                        _db.SaveChanges();
                        // Delete key value pair in redis.
                        redis.StringGetDelete(id);
                        return RedirectToAction("ResetPasswordConfirmation");
                    }
                }
                // id parameter is expired
                ModelState.AddModelError("Password", "Looks like your link is expired please go to forgot password and get new link");

            }
            return View(obj);
        }

        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyUsers()
        {
            IEnumerable<User> objUserList = _db.User;
            return View(objUserList);
        }
    }
}
