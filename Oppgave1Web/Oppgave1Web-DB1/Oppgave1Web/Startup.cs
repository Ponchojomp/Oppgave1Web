using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oppgave1Web.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using KundeApp2.DAL;
using KundeApp2.Model;
using Microsoft.Extensions.Logging;

namespace Oppgave1Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<TransportDB>(options => options.UseSqlite("Data source=transport.db"));
            services.AddScoped<IKundeRepo, KundeRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerfactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerfactory.AddFile("Logs/Kundelog.txt");
                //DBInit.Initialize(app);
            }

            app.UseRouting();

            app.UseStaticFiles(); // merk denne!

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
