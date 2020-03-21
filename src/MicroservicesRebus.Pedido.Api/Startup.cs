using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MicroservicesRebus.Pedido.Api.Data;
using Rebus.ServiceProvider;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using MicroservicesRebus.Pedido.Api.Events;
using Rebus.Serialization.Json;
using MicroservicesRebus.Core;
using MicroservicesRebus.Core.Events;

namespace MicroservicesRebus.Pedido.Api
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
            services.AddControllers();

            services.AddDbContext<PedidoContext>(o => o.UseMySql(Configuration.GetConnectionString("PedidoConnection")));
            services.AddScoped<IPedidoRepository, PedidoRepository>();

             var fila = "fila_pedido";

            services.AddRebus(c => c
                .Transport(t => t.UseRabbitMq(Configuration.GetConnectionString("RabbitConnection"), fila)) //Configura o RabbitMQ
            );

             services.AutoRegisterHandlersFromAssemblyOf<PedidoEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ApplicationServices.UseRebus(c =>
            {
                c.Subscribe<EstoqueFinalizadoEvent>().Wait();
                c.Subscribe<EstoqueInconsistenteEvent>().Wait();
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
