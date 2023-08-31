using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Com.Atomatus.Bootstarter.Middlewares
{
    /// <summary>
    /// Represents an abstract base class for middleware implementations that utilize five specific services.
    /// </summary>
    /// <typeparam name="TService0">The type of the first service to be used by the middleware.</typeparam>
    /// <typeparam name="TService1">The type of the second service to be used by the middleware.</typeparam>
    /// <typeparam name="TService2">The type of the third service to be used by the middleware.</typeparam>
    /// <typeparam name="TService3">The type of the fourth service to be used by the middleware.</typeparam>
    /// <typeparam name="TService4">The type of the fifth service to be used by the middleware.</typeparam>
    public abstract class Middleware<TService0, TService1, TService2, TService3, TService4>
        : IMiddleware<TService0, TService1, TService2, TService3, TService4>
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="Middleware{TService0, TService1, TService2, TService3, TService4}"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        protected Middleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Handles the invocation of services by the middleware asynchronously.
        /// Derived classes must implement this method to provide custom behavior.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <param name="s2">The third service to be used by the middleware.</param>
        /// <param name="s3">The fourth service to be used by the middleware.</param>
        /// <param name="s4">The fifth service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        protected abstract Task OnInvokeServiceAsync(HttpContext context, TService0 s0, TService1 s1, TService2 s2, TService3 s3, TService4 s4);

        /// <summary>
        /// Invokes the middleware asynchronously with the specified services,
        /// executing custom behavior and passing the request to the next middleware in the pipeline.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <param name="s2">The third service to be used by the middleware.</param>
        /// <param name="s3">The fourth service to be used by the middleware.</param>
        /// <param name="s4">The fifth service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        public async Task InvokeAsync(HttpContext context, TService0 s0, TService1 s1, TService2 s2, TService3 s3, TService4 s4)
        {
            await this.OnInvokeServiceAsync(context, s0, s1, s2, s3, s4);
            await this.next(context);
        }
    }
}
