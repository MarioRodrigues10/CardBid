using CardBid.Data;
using Microsoft.EntityFrameworkCore;
using CardBid.DataAcessLibrary;
using Blazored.LocalStorage;

namespace CardBid
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredLocalStorage();

            // Configure the DbContext
            services.AddDbContext<CardBidDbContext>(options =>
            {
                options.UseSqlServer("Server=localhost,1436;Database=cardbid;User Id=sa;Password=Password123;TrustServerCertificate=True");
            });

            services.AddTransient<IUtilizadoresData, UtilizadoresService>();
            services.AddTransient<IContaData, ContaService>();
            services.AddTransient<ILeiloesData, LeiloesService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }   
    }
}
