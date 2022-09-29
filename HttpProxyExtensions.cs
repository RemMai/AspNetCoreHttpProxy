using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HttpProxy
{
    public static class HttpProxyExtensions
    {
        public static IServiceCollection AddHttpProxy(this IServiceCollection service)
        {
            service.AddHttpClient<ProxyHttpClient>()
                .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler()
                {
                    AllowAutoRedirect = false,
                    MaxConnectionsPerServer = int.MaxValue,
                    UseCookies = false,
                });

            var configuration = service.BuildServiceProvider(false).GetService<IConfiguration>()!;

            var prefix = configuration["proxy:prefix"];
            var newHost = configuration["proxy:newHost"];
            if (string.IsNullOrEmpty(prefix))
            {
                throw new Exception("请在appsetting.json中配置proxy.prefix");
            }

            if (string.IsNullOrEmpty(newHost))
            {
                throw new Exception("请在appsetting.json中配置proxy.newHost");
            }

            Console.WriteLine($"代理信息： {prefix} -> {newHost}");
            service.AddSingleton<IUrlReWriter>(new PrefixReWriter(prefix, newHost));

            return service;
        }


        public static void UseHttpProxy(this IApplicationBuilder app)
        {
            app.UseMiddleware<ProxyMiddleware>();
        }

    }

}
