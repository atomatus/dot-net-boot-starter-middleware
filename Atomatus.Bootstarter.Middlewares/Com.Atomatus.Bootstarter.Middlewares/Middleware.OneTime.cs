using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Com.Atomatus.Bootstarter.Middlewares
{
    /// <summary>
    /// Represents an abstract base class for one-time execution middleware implementations.
    /// </summary>
    public abstract class OneTimeMiddleware : Middleware
    {
        private volatile bool hasExecuted;

        /// <summary>
        /// Initializes a new instance of the <see cref="OneTimeMiddleware"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        protected OneTimeMiddleware(RequestDelegate next) : base(next) { }

        /// <summary>
        /// Handles the invocation of services by the one-time middleware.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        protected abstract void OnInvokeService(HttpContext context);

        /// <summary>
        /// Invokes the one-time middleware, executing custom behavior only on the first call and passing the request to the next middleware in the pipeline.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        protected sealed override Task OnInvokeServiceAsync(HttpContext context)
        {
            if (!hasExecuted)
            {
                this.OnInvokeService(context);
                hasExecuted = true;
            }
            return Task.CompletedTask;
        }
    }
}
