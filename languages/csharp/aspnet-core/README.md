# ASP.NET Core notes

ASP.NET Core is a cross-platform .NET framework for building cloud-based web applications on Windows, Mac, or Linux.

Benefits:

- ASP.NET core is runnable on both .NET Core and .NET Framework;
- Can be host on kestrel, IIS, HTTP.sys, Docker, Nginx, Apache;
- Built-in dependency injection;
- Has [Blazor](https://docs.microsoft.com/en-us/aspnet/core/blazor/index?view=aspnetcore-3.0). C# in markup;

## Table of contents

1. The Startup.cs
1. DI
1. Middleware
1. Host
1. Servers
1. Configuration
1. Options
1. Environments
1. Logging
1. Routing
1. Error handling
1. Making HTTP requests
1. Content root
1. Web root

## The Startup.cs

**Startup.cs** is class where:

- Services required by the app are configured in the function ```void ConfigureServices(IServiceCollection services)```;
- The request handling pipeline is defined ```public void Configure(IApplicationBuilder app)```;

## DI

Also ASP.NET Core has a built-in **dependency injection (DI)** framework that makes configured services available to an app's classes.

## Middleware

The request handling pipeline is composed as a series of **middleware** components. Each component performs asynchronous operations on an HttpContext and then either invokes the next middleware in the pipeline or terminates the request. It means that the all middlewares share the same HttpContext.

## Host

The **host** is an object that encapsulates all of the app's resources, such as: an HTTP server implementation, middlewares, logging, DI, Configuration. Program.main() creates the Host object.
Two hosts are available: the Generic Host and the Web Host. The Generic Host is recommended, and the Web Host is available only for backwards compatibility.

## Servers

Windows:

- Kestrel;
- IIS Http;
- HTTP.sys;

macOS and linux:

- nginx;
- apache;

## Configuration

Config providers:

- Azure key vault;
- Azure app configuration;
- Command line arguments;
- Custom providers;
- config files (appSettings.json);
- Secret Manager tool;
- Azure Key Vault;

## Options

The options pattern uses classes to represent groups of related settings.

## Environments

ASPNETCORE_ENVIRONMENT - allows to set the type of environment;

Main environments:

- Development;
- Staging;
- Production;

## Logging

ASP.NET Core supports a built-in logging API that.

## Routing

TBD

## Error handling

Built-in features for handling errors, such as:

- A developer exception page;
- Custom error pages;
- Static status code pages;
- Startup exception handling;

## Making HTTP requests

An implementation of IHttpClientFactory is available for creating HttpClient instances. The factory:

- Provides a central location for naming and configuring logical HttpClient instances. For example, a github client can be registered and configured to access GitHub. A default client can be registered for other purposes;
- Supports registration and chaining of multiple delegating handlers to build an outgoing request middleware pipeline. This pattern is similar to the inbound middleware pipeline in ASP.NET Core. The pattern provides a mechanism to manage cross-cutting concerns around HTTP requests, including caching, error handling, serialization, and logging;
- Integrates with Polly, a popular third-party library for transient fault handling.
Manages the pooling and lifetime of underlying HttpClientMessageHandler instances to avoid common DNS problems that occur when manually managing HttpClient lifetimes;
- Adds a configurable logging experience (via ILogger) for all requests sent through clients created by the factory;

## Content root

The content root is the base path to any private content used by the app, such as its Razor files. By default, the content root is the base path for the executable hosting the app

## Web root

The web root (also known as webroot) is the base path to public, static resources, such as CSS, JavaScript, and image files.
