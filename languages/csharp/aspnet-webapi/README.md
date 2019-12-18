# ASP.NET WebAPI 2.0

## Controllers

A web API controller action return:

1. void ~ 204 (NoContent)
1. HttpResponseMessage -> convert directly to an HTTP response message 
1. IHttpActionResult -> calls ExecuteAsync to create -> an HttpResponse message
1. Any other type -> serializes return value into the response body and returns 200 (OK)

## Routing 

ASP.NET WebAPI uses routing table to determine which action to invoke

```c#
// Default routing table in 'ASP.NET WebAPI 2.0 in the WebAPI config'
routes.MapHttpRoute(
    name: "ActionApi",
    routeTemplate: "api/{controller}/{action}/{id}",
    defaults: new { id = RouteParameter.Optional }
);

// Customized routing table in
routes.MapHttpRoute(
    name: "API Default",
    routeTemplate: "api/{controller}/public/{category}/{id}",
    // Default value for id
    defaults: new { category = "all" }
    // constraints
    constraints: new { id = @"\d+" }
);
```

Routing as three main phases:

1. Matching the URL to a route template
1. Selecting a controller
1. Selecting an action

Each item of a route table has to special placeholders: "{controller}" and "{action}". If the frameworks finds a match for a URI, it creates a dictionary that contains the value for each placeholder. A value for the placeholder is taken from URI or from default values. The dictionary in the `IHttpRouteData` object

**Selecting a controller**

Framework uses `HttpControllerDescriptor IHttpControllerSelector.SelectController(HttpRequestMessage)` method to select a controller

Be default the selection algorithm is following:
1. look in the route dictionary for the key `controller`;
1. take the value of a key and appends the string 'Controller' to get the controller type name
1. finlay looks for the controller

**Selecting an action**

Framework uses `HttpActionDescriptor IHttpActionSelector.SelectAction(HttpControllerContext)` method to select an action

Be default the selection algorithm is following:
1. the HTTP method of the request.
1. the "{action}" placeholder in the route template, if present.
1. the parameters of the actions on the controller.

An action is a method inside a class derived from `ApiController` class. All other class members like event, delegate, constructor are excluded

Parameter binding in actions: simple params are taken from URI and complex are taken from request body

If there are several actions matching a request, the app will throw an `System.InvalidOperationException` exception

### Routing Attributes

`[HttpGet]`, `[HttPost]`, etc. allows to specify which HTTP verb to apply to specific action

`[AcceptVerbs("GET", "HEAD")]` allows to specify several verbs to one action

`[NonAction]` allow to mark a method inside controller as non action

To avoid using attributes you can start your action with "Get", "Post", "Put", "Delete", "Head", "Options", or "Patch". Like: PostUser or OptionsUser

`[Route("customers/{customerId}/orders")]` allows to specify exact path to your action. To enable routing attribute it's necessary to call `config.MapHttpAttributeRoutes();` Register in the  WebApiConfig

`[RoutePrefix]` allows to specify a prefix for all routes. It can be applied to a controller


**Constraint**

```
[Route("users/{id:int:min(1)}")]
public User GetUserById(int id) { ... }
```

Also it's possible to implement custom constraint


**Optional URI parameter and default parameter:**

```c#
public class BooksController : ApiController
{
    [Route("api/books/locale/{lcid:int?}")]
    public IEnumerable<Book> GetBooksByLocale(int lcid = 1033) { ... }
}
```
