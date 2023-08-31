# Atomatus BootStarter Middlewares

[![Help Wanted](https://img.shields.io/github/issues/atomatus/runtime/dot-net-boot-starter-middleware?style=flat-square&color=%232EA043&label=help%20wanted)](https://github.com/atomatus/dot-net-boot-starter-middleware/issues?q=is%3Aissue+is%3Aopen+label%3A%22up-for-grabs%22)
[![NuGet version (Com.Atomatus.BootStarter)](https://img.shields.io/nuget/v/Com.Atomatus.BootStarter.Middlewares.svg?style=flat-square)](https://www.nuget.org/packages/Com.Atomatus.BootStarter.Middlewares/)

The Com.Atomatus.Bootstarter.Middlewares library is an innovative solution developed by Atomatus to simplify and streamline the process of creating and implementing middlewares in projects based on the Bootstarter framework.

# Middleware Usage Guide

## Introduction

Middlewares are an essential part of the application pipeline that handle requests and responses. They provide a way to execute custom logic before or after the main application logic. This guide explains how to use various types of Middlewares and their benefits.

## Why Use Middlewares?

Middlewares offer several benefits:
- **Modularity**: Middlewares allow you to split application logic into smaller, reusable components.
- **Customization**: You can inject custom behavior into the request-response lifecycle.
- **Pipeline Manipulation**: Middlewares can manipulate the request/response pipeline, such as authentication, logging, error handling, etc.
- **Ordering**: Control the order in which Middlewares are executed.

## Examples

### Middleware<TService>

The `Middleware` executes its logic only once during the application's lifetime.

Usage:
```csharp
app.UseMiddleware<MyServiceMiddleware>();
```

```csharp
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class MyServiceMiddleware : Middleware<MyService>
{
    public MyServiceMiddleware(RequestDelegate next) : base(next) { }

    protected override void OnInvokeService(HttpContext context, MyService service)
    {
        // Custom logic using MyService
    }
}
```

### OneTimeMiddleware<TService>

The `OneTime Middleware` executes its logic only once time during the application's lifetime.

Usage:
```csharp
app.UseMiddleware<MyServiceOneTimeMiddleware>();
```

```csharp
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class MyServiceOneTimeMiddleware : Middleware<MyService0, MyService1>
{
    public MyServicesMiddleware(RequestDelegate next) : base(next) { }

    protected override Task OnInvokeServiceAsync(HttpContext context, MyService0 s0, MyService1 s1)
    {
        // Custom logic using MyService0 and MyService1
        return Task.CompletedTask;
    }
}
```

Follow similar patterns for other OneTimeMiddleware and Middleware variations with different numbers of services.

### Conclusion

Middlewares provide a powerful mechanism to customize and extend the behavior of your application's request-response pipeline. By utilizing different Middleware types, you can efficiently integrate various functionalities and services into your application without tightly coupling them.