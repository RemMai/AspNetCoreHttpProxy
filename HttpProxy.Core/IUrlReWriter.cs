using Microsoft.AspNetCore.Http;

namespace HttpProxy.Core;

public interface IUrlReWriter
{
    Task<Uri> RewriteUri(HttpContext context);
}