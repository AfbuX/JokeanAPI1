
using JokeanAPI1Repository.Implements;
using JokeanAPI1Repository.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace JokeanAPI1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDbConnection>(options =>
            {
                var connect = builder.Configuration.GetConnectionString("SqlConnecion");
                var con = new SqlConnection(connect);
                return con;
            });
            builder.Services.AddTransient<IUsuarioQueries, UsuarioQueries>();
            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<IServicioQueries, ServicioQueries>();
            builder.Services.AddTransient<IServicioRepository, ServicioRepository>();
            builder.Services.AddTransient<ICalificacionQueries, CalificacionQueries>();
            builder.Services.AddTransient<ICalificacionRepository, CalificacionRepository>();
            builder.Services.AddTransient<ISolicitudServicioQueries, SolicitudServicioQueries>();
            builder.Services.AddTransient<ISolicitudServicioRepository, SolicitudServicioRepository>();
            builder.Services.AddTransient<IExtraSolicitudQueries, ExtraSolicitudQueries>();
            builder.Services.AddTransient<IExtraSolicitudRepository, ExtraSolicitudRepository>();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
