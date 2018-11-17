﻿using Google.Dialogflow.TestWebHook.Helper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using uFood.Infrastructure.Configuration;
using uFood.ServiceLayer.LichtBild;
using uFood.ServiceLayer.MongoDB;

namespace uFood.API
{
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
			services.Configure<LichtBildConfiguration>(Configuration.GetSection("LichBild"));
            services.Configure<MongoDBConfiguration>(Configuration.GetSection("MongoDB"));

            services.AddSingleton<LichtBildConnector>();
			services.AddSingleton<MongoDBConnector>();
            services.AddSingleton<GoogleJsonHelper>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}