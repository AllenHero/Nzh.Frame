﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Nzh.Frame.IRepository;
using Nzh.Frame.IService;
using Nzh.Frame.Repository;
using Nzh.Frame.Repository.EF;
using Nzh.Frame.Service;
using Nzh.Frame.Service.MapperConfig;
using STD.NetCore.SwaggerHelp;
using Swashbuckle.AspNetCore.Swagger;

namespace Nzh.Frame
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc();

            services.AddDbContext<EFDbContext>(option =>
                 option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfiguration());
            });
            config.CreateMapper();

            //注入服务、仓储类
            services.AddTransient<IDemoRepository, DemoRepository>();
            services.AddTransient<IDemoService, DemoService>();
            services.AddAutoMapper();
            services.AddMvc();

            #region  Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1.1.0",
                    Title = "Nzh.Frame WebAPI",
                    Description = ".NetCore WebAPI框架",
                    TermsOfService = "None",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Nzh.Frame", Email = "", Url = "" }
                });
                //添加注释服务
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "Nzh.Frame.xml");
                var modelPath = Path.Combine(basePath, "Nzh.Frame.Common.xml");
                var comonPath = Path.Combine(basePath, "Nzh.Frame.Model.xml");
                c.IgnoreObsoleteActions();
                c.DocInclusionPredicate((docName, description) => true);
                c.DescribeAllEnumsAsStrings();
                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(modelPath);
                c.IncludeXmlComments(comonPath);
                //添加对控制器的标签(描述)
                c.DocumentFilter<SwaggerDocTag>();
               // c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });

            #endregion

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });

            #endregion
        }
    }
}
