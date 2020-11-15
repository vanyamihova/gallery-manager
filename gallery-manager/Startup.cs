using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace gallery_manager
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Gallery/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Gallery}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "gallery",
                    defaults: new { controller = "Gallery", action = "Index" },
                    pattern: "gallery/{galleryId}");

                endpoints.MapControllerRoute(
                    name: "gallery-edit",
                    defaults: new { controller = "Gallery", action = "Edit" },
                    pattern: "gallery/{galleryId}/edit");

                endpoints.MapControllerRoute(
                    name: "gallery-delete",
                    defaults: new { controller = "Gallery", action = "Delete" },
                    pattern: "gallery/{galleryId}/delete");

                endpoints.MapControllerRoute(
                    name: "image-index",
                    defaults: new { controller = "Image", action = "Index" },
                    pattern: "gallery/{galleryId}/images");

                endpoints.MapControllerRoute(
                    name: "image-add",
                    defaults: new { controller = "Image", action = "Add" },
                    pattern: "gallery/{galleryId}/images/add");

                endpoints.MapControllerRoute(
                    name: "image-edit",
                    defaults: new { controller = "Image", action = "Edit" },
                    pattern: "gallery/{galleryId}/images/{imageId}/edit");

                endpoints.MapControllerRoute(
                    name: "image-delete",
                    defaults: new { controller = "Image", action = "Delete" },
                    pattern: "gallery/{galleryId}/images/{imageId}/delete");

            });
        }
    }
}
