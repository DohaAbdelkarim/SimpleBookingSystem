# SimpleBookingSystem

SimpleBookingSystem solution contain 3 projects: 
1) SimpleBookingSystem.API -.Net core API-
2) SimpleBookingSystem.UnitTest -Xunit .Net core project-
3) SimpleBookingSystemUI -Angular app-

To run the Project you will need to run the API then run the UI using 'npm i' to install the packages and 'ng serve' as they are in separate projects.

Further enhancemnet to be done:
API:

-Implement Integration testing.

-Implement handling error module to throw errors (eg. badRequest, notFound) from services to be catched in the controller and in this case CreateBookingResponseModel will only hold the Id, 
Error codes will be applied accroding to the HttpStatusCode we return, the UI will implement the messages for this error codes in case we wanted to localize the messages in future.

-Return Error codes in CreateBookingRequestModelValidator instead of messages and let the UI will implement the messages for this error codes in case we wanted to localize the messages in future.

-Enhance the Mail Service to be able to send mail accroding to determined mails acroding to the event(eg. book a resouce, cancel a booking).

UI:
-Enhance the styling
-add validation messages
-Implement HttpInterceptor to handle the api httpStatusResposes in case there is any error.
