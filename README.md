This porject was built for the Capital placement dev task

I made use of .Net 8 & Cosmos DB as instructed. The project consists of 2 projects, main ProgramApplicationMngr project that has the webAPIs for the CRUD operations & the ProgramApplicationMngr.Core project which
has the data objects (i.e Programs,Applications & QuestionTypes) & also the repository patterns for accessing/managing the data objects.
I created 3 controllers as follows:

ProgramController: 
This controller is to be used by the employer to create programs and add custom questions based on the available Question Types available within the system. 
The owner is able to create programs by defining which personal information data is required or oprtional for each program. The owner is also able to add as many custom questions as required.
It is also to be used by the front-end team to render the application form based on Programs which have their questions & question types embbeded.

ConfigController:
I added this controller to enable front-end devs to retrieve the list of available Question Types and see the data type each of those question types require in order to guide how the question type info should be structed.

ApplicationsController:
This countroller is to be used for submitting new applications based on the program being applied for. A user can create or edit an application with a valid program & corresponding custome questions & their personal information
