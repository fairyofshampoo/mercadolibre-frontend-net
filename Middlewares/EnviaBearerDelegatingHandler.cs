using System.Security.Claims;

namespace frontendnet.Middlewares;

public class EnviaBearerDelegatingHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("Authorization", "Bearer" + httpContextAccessor.HttpContext?.User.FindFirstValue("jwd"));
        return base.SendAsync(request, cancellationToken);
    }
}
