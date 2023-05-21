using ICM.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.Context
{
    public interface ICMDbContext
    {

        DbSet<Dash> Dashes { get; }
        DbSet<ETH> ETHs { get; }
        DbSet<BTC> BTCs { get; }
        Task<int> SaveToDbAsync();

    }
}
