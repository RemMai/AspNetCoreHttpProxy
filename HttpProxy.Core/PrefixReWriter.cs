using Microsoft.AspNetCore.Http;

namespace HttpProxy.Core;

public class PrefixReWriter : IUrlReWriter
{
    private readonly PathString _prefix; //前缀值
    private readonly string _newHost; //转发的地址

    public PrefixReWriter(PathString prefix, string newHost)
    {
        _prefix = prefix;
        _newHost = newHost;
    }

    public Task<Uri> RewriteUri(HttpContext context)
    {
        if (context.Request.Path.StartsWithSegments(_prefix)) //判断访问是否含有前缀
        {
            var newUri = context.Request.Path.Value.Remove(0, _prefix.Value.Length) + context.Request.QueryString;
            var targetUri = new Uri(_newHost + newUri);
            return Task.FromResult(targetUri);
        }

        return Task.FromResult((Uri)null);
    }
}