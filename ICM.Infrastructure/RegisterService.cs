using ICM.Application.Context;
using ICM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Infrastructure
{
    public static class RegisterService
    {
        public static void ConfigureInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CMDbContext>(options =>
            {
                options.UseInMemoryDatabase(databaseName: configuration.GetConnectionString("ICMDBName"));

            });
            services.AddScoped<ICMDbContext>(option => {
                return option.GetService<CMDbContext>();
            });

        }


    }
}
