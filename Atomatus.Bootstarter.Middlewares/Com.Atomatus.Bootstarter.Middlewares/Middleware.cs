using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Com.Atomatus.Bootstarter.Middlewares
{
    /// <summary>
    /// Represents an abstract base class for middleware implementations.
    /// </summary>
    public abstract class Middleware : IMiddleware
    {
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="Middleware"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="next"/> is null.</exception>
        protected Middleware(RequestDelegate next)
        {
            this.next = next ?? throw new ArgumentNullException(nameof(next));
        }

        /// <summary>
        /// Handles the invocation of services by the middleware asynchronously.
        /// Derived classes must implement this method to provide custom behavior.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        protected abstract Task OnInvokeServiceAsync(HttpContext context);

        /// <summary>
        /// Invokes the middleware asynchronously, executing custom behavior and passing the request to the next middleware in the pipeline.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            await this.OnInvokeServiceAsync(context);
            await this.next(context);
        }
    }

}
