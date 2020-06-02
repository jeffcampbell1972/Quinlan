Quinlan v1
----------

Author       : Jeff Campbell

Description  : The Quinlan application was written to support a client's inheritance 
               of a sports card collection.  I was provided a flat MS Access database
               which is used as the initialization data so when the application is 
               released to production, it will contain up-to-date information as of
               about 2012. 

Notes        : For the initial release, no research has been done with regard to 
               deployment of the website, either locally or on the cloud.  My client 
               probably does not need this application hosted on the cloud unless
               it is decided that the sports card collection is to be sold for max
               profit and thus it's contents would need to be viewable by prospective
               buyers.  Other options for my client include selling or donating the
               collection whole which means cloud hosting is not necessary.  At a 
               minimum, this app will need to be deployed to my client's local web
               server so that a full inventory can be performed.

Instructions : The application is being developed using Visual Studio 2019 with a
               local SQL Server database and the IIS Express web server to handle
               requests.  So the instructions will assume you are doing the same. 
               Version 2 should have an installer and be able to run outside of
               Visual Studio but I'm not there yet.

               1) Install Visual Studio Community 2019 which appears to be available
                  at https://visualstudio.microsoft.com/vs/community/ for free.  Other
                  versions of Visual Studio 2019 should work, but older versions 
                  probably won't. I think this brings the local SQL Server and IIS
                  Express with it, but you should verify until I can expand this part
                  of the instructions.

               2) Open Visual Studio and get the latest code.  This instruction also
                  needs to be more detailed.

               3) Under Build menu, click 'Build Solution' and verify that it compiles

               4) In Solution Explorer, right-click Quinlan.MVC and click 'Set as Startup Project'

               5) Under Debug menu, click 'Start without Debugging'

               6) This should take a bit of time as it is creating the database.  Once that is
                  complete, the home page should render with not data to show.  Exit application.

               7) 
               

