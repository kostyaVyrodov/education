# ASP.NET MVC

## Request life cycle

1. The server creates an instance of ```MvcApplication: HttpApplication``` in the global.asax and invokes Application_Start method. Also Global.asax contains additional methods that allows to manage life cycle of application.
2. Mapping user's request to a handler using URL Routing Module. The app has a RouteTable containing all information about existing routes and handlers for them.

### Interesting notes

