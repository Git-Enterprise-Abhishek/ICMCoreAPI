using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.GetData.CreateICM
{
    public class CreateDashMapper:Profile
    {
        public CreateDashMapper()
        {
            CreateMap<CreateDashRequest, ICM.Domain.Entities.Dash>();
            CreateMap<CreateETHRequest, ICM.Domain.Entities.ETH>();
            CreateMap<CreateBTCRequest, ICM.Domain.Entities.BTC>(); 
        }
    }
}
