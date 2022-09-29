using Microsoft.AspNetCore.Http;

namespace HttpProxy;

public interface IUrlReWriter
{
    Task<Uri> RewriteUri(HttpContext context);
}