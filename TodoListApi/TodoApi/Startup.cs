using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TodoApi.Models;

namespace TodoApi
{
    //使用 ASP.NET Core MVC 创建 Web API
    /*
     * API                   说明                请求正文    响应正文
     * GET /api/todo         获取所有待办事项     无          待办事项的数组
     * GET /api/todo/{id}    按 ID 获取项        无          待办事项
     * POST /api/todo        添加新项            待办事项     待办事项
     * PUT /api/todo/{id}	 更新现有项          待办事项     无
     * DELETE /api/todo/{id} 删除项              无          无
     */
    //Razor 是一种将服务器代码嵌入在网页中的简单的编程语法。
    //Razor 页面是 ASP.NET Core MVC 的一个新特性，它可以使基于页面的编码方式更简单高效。
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO:4.注册数据库上下文
            //在 ASP.NET Core 中，服务（如数据库上下文）必须向依赖关系注入 (DI) 容器进行注册。 该容器向控制器提供服务。
            services.AddDbContext<TodoContext>(opt=>opt.UseInMemoryDatabase("TodoList"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        //TODO:6.使用 jQuery 调用 API
        //添加了使用 jQuery 调用 Web API 的 HTML 页面。 jQuery 启动请求，并用 API 响应中的详细信息更新页面。
        //jQuery 是一个JavaScript函数库
        /*
         * HTML 元素选取
         * HTML 元素操作
         * CSS 操作
         * HTML 事件函数
         * JavaScript 特效和动画
         * HTML DOM 遍历和修改
         * AJAX
         * Utilities
         */
        /*
         * 1.配置应用提供静态文件并启用默认文件映射
         * 2.在项目目录中创建 wwwroot 文件夹,将一个名为 index.html 的 HTML 文件添加到 wwwroot 目录
         * 3.将名为 site.js 的 JavaScript 文件添加到 wwwroot 目录
         * 4.可能需要更改 ASP.NET Core 项目的启动设置，以便对 HTML 页面进行本地测试：
            打开 Properties\launchSettings.json。
            删除 launchUrl 以便在项目的默认文件 index.html 强制打开应用。
         */
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //配置应用提供静态文件并启用默认文件映射
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
