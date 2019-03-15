using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Application.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomIPRateMiddleware : IpRateLimitMiddleware
    {
        public CustomIPRateMiddleware(RequestDelegate next, IOptions<IpRateLimitOptions> options, IRateLimitCounterStore counterStore, IIpPolicyStore policyStore, IRateLimitConfiguration config, ILogger<IpRateLimitMiddleware> logger) : base(next, options, counterStore, policyStore, config, logger)
        {
        }

        public override Task ReturnQuotaExceededResponse(HttpContext httpContext, RateLimitRule rule, string retryAfter)
        {
            string str = string.Format("API calls quata exceeded!! maximum admitted  {0} per {1}", rule.Limit, rule.Period);
            httpContext.Response.Headers["Retry.After"] = retryAfter;
            httpContext.Response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(new {error = str});
            httpContext.Response.StatusCode = 429;
            return httpContext.Response.WriteAsync(result);
            //return base.ReturnQuotaExceededResponse(httpContext, rule, retryAfter);
        }
    }
}
