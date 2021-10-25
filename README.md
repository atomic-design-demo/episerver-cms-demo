# README

## Installation

1. Clone this repo.
1. Restore the latest database in **backups** folder.
1. In **src/locals** folder, add following files:

   **connectionStrings.config**:

   ```xml
   <connectionStrings>
     <add
       name="EPiServerDB"
       connectionString="Data Source=.;Initial Catalog=episerver-cms-demo;Connection Timeout=60;Integrated Security=False;User ID=sa;Password=*****;MultipleActiveResultSets=True;"
       providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

   **episerverfind.config**:

   ```xml
   <episerver.find
     serviceUrl="https://demo****.find.episerver.net/*****/"
     defaultIndex="*****"/>
   ```

   Change your database/Find index info to your own instances.

1. Build and run the project

1. Go to CMS Editor and login with below account:

   - URL: <http://localhost:80/util/login.aspx?ReturnUrl=%2fEpiserver%2fCMS>  
     (Change `localhost:80` to your own domain).
   - Username: **demo**
   - Password: **Pass@word123!**
