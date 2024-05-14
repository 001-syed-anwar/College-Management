To run and launch the app,
* Install VisualStudio
* Install MySQL https://dev.mysql.com/downloads/installer/
* Open the project by it's solution.
* Update the mysql username and password in app.settings.json file under "connectionstring" key.
* Open package manager console (tools -> nuget package manager -> package manager console) and type the following commands,
add-migration "identity" -context ApplicationIdentityDbContext (not required if migration file already exists)
update-database -context ApplicationIdentityDbContext 
add-migration "student" -context ApplicationDbContext (not required if migration file already exists) 
update-database -context ApplicationDbContext

now run and launch the application.
