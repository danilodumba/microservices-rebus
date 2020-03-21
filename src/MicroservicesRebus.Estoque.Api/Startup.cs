using MicroservicesRebus.Core;
using MicroservicesRebus.Estoque.Api.Data;
using MicroservicesRebus.Estoque.Api.Data.Repository;
using MicroservicesRebus.Estoque.Api.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rebus.Config;
using Rebus.Persistence.InMem;
using Rebus.Routing.TypeBased;
using Rebus.Serialization.Json;
using Rebus.ServiceProvider;

namespace MicroservicesRebus.Estoque.Api
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
            var conectionString = Configuration.GetConnectionString("EstoqueConnection");
            
            services.AddDbContext<EstoqueContext>(options =>
                    options.UseMySql(conectionString));


            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddControllers();

            var fila = "fila_pedido";

            services.AddRebus(c => c
                .Transport(t => t.UseRabbitMq(Configuration.GetConnectionString("RabbitConnection"), fila)) //Configura o RabbitMQ
            );

            services.AutoRegisterHandlersFromAssemblyOf<RemoverEstoqueEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.ApplicationServices.UseRebus();

            app.ApplicationServices.UseRebus(c =>
            {
                c.Subscribe<RemoverEstoqueEvent>().Wait();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
