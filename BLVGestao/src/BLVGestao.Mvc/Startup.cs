using BLVGestao.Data.Interfaces;
using BLVGestao.Data.ORM;
using BLVGestao.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BLVGestao.Mvc
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
            services.AddCors();
            services.AddDbContext<Context>(options => options.UseMySql(Configuration.GetConnectionString("ContextDiogo")));
            services.AddAuthentication("CookieAuthentication").AddCookie("CookieAuthentication", config => { config.Cookie.Name = "UserLoginCookie";
                config.LoginPath = "/Login/UserLogin";config.AccessDeniedPath = "/Usuarios/AcessoNegado"; });
            services.AddMemoryCache();
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IPessoaRepositorio, PessoaRepositorio>();
            services.AddScoped<ITelefoneRepositorio, TelefoneRepositorio>();
            services.AddScoped<IEnderecoRepositorio, EnderecoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IGrupoAcessoRepositorio, GrupoAcessoRepositorio>();
            services.AddScoped<IFormaDePagamentoRepositorio, FormaDePagamentoRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IVendaRepositorio, VendaRepositorio>();
         
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //pattern: "{controller=Usuarios}/{action=LogarUsuario}/{id?}");
                pattern: "{controller=Vendas}/{action=Create}/{id?}");
        });
        }
    }
}
