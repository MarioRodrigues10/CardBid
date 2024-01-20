using Blazored.LocalStorage;
using CardBid.Data;
using CardBid.DataAcessLibrary;
using Microsoft.EntityFrameworkCore;

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

            services.AddHostedService<LeiloesBackgroundService>();
            services.AddTransient<IUtilizadoresData, UtilizadoresService>();
            services.AddTransient<IContaData, ContaService>();
            services.AddTransient<ILeiloesData, LeiloesService>();
            services.AddTransient<ICategoriaData, CategoriaService>();
            services.AddTransient<IGrauDegradacaoData, GrauDegradacaoService>();
            services.AddTransient<ILicitacoesData, LicitacoesService>();
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
