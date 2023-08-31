using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Com.Atomatus.Bootstarter.Middlewares
{
    /// <summary>
    /// Represents an abstract base class for middleware implementations that utilize a specific service.
    /// </summary>
    /// <typeparam name="TService">The type of service to be used by the middleware.</typeparam>
    public abstract class Middleware<TService> : IMiddleware<TService>
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="Middleware{TService}"/> class.
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
        /// <param name="service">The service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        protected abstract Task OnInvokeServiceAsync(HttpContext context, TService service);

        /// <summary>
        /// Invokes the middleware asynchronously with the specified service,
        /// executing custom behavior and passing the request to the next middleware in the pipeline.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="service">The service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        public async Task InvokeAsync(HttpContext context, TService service)
        {
            await this.OnInvokeServiceAsync(context, service);
            await this.next(context);
        }
    }
}
