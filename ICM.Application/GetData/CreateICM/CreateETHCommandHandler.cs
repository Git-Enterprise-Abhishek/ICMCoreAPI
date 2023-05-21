using AutoMapper;
using ICM.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.GetData.CreateICM
{
    public class CreateETHCommandHandler : IRequestHandler<CreateETHRequest, int>
    {
        private readonly ICMDbContext _cMDbContext;
        private readonly IMapper _mapper;

        public CreateETHCommandHandler(ICMDbContext cMDbContext, IMapper mapper) 
        {
            _cMDbContext = cMDbContext;
            _mapper = mapper;

        }

        public async Task<int> Handle(CreateETHRequest request, CancellationToken cancellationToken)
        {
            var newETH = _mapper.Map<ICM.Domain.Entities.ETH>(request);
            _cMDbContext.ETHs.Add(newETH);
            await _cMDbContext.SaveToDbAsync();
            return newETH.Id;
        }
    }
}
