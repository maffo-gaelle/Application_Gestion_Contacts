using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SC = Model.Client.Services;
using SI = Model.Client.Repositories;
using SCG = Model.Global.Services;
using SIG = Model.Global.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools;
using WepAppEmpty.Models.Sessions;

namespace WepAppEmpty
{
    public class Startup
    {
        private string connectionString = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //On crée la connexion que nous allons injecter dans notre projet
            //sp = Service provider
            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, connectionString));
            services.AddSingleton<SI.IContactRepository, SC.ContactService>();
            services.AddSingleton<SI.ICategoryRepository, SC.CategoryService>();
            services.AddSingleton<SI.IAuthRepository, SC.UserService>();
            services.AddSingleton<SIG.IContactRepository, SCG.ContactService>();
            services.AddSingleton<SIG.ICategoryRepository, SCG.CategoryService>();
            services.AddSingleton<SIG.IAuthRepository, SCG.UserService>();


            //----- Activation des services pour l'utilisation des sessions
            //Permet d'utiliser la mémoire de l'ordinateur
            services.AddDistributedMemoryCache();
            //On ajoute ici les services de sessions à l'occurence le timeout
            services.AddSession(options =>
            {
                //options.Cookie.Name = ".GestContact.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            //Va nous permettre d'inhecter dans nos classe un http lié à notre context
            services.AddHttpContextAccessor();
            //La classe manageraccessor va recevoir un httpcontextAccessor...

            //Chaque fois qu'on fait appel au getServi, pour le singleton on recupère toujours la m^me instance
            //pour le transiant, chaque fois que on fais appel au get, il va nous renvoyer une nouvelle instance
            //Pour le scope, à chaque appel du get service, on recupère la même instance tant que on est dans le même scope
            //
            services.AddScoped<ISessionManager, SessionManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                connectionString = Configuration.GetConnectionString("FullApp");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //active le module de session : L'application utilise des sessions
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
