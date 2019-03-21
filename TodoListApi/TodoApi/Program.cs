using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TodoApi
{
    //TODO:1.创建 Web 项目 
    /* 注：
     * Visual Studio 2017 version 15.9 or later with the ASP.NET and web development workload
     * .NET Core SDK 2.2 or later
     * 
     * https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio
     * 
     * 1.从“文件”菜单中选择“新建” > “项目”
     * 选择“ASP.NET Core Web 应用程序”模板
     * 将项目命名为 TodoApi，然后单击“确定”
     * 2.在“新建 ASP.NET Core Web 应用程序 - TodoApi”对话框中，选择 ASP.NET Core 版本
     * 3.选择“API”模板，然后单击“确定”。 请不要选择“启用 Docker 支持”。
     * 
     * 4.如果出现询问是否应信任 IIS Express 证书的对话框，则选择“是”。 在接下来出现的“安全警告”对话框中，选择“是”。
    */
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
