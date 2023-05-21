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
    public class GetAllETHQueryHandler: IRequestHandler<GetAllETHRequest, List<GetAllETHResponse>>
    {
        private readonly ICMDbContext _cmdbContext;
        private readonly IMapper _mapper;

        public GetAllETHQueryHandler(ICMDbContext cMDbContext, IMapper mapper) 
        {
            _cmdbContext = cMDbContext;
            _mapper = mapper;

        }

        public Task<List<GetAllETHResponse>> Handle(GetAllETHRequest request, CancellationToken cancellationToken)
        {
            return _cmdbContext.ETHs.ProjectTo<GetAllETHResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
