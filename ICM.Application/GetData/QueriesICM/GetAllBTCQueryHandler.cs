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
    public class GetAllBTCQueryHandler : IRequestHandler<GetAllBTCRequest, List<GetAllBTCResponse>>
    {
        private readonly ICMDbContext _cmdbContext;
        private readonly IMapper _mapper;

        public GetAllBTCQueryHandler(ICMDbContext cMDbContext, IMapper mapper)
        {
            _cmdbContext = cMDbContext;
            _mapper = mapper;

        }

        public Task<List<GetAllBTCResponse>> Handle(GetAllBTCRequest request, CancellationToken cancellationToken)
        {
            return _cmdbContext.BTCs.ProjectTo<GetAllBTCResponse>(_mapper.ConfigurationProvider).ToListAsync();

        }
    }
}
