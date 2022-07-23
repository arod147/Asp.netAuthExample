<h1>What is this?</h1>
<div>
  <h3>Basic User Authentication using ASP.net MVC</h3>
  <h4>Tools</h4>
  <ul>
    <li>SSMS (Sql Server Management Studio)</li>
    <li>Sessions cookies</li>
    <li>Redis</li>
    <li>Entity Frame work</li>
    <li>ASP.net MVC</li>
    <li>C#</li>
  </ul>
  
  <h1>How it works</h1>
  <p>This project shows a basic example of how one might register users, 
  login them in, verify a user is logged in using session cookies and reset user passwords.
  </p>
  <h3>NOTE that this is just an example and the code above would NOT be used in a live website.<h3/>
  
  <h1>Set up</h1>
  <h3> I have provided some steps to get the code working on your device</h3>
  <h4>Pre requisites</h4>
  <ul>
    <li>Visual Studio 2022</li>
    <a href="https://visualstudio.microsoft.com/downloads/">Visual Studio Download</a>
    <sub>Get the community version</sub>
    <li>SSMS (Sql Server Management Studio) & Sql server installed and set up on your device</li>
    <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads">Downlod sql server</a>
    <a href="https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16">Downlod SSMS</a>
    <li>Redis installed and set up on your device I have gone ahead a set up the project with redis so just need it running</li>
    <a href="https://developer.redis.com/create/windows">Download and set up redis</a>
    <li>Basic understanding of the Entity Frame work</li>
    <a href="https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli">Using Entity</a>
    <li>Basic understanding ASP.net MVC</li>
    <a href="https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?WT.mc_id=dotnet-35129-website&view=aspnetcore-6.0&tabs=visual-studio">Docs for Asp.net mvc</a>
    <a href="https://www.youtube.com/watch?v=hZ1DASYd9rk&t=5935s">Video on ASP.mvc and how it works.</a>
    <br />
    <sub>This video explains the concepts pretty well.</sub>
    <li>Basic C# and OOP (Object-oriented programming) theory</li>
    <a href="https://www.w3schools.com/cs/cs_oop.php">Basic grasp of C# and oop.<a/>
    <br />
    <sub>You can also just search youtube for tons of great explinations.</sub>
    <li>How session cookies work</li>
    <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-6.0">Session and state management in ASP.NET</a>
  </ul>
  <p>If you dont meet the above requirments no worries I have provided some links to help you get started. I know it might seem like a lot but trust me when I say these are very basic topics. Researching is a big part of programming and getting used to that and learning how to do this is a key skill to have. :) </p>
  <hr />
  <h1>Steps</h1>
  <h3>Step 1</h3>
  <p>Clone this repository into you Visual Sudio IDE</p>
  <hr />
  <h3>Step 2</h3>
  <p>Make sure you have all these NuGet packages installed.</p>
  <img width="459" alt="NuGetPackeges" src="https://user-images.githubusercontent.com/39133396/180591148-f8efef97-52ab-44a6-a46a-f67753f41f24.png">
  <hr />
  <h3>Step 3</h3>
  <p>Now we need to change one thing to get our DB connected. After we will create our database and table</p>
  <ol>
    <li>First lets change our connection string to match your sql server. I just use my local machine to do this. You will change this in the appsetting.json file</li>
    <img width="968" alt="ConnectionString" src="https://user-images.githubusercontent.com/39133396/180590415-7cda17c1-daf6-4afe-8f21-7818b6541879.png">
    <li>Next were going to need to use migrations to create our DB and table so lets navigate to the NuGet package console.</li>
    <img width="733" alt="console" src="https://user-images.githubusercontent.com/39133396/180590433-77c6e0ad-830e-449a-8d9e-47a1b2c83320.png">
    <li>Navigate to project folder using this command cd UserAuthExample </li>
    <img width="745" alt="cd" src="https://user-images.githubusercontent.com/39133396/180590445-c2791d36-26f9-4cd4-aaf4-0425fcfd75d5.png">
    <li>Create migrations folder and file using this command dotnet ef migrations add User</li>
    <img width="931" alt="mig" src="https://user-images.githubusercontent.com/39133396/180590881-0caccb74-c10c-47ba-8e4b-ef2d3008b08e.png">
    <li>Create database and table using this command dotnet ef database update</li>
    <img width="771" alt="db" src="https://user-images.githubusercontent.com/39133396/180590524-452eb55f-bc27-4da9-88ea-6e44302c15c2.png">
    <img width="646" alt="ssms" src="https://user-images.githubusercontent.com/39133396/180590527-66a70d0f-c48b-49bb-a2f1-11909c9fd1c2.png">
  </ol>
  <hr />
  <h3>Step 4</h3>
  <p>Alright if eveything went well in the last step now were going to set up our connection to redis I am running redis on my local machine</p>
  <h5>Change this string to the correct port and your password for redis if you dont have redis set up use the this link to get it set up for windows.</h5>
  <br />
  <a href="https://developer.redis.com/create/windows">Download and set up redis</a>
  <br />
  <img width="782" alt="Redis" src="https://user-images.githubusercontent.com/39133396/180590735-d8bbe0f8-552a-41a7-99cd-1218212ff2fb.png">
  <hr />
  <h4>Step 5</h3>
  <p>Almost done... all we need to do now is change the email configuration to match your email. I am using outlook here so if you have one too thats great!</p>
  <ol>
    <li>Go to your appsettings.json file and change the email configuration options</li>
    <img width="934" alt="Emailconfi" src="https://user-images.githubusercontent.com/39133396/180591234-6db4ec8e-5b98-4d14-ad2f-1356740dfc10.png">
    <li>Then navigate to the EmailManager class located in the data folder and change the from email address to yours and the link variable port number to the port you will be running the app on. This can be found in the launch setting inside the properties folder.</li>
    <img width="949" alt="EmailManager" src="https://user-images.githubusercontent.com/39133396/180591045-f6eba677-9b09-41ce-b3cf-9c4101739c84.png">
    <br />
<img width="949" alt="Luanch" src="https://user-images.githubusercontent.com/39133396/180591314-d6f46dc8-3b1f-4145-9b7d-15a4b78434bf.png">
  </ol>
  <hr />
    <h1>Your done!</h1>
    <p>Run the application and test its features you should be able to to the following</p>
    <ul>
      <li>Login and see your username on the home page.</li>
      <li>Register a new user which will be added to your DB</li>
      <li>If the application is closed the session is cleared</li>
      <li>Log out, which will clear the session and cookies</li>
      <li>See a list of all you users registerd in your DB on the MyUsers page</li>
      <li>Reset your password for a user. This feature will send a email with a link to the email address of the provided username. Will use redis to store a token which will be used to validate the request. This token is ony valid for 3 days. With a valid token we can then update the user password in our DB.</li>
    </ul>
</div>
