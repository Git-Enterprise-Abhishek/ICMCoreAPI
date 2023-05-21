using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.GetData.QueriesICM
{
    public class GetAllDashMapper:Profile
    {
        public GetAllDashMapper()
        {
            CreateMap<ICM.Domain.Entities.Dash, GetAllDashResponse>();
            CreateMap<ICM.Domain.Entities.ETH,GetAllETHResponse>();
            CreateMap<ICM.Domain.Entities.BTC, GetAllBTCResponse>();
        }
    }
}
