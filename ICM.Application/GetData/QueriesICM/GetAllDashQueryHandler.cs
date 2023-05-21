using AutoMapper;
using AutoMapper.QueryableExtensions;
using ICM.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.GetData.QueriesICM
{
    public class GetAllDashQueryHandler : IRequestHandler<GetAllDashRequest, List<GetAllDashResponse>>
    {
        private readonly ICMDbContext _cmdbContext;
        private readonly IMapper _mapper;

        public GetAllDashQueryHandler(ICMDbContext cMDbContext, IMapper mapper)
        {
            _cmdbContext = cMDbContext;
            _mapper = mapper;
        }


        public Task<List<GetAllDashResponse>> Handle(GetAllDashRequest request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            return _cmdbContext.Dashes.ProjectTo<GetAllDashResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }

      
    }

}
