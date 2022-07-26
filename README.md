<h1>What is this project?</h1>
<div>
  <h3>Basic User Authentication using ASP.net MVC</h3>
  <h4>Tools</h4>
  <ul>
    <li>SSMS (SQL Server Management Studio)</li>
    <li>Session cookies</li>
    <li>Redis</li>
    <li>Entity Framework</li>
    <li>ASP.net MVC</li>
    <li>C#</li>
  </ul>
  
  <h1>How it works</h1>
  <p>This project shows a basic example of how one might register users, 
  login users, verify a user is logged in using session cookies and reset user passwords.
  </p>
  <h3>NOTE that this is just an example and the code above would NOT be used in a live website.<h3/>
  
  <h1>Set up</h1>
  <h3> I have provided some steps to get the code working on your device</h3>
  <h4>Pre requisites</h4>
  <ul>
    <li>Visual Studio 2022</li>
    <a href="https://visualstudio.microsoft.com/downloads/">Visual Studio Download</a>
    <sub>Get the community version</sub>
    <li>SSMS (Sql Server Management Studio) & SQL server installed and set up on your device</li>
    <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">Downlod sql server</a>
    <a href="https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16">Downlod SSMS</a>
    <li>Redis installed and set up on your device I have gone ahead a set up the project with Redis so just need it running</li>
    <a href="https://developer.redis.com/create/windows">Download and set up redis</a>
    <li>Basic understanding of the Entity Frame work</li>
    <a href="https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli">Using Entity</a>
    <li>Basic understanding ASP.net MVC</li>
    <a href="https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?WT.mc_id=dotnet-35129-website&view=aspnetcore-6.0&tabs=visual-studio">Docs for Asp.net mvc</a>
    <br />
    <a href="https://www.youtube.com/watch?v=hZ1DASYd9rk&t=5935s">Video on ASP.mvc and how it works.</a>
    <br />
    <sub>This video explains the concepts pretty well.</sub>
    <li>Basic C# and OOP (Object-oriented programming) theory</li>
    <a href="https://www.w3schools.com/cs/cs_oop.php">Basic grasp of C# and oop.<a/>
    <br />
    <sub>You can also just search YouTube for tons of great explanations.</sub>
    <li>How session cookies work</li>
    <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0">Session and state management in ASP.NET</a>
  </ul>
  <p>If you don't meet the above requirments no worries, I have provided some links to help you get started. I know it might seem like a lot but trust me when I say these are very basic topics. Researching is a big part of programming and getting used to that and learning how to do this is a key skill to have. :) </p>
  <hr />
  <h1>Steps</h1>
  <h3>Step 1</h3>
  <p>Clone this repository into your Visual Studio IDE</p>
  <img width="755" alt="git" src="https://user-images.githubusercontent.com/39133396/180621889-8851c289-243b-441f-b69f-e4ec0463504a.png">
  <img width="743" alt="repo" src="https://user-images.githubusercontent.com/39133396/180621894-5b0f2383-2632-4d69-8b17-aade88f4b732.png">
  <hr />
  <h3>Step 2</h3>
  <p>Make sure you have all these NuGet packages installed.</p>
  <img width="942" alt="tools" src="https://user-images.githubusercontent.com/39133396/180622558-116cab61-26f7-482e-91eb-33e615f09ce3.png">
  <img width="459" alt="NuGetPackeges" src="https://user-images.githubusercontent.com/39133396/180591148-f8efef97-52ab-44a6-a46a-f67753f41f24.png">
  <h4>If your packages look like this please follow the steps below. if not skip to step 3<h/4>
  <img width="942" src="https://user-images.githubusercontent.com/39133396/180624731-6a64fd97-349e-496e-9a8c-95c9d16d30cc.png">
    <ol>
      <li>click on the setting Icon</li>
      <img width="756" alt="badpackage" src="https://user-images.githubusercontent.com/39133396/180624813-964cbac5-a6c0-4c42-802f-35d7cf932f0b.png">
      <b4 />
      <li>Below window will open write the NuGet details if does not allow to write edit the existing</li>
      <img width="483" alt="addorg" src="https://user-images.githubusercontent.com/39133396/180624865-18176d18-4b7d-47d9-8eef-4034af535438.png">
    </ol>
  <hr />
  <h3>Step 3</h3>
  <p>Now we need to change one thing to get our DB connected. After we will create our database and table</p>
  <ol>
    <li>First let's change our connection string to match your SQL server. I just use my local machine to do this. You will change this in the appsetting.json file</li>
    <img width="968" alt="ConnectionString" src="https://user-images.githubusercontent.com/39133396/180590415-7cda17c1-daf6-4afe-8f21-7818b6541879.png">
    <li>Next were going to need to use migrations to create our DB and table so let's navigate to the NuGet package console.</li>
    <img width="733" alt="console" src="https://user-images.githubusercontent.com/39133396/180590433-77c6e0ad-830e-449a-8d9e-47a1b2c83320.png">
    <li>Navigate to project folder using this command cd UserAuthExample </li>
    <img width="745" alt="cd" src="https://user-images.githubusercontent.com/39133396/180590445-c2791d36-26f9-4cd4-aaf4-0425fcfd75d5.png">
    <li>Instal entity framework using this command dotnet tool install --global dotnet-ef</li>
    <img width="958" alt="Screenshot (34)" src="https://user-images.githubusercontent.com/39133396/180626595-7aa213a5-fcd9-4381-8639-98ee1eaee2cc.png">
    <li>Create migrations folder and file using this command dotnet ef migrations add User</li>
    <img width="931" alt="mig" src="https://user-images.githubusercontent.com/39133396/180590881-0caccb74-c10c-47ba-8e4b-ef2d3008b08e.png">
    <li>Create database and table using this command dotnet ef database update</li>
    <img width="771" alt="db" src="https://user-images.githubusercontent.com/39133396/180590524-452eb55f-bc27-4da9-88ea-6e44302c15c2.png">
    <img width="646" alt="ssms" src="https://user-images.githubusercontent.com/39133396/180590527-66a70d0f-c48b-49bb-a2f1-11909c9fd1c2.png">
  </ol>
  <hr />
  <h3>Step 4</h3>
  <p>Alright if everything  went well in the last step now were going to set up our connection to Redis. I am running Redis on my local machine. Navigate to the UserController file located in the Controllers folder and 
  change this string to the correct port and your password for Redis if you don't have Redis set up use this link to get it set up for windows.</p>

  <br />
  <a href="https://developer.redis.com/create/windows">Download and set up redis</a>
  <br />
  <img width="965" alt="Screenshot (29)" src="https://user-images.githubusercontent.com/39133396/180591810-3abd5470-b3f7-4893-a283-5be526ca2efa.png">
  <hr />
  <h4>Step 5</h3>
  <p>Almost done... all we need to do now is change the email configuration to match your email. I am using outlook here so if you have one too that's great!</p>
  <ol>
    <li>Go to your appsettings.json file and change the email configuration options</li>
    <img width="934" alt="Emailconfi" src="https://user-images.githubusercontent.com/39133396/180591234-6db4ec8e-5b98-4d14-ad2f-1356740dfc10.png">
    <li>Then navigate to the EmailManager class located in the data folder and change the from email address to yours and the link variable port number to the port you will be running the app on. This can be found in the launch setting inside the properties folder.</li>
    <img width="949" alt="EmailManager" src="https://user-images.githubusercontent.com/39133396/180621180-42afdd3f-8029-4886-ae65-7c54715d8308.png">
    <br />
<img width="949" alt="Luanch" src="https://user-images.githubusercontent.com/39133396/180591314-d6f46dc8-3b1f-4145-9b7d-15a4b78434bf.png">
  </ol>
  <hr />
    <h1>You're done!</h1>
    <p>Run the application and test its features you should be able to do the following:</p>
    <ul>
      <li>Login and see your username on the home page.</li>
      <li>Register a new user which will be added to your DB</li>
      <li>If the application is closed the session is cleared</li>
      <li>Log out, which will clear the session and cookies</li>
      <li>See a list of all you users registered in your DB on the MyUsers page</li>
      <li>Reset your password for a user. This feature will send an email with a link to the email address of the provided username. We will use Redis to store a token           which will be used to validate the request. This token is only valid for 3 days. With a valid token we can then update the user password in our DB.</li>
    </ul>
    <hr />
    <p>If you have any trouble setting up don't hesitate to message me but I encourage you to try and figure it out if you're learning. Running into errors and making mistakes is the best way to learn programming. In the future I might make a video to demo the project</p>
    
    
    
</div>
    
    
