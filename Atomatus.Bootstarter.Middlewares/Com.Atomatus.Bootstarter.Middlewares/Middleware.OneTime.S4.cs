using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Com.Atomatus.Bootstarter.Middlewares
{
    /// <summary>
    /// Represents an abstract base class for one-time execution middleware implementations that utilize four specific services.
    /// </summary>
    /// <typeparam name="TService0">The type of the first service to be used by the middleware.</typeparam>
    /// <typeparam name="TService1">The type of the second service to be used by the middleware.</typeparam>
    /// <typeparam name="TService2">The type of the third service to be used by the middleware.</typeparam>
    /// <typeparam name="TService3">The type of the fourth service to be used by the middleware.</typeparam>
    public abstract class OneTimeMiddleware<TService0, TService1, TService2, TService3> : Middleware<TService0, TService1, TService2, TService3>
    {
        private volatile bool hasExecuted;

        /// <summary>
        /// Initializes a new instance of the <see cref="OneTimeMiddleware{TService0, TService1, TService2, TService3}"/> class.
        /// </summary>
        /// <param name="next">The delegate representing the next middleware in the pipeline.</param>
        protected OneTimeMiddleware(RequestDelegate next) : base(next) { }

        /// <summary>
        /// Handles the invocation of services by the one-time middleware asynchronously.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <param name="s2">The third service to be used by the middleware.</param>
        /// <param name="s3">The fourth service to be used by the middleware.</param>
        protected abstract void OnInvokeService(HttpContext context, TService0 s0, TService1 s1, TService2 s2, TService3 s3);

        /// <summary>
        /// Invokes the one-time middleware asynchronously, executing custom behavior only on the first call and passing the request to the next middleware in the pipeline.
        /// </summary>
        /// <param name="context">The HTTP context for the request.</param>
        /// <param name="s0">The first service to be used by the middleware.</param>
        /// <param name="s1">The second service to be used by the middleware.</param>
        /// <param name="s2">The third service to be used by the middleware.</param>
        /// <param name="s3">The fourth service to be used by the middleware.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous middleware operation.</returns>
        protected sealed override Task OnInvokeServiceAsync(HttpContext context, TService0 s0, TService1 s1, TService2 s2, TService3 s3)
        {
            if (!hasExecuted)
            {
                this.OnInvokeService(context, s0, s1, s2, s3);
                hasExecuted = true;
            }
            return Task.CompletedTask;
        }
    }

}
