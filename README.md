# BazarSodai



## Prerequirements

* Visual Studio 2022
* .NET Core SDK
* SQL Server

## How To Run

* Open solution in Visual Studio 2022
* Set .Web project as Startup Project and build the project.
* Run the application.
* Import the ShopDatabse.bacpac file in Microsoft Sql Server Management Studio
  Right click on Database Folder -> Tasks -> Import Data-tier Application -> Select the ShopDatabase.bacpac file

## Overview 
  
 - `Content/*` - It contains all css files for both user and admin interface.
 - `Script/*` - It has all Js files which are required to run the cshtml files. 
 - `Model/*` - It contains all auto-generated files from database including context, diagram and validation codes. 
 - `Controller/*` - It has all the required codes in HomeController which communicates with the cshtml files. 
 - `Views/AdminView*` - It has all the cshtml files which generates the admin part of the website.
 - `Views/Home*` - It has all the cshtml files which generates the user part of the website.
 - `View/shared` - Generally it contains the shared resources like header and footer , error page.
 - `scss/*` - Contains all scss files.
 - `images/*` - Contains all required image for the website.
