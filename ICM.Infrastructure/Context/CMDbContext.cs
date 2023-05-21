using ICM.Application.Context;
using ICM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Infrastructure.Context
{
    public class CMDbContext : DbContext, ICMDbContext
    {
        public CMDbContext(DbContextOptions<CMDbContext> options) : base(options)
        {

        }

        public DbSet<Dash> Dashes { get; set; }
        public DbSet<ETH> ETHs { get; set; }
        public DbSet<BTC> BTCs { get; set; }


        public async Task<int> SaveToDbAsync()
        {
            return await SaveChangesAsync();
        }
    }
}
