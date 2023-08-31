using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Com.Atomatus.Bootstarter.Middlewares
{
    /// <summary>
    /// Represents an abstract base class for one-time execution middleware implementations that utilize a specific service.
    /// </summary>
    /// <typeparam name="TService">The type of service to be used by the middleware.</typeparam>
    public abstract class OneTimeMiddleware<TService> : Middleware<TService>
    {
        private volatile bool hasExecuted;

        /// <summary>
        /// Initializes a new instance of the <see cref="OneTimeMiddleware{TService}"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        protected OneTimeMiddleware(RequestDelegate next) : base(next) { }

        /// <summary>
        /// Handles the invocation of services by the one-time middleware asynchronously.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="service">The service to be used by the middleware.</param>
        protected abstract void OnInvokeService(HttpContext context, TService service);

        /// <summary>
        /// Invokes the one-time middleware asynchronously, executing custom behavior only on the first call and passing the request to the next middleware in the pipeline.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="service">The service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        protected sealed override Task OnInvokeServiceAsync(HttpContext context, TService service)
        {
            if (!hasExecuted)
            {
                this.OnInvokeService(context, service);
                hasExecuted = true;
            }
            return Task.CompletedTask;
        }
    }
}
