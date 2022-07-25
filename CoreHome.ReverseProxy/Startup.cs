using Microsoft.AspNetCore.DataProtection;
using System.Runtime.InteropServices;

namespace CoreHome.ReverseProxy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // 配置服务
        public void ConfigureServices(IServiceCollection services)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDataProtection().SetApplicationName("CoreHome")
                    .PersistKeysToFileSystem(new DirectoryInfo(@"C:/Server/CoreHome/"));
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                services.AddDataProtection().SetApplicationName("CoreHome")
                    .PersistKeysToFileSystem(new DirectoryInfo(@"/home/Server/CoreHome/"));
            }

            services.AddReverseProxy().LoadFromConfig(Configuration.GetSection("ReverseProxy"));
        }

        // 配置HTTP请求管道
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapReverseProxy();
            });
        }
    }
}
