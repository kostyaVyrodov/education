# About ActionResult in ASP.NET Core

An `ActionResult` is any type that implement IActionResult. Action results are classes representing things the client is supposed to do as a result of the controller action

## ActionResult sets

An `ActionResult` can be:
- status code;
- status code with object;s
- redirect results;
- file results;
- content result;

### Status Code results

**OK(200)**

```
public IActionResult OkResult()
{
    return Ok();
}
```

**Created(201)**

```
public IActionResult CreatedResult()
{
    return Created("http://example.org/myitem", new { name = "testitem" });
}
```

**NoContent(204)**

```
public IActionResult CreatedResult()
{
    return NoContent();
}
```

**BadRequest(400)**

```
public IActionResult BadRequestResult()
{
    return BadRequest();
}
```

**Unauthorized(401)**

```
public IActionResult UnauthorizedResult()
{
    return Unauthorized();
}
```

**NotFound(404)**

```
public IActionResult NotFoundResult()
{
    return NotFound();
}
```


**UnsupportedMediaType(415)**

```
public IActionResult UnsupportedMediaTypeResult()
{
    return UnsupportedMediaTypeResult();
}
```

**Any other codes**

```
public IActionResult StatusCodeResult(int statusCode)
{
    return StatusCode(statusCode);
}
```

## Status Code with Object Results

**OK(200) but with additional data**
```
public IActionResult OkObjectResult()
{
    var result = new OkObjectResult(new { message = "200 OK", currentDate = DateTime.Now });
    return result;
}
```

Similarly to status code responses, the responses supports same codes but with data in the body

## Redirect Results

**Redirect** (to any base url)

```
public IActionResult RedirectResult()
{
    return Redirect("https://www.exceptionnotfound.net");
}
```


**LocalRedirectResult** (to any base url)

```
public IActionResult LocalRedirectResult()
{
    return LocalRedirect("/redirects/target");
}
```

**RedirectOtActionResult**

```
public IActionResult RedirectToActionResult()
{
    return RedirectToAction("target");
}
```

## File result

File result allows returning files

**FileResult**

```
public IActionResult FileResult()
{
    return File("~/downloads/pdf-sample.pdf", "application/pdf");
}
```

**FileContentResult**. Allows to return bytes from memory

```
public IActionResult FileContentResult()
{
    //Get the byte array for the document
    var pdfBytes = System.IO.File.ReadAllBytes("wwwroot/downloads/pdf-sample.pdf");

    //FileContentResult needs a byte array and returns a file with the specified content type.
    return new FileContentResult(pdfBytes, "application/pdf");}
```

**VirtualFileResult**. Returns a file from /wwwroot

```
public IActionResult VirtualFileResult()
{
    //Paths given to the VirtualFileResult are relative to the wwwroot folder.
    return new VirtualFileResult("/downloads/pdf-sample.pdf", "application/pdf");
}
```

**PhysicalFileResult**. Allows to return a file from any place on the server

```
public IActionResult PhysicalFileResult()
{
    return new PhysicalFileResult(_hostingEnvironment.ContentRootPath + "/wwwroot/downloads/pdf-sample.pdf", "application/pdf");
}
```

## Content Result

Content results are used to return html based on views

**ViewResult** 

```
public IActionResult Index()
{
    return View();
}
```

**PartialViewResult**
```
public IActionResult PartialViewResult()
{
    return PartialView();
}
```

## JsonResult

```
public IActionResult JsonResult()
{
    return Json(new { message = "This is a JSON result.", date = DateTime.Now });
}
```

## ContentResult

```
public IActionResult ContentResult()
{
    return Content("Here's the ContentResult message.");
}
```
