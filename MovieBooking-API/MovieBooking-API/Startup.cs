using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MovieBooking_API.Errors;
using MovieBooking_API.Helper;
using MovieBooking_API.Middleware;
using MovieBooking_DomainModels;
using MovieBooking_Repository;
using System.Linq;

namespace MovieBooking_API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieBooking_API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(optionAction => optionAction.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(MapperProfiles));
            services.AddCors(setupAction => setupAction.AddPolicy("CorsPolicy", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = optionAction =>
                {
                    var errors = optionAction.ModelState.Where(e => e.Value.Errors.Count > 0).SelectMany(s => s.Value.Errors).Select(s => s.ErrorMessage);
                    var errorResponse = new ApiValidationResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errors);
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieBooking_API v1"));
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}