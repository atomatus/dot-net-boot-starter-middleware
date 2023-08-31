using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Com.Atomatus.Bootstarter.Middlewares
{
    /// <summary>
    /// Represents the base interface for all middlewares.
    /// </summary>
    public interface IMiddleware { }

    /// <summary>
    /// Represents a middleware interface that takes one service for invocation.
    /// </summary>
    /// <typeparam name="TService">The type of service to be used by the middleware.</typeparam>
    public interface IMiddleware<TService> : IMiddleware
    {
        /// <summary>
        /// Invokes the middleware asynchronously with the specified HTTP context and service.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="service">The service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        Task InvokeAsync(HttpContext context, TService service);
    }

    /// <summary>
    /// Represents a middleware interface that takes two services for invocation.
    /// </summary>
    /// <typeparam name="TService0">The type of the first service to be used by the middleware.</typeparam>
    /// <typeparam name="TService1">The type of the second service to be used by the middleware.</typeparam>
    public interface IMiddleware<TService0, TService1> : IMiddleware
    {
        /// <summary>
        /// Invokes the middleware asynchronously with the specified HTTP context and services.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        Task InvokeAsync(HttpContext context, TService0 s0, TService1 s1);
    }

    /// <summary>
    /// Represents a middleware interface that takes three services for invocation.
    /// </summary>
    /// <typeparam name="TService0">The type of the first service to be used by the middleware.</typeparam>
    /// <typeparam name="TService1">The type of the second service to be used by the middleware.</typeparam>
    /// <typeparam name="TService2">The type of the third service to be used by the middleware.</typeparam>
    public interface IMiddleware<TService0, TService1, TService2> : IMiddleware
    {
        /// <summary>
        /// Invokes the middleware asynchronously with the specified HTTP context and services.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <param name="s2">The third service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        Task InvokeAsync(HttpContext context, TService0 s0, TService1 s1, TService2 s2);
    }

    /// <summary>
    /// Represents a middleware interface that takes four services for invocation.
    /// </summary>
    /// <typeparam name="TService0">The type of the first service to be used by the middleware.</typeparam>
    /// <typeparam name="TService1">The type of the second service to be used by the middleware.</typeparam>
    /// <typeparam name="TService2">The type of the third service to be used by the middleware.</typeparam>
    /// <typeparam name="TService3">The type of the fourth service to be used by the middleware.</typeparam>
    public interface IMiddleware<TService0, TService1, TService2, TService3> : IMiddleware
    {
        /// <summary>
        /// Invokes the middleware asynchronously with the specified HTTP context and services.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <param name="s2">The third service to be used by the middleware.</param>
        /// <param name="s3">The fourth service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        Task InvokeAsync(HttpContext context, TService0 s0, TService1 s1, TService2 s2, TService3 s3);
    }

    /// <summary>
    /// Represents a middleware interface that takes five services for invocation.
    /// </summary>
    /// <typeparam name="TService0">The type of the first service to be used by the middleware.</typeparam>
    /// <typeparam name="TService1">The type of the second service to be used by the middleware.</typeparam>
    /// <typeparam name="TService2">The type of the third service to be used by the middleware.</typeparam>
    /// <typeparam name="TService3">The type of the fourth service to be used by the middleware.</typeparam>
    /// <typeparam name="TService4">The type of the fifth service to be used by the middleware.</typeparam>
    public interface IMiddleware<TService0, TService1, TService2, TService3, TService4> : IMiddleware
    {
        /// <summary>
        /// Invokes the middleware asynchronously with the specified HTTP context and services.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <param name="s2">The third service to be used by the middleware.</param>
        /// <param name="s3">The fourth service to be used by the middleware.</param>
        /// <param name="s4">The fifth service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        Task InvokeAsync(HttpContext context, TService0 s0, TService1 s1, TService2 s2, TService3 s3, TService4 s4);
    }
}
