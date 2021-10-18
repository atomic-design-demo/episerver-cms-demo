# READ ME

## Installation

1. Clone this repo.
1. Restore the latest database in the **backups** folder.
1. In the **src/locals** add following files:

   connectionStrings.config:

   ```xml
   <connectionStrings>
     <add
       name="EPiServerDB"
       connectionString="Data Source=.;Initial Catalog=episerver-cms-demo;Connection Timeout=60;Integrated Security=False;User ID=sa;Password=*****;MultipleActiveResultSets=True;"
       providerName="System.Data.SqlClient" />
   </connectionStrings>
   ```

   episerverfind.config:

   ```xml
   <episerver.find
     serviceUrl="https://demo****.find.episerver.net/*****/"
     defaultIndex="*****"/>
   ```

   Change your database/search index info to your own instances.

1. Build and run the project