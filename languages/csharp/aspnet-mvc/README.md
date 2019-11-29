# ASP.NET MVC

## Request life cycle

More details about the [life cycle](https://opdhsblobprod04.blob.core.windows.net/contents/ed5efb1947c04bb29402a0c08d68958e/d0ed2e012c44fea6a368d4591ea14088?sv=2015-04-05&sr=b&sig=NdTFWa0qe7%2BJl62n%2BaKT3Sw%2FktCYHtwKqUiJIEuuvME%3D&st=2019-11-28T15%3A31%3A34Z&se=2019-11-29T15%3A41%3A34Z&sp=r)

1. The server creates an instance of ```MvcApplication: HttpApplication``` based on the global.asax and invokes Application_Start method. Also Global.asax contains additional methods that allows to manage life cycle of application;
1. Mapping user's request to a handler using URL Routing Module. The app has a RouteTable containing all information about existing routes and handlers for them;
1. Creating controller based on information request:
    - IControllerFactory.CreateController;
    - <Named>Controller.ctor;
    - Controller.BeginExecute;
    - Controller.Initialize;
    - Controller.BeginExecuteCore;
    - Controller.CreteTempDataProvidver;
    - Controller.CreateActionInvoker;
1. Authentication and authorization:
    - Authentication filter (OnAuthentication);
    - Authorization filter (OnAuthorization);
1. Model binding;
1. Action method invocation:
    - Controller.OnActionExecuting;
    - ActionFilter.OnActionExecuting;
    - Controller.ActionExecute();
    - Controller.EndExecute();
    - ActionFiler.OnActionExecuted();
1. Result Execution:
    - Controller.OnResultExecuting;
    - ResultFilter.OnResultExecuting;
    - Controller.ActionExecute();
    - Controller.EndExecute();
    - ResultFiler.OnActionExecuted();
    - Controller.OnResultExecuted;
