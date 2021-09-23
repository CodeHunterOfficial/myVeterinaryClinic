using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VeterinaryClinic.Models;
using VeterinaryClinic.Repository;
using VeterinaryClinic.Services;
using Microsoft.Extensions.Configuration;
using myVeterinaryClinic.Repository;
using myVeterinaryClinic.Services;

namespace VeterinaryClinic
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var con = Configuration.GetConnectionString("SQLAuth");
            services.AddDbContext<VeterinaryClinicContext>(options => options.UseSqlServer(con));

            services.AddControllers(); // используем контроллеры без представлений

            services.AddAutoMapper(typeof(ApiMappings.ApiMappings));

            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();

            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();

            services.AddScoped<IDocServRepository, DocServRepository>();
            services.AddScoped<IDocServService, DocServService>();

            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IVaccinationService, VaccinationService>();
            services.AddScoped<IVaccinationRepository, VaccinationRepository>();
            services.AddSwaggerGen();
            services.AddSwaggerGen();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseDefaultFiles();
            // app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}