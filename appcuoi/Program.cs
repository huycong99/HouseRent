using appcuoi.Bussiness.IServices;
using appcuoi.Bussiness.Services;
using appcuoi.Data.Context;
using appcuoi.Data.IRepositories;
using appcuoi.Data.Repositories;

using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace appcuoi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddTransient<AppDbContext>();
            builder.Services.AddTransient<IUserRepository,UserRepository>();
            builder.Services.AddTransient<IUserService,UserService>();
            builder.Services.AddTransient<ITokenservice,TokenService>();
            builder.Services.AddTransient<IAuthenservice,AuthenServicecs>();
            builder.Services.AddTransient<IHouseRepository,HouseRepository>();
            builder.Services.AddTransient<IHouseService,HouseService>();
            builder.Services.AddAutoMapper(typeof(Mappingcs).Assembly);
            //authorization Configguration
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(otps =>
            {
                otps.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("-UK-CoHp_Ow4VRjx41cQqzpNMDexj4vpBWiLjRUAScAWozenQMhLqGdFNLHtrMEidluJyf9u2dWEosztjMwNHJiBx4wMmQL9ovP9tILEvQTG435R4-tFVRvXZg6_FOvdyDSi35ibA2ARJpQ5-2S4_oZQBV69VGT-oYOHY9XpOBM")),
                    ValidIssuer = "http://localhost:5000",
                    ValidAudience = "http://localhost:5000",
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer=true,
                    ValidateAudience=true
                    

                };
            });

            
           
            

            var app = builder.Build();
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default",
                                            pattern: "{controller=Home}/{action=Index}/{id?}");



            });

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}