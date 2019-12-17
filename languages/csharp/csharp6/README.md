# C# 6.0 features

Here a list for new features that came with C#

## Read-only auto-properties

Read-only properties can initialized only in the body of constructor

```c#
public string FirstName { get; }
```

## Auto-property initializers

Allows easier to make initialization only once

```c#
public ICollection<double> Grades { get; } = new List<double>();
```

## Expression-bodied function members

```c#
public string FullName => $"{FirstName} {LastName}";
```

## Using static

No need to write before each static method the name of class 

```c#
using static System.Math;
```

## Null-conditional operator

Allows to make null checks shorter

```c#
var first = person?.FirsName
```

if person is null then variable will be assigned with null

## String interpolation

String interpolation feature enables you to embed expressions in a string

```c#
public string FullName => $"{FirstName} {LastName}";
```

## Exception filters

Exception Filters are clauses that determine when a given catch clause should be applied

```c#
public static async Task<string> MakeRequest()
{
    WebRequestHandler webRequestHandler = new WebRequestHandler();
    webRequestHandler.AllowAutoRedirect = false;
    using (HttpClient client = new HttpClient(webRequestHandler))
    {
        var stringTask = client.GetStringAsync("https://docs.microsoft.com/en-us/dotnet/about/");
        try
        {
            var responseText = await stringTask;
            return responseText;
        }
        catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
        {
            return "Site Moved";
        }
    }
}
```

## The 'nameof' expression

The nameof expression evaluates to the name of a symbol. 

```c#
if (IsNullOrWhiteSpace(lastName))
    throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
```

## Await in Catch and Finally blocks

```c#
public static async Task<string> MakeRequestAndLogFailures()
{ 
    await logMethodEntrance();
    var client = new System.Net.Http.HttpClient();
    var streamTask = client.GetStringAsync("https://localHost:10000");
    try {
        var responseText = await streamTask;
        return responseText;
    } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
    {
        await logError("Recovered from redirect", e);
        return "Site Moved";
    }
    finally
    {
        await logMethodExit();
        client.Dispose();
    }
}
```

## Initialize associative collections using indexers

```c#
private Dictionary<int, string> messages = new Dictionary<int, string>
{
    { 404, "Page not Found"},
    { 302, "Page moved, but left a forwarding address."},
    { 500, "The web server can't come out to play today."}
};
```
