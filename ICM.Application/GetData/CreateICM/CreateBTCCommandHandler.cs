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
    public class CreateBTCCommandHandler : IRequestHandler<CreateBTCRequest, int>
    {
        private readonly ICMDbContext _cMDbContext;
        private readonly IMapper _mapper;

        public CreateBTCCommandHandler(ICMDbContext cMDbContext, IMapper mapper)
        {
            _cMDbContext = cMDbContext;
            _mapper = mapper;

        }

        public async Task<int> Handle(CreateBTCRequest request, CancellationToken cancellationToken)
        {
            var newBTC = _mapper.Map<ICM.Domain.Entities.BTC>(request);
            _cMDbContext.BTCs.Add(newBTC);
            await _cMDbContext.SaveToDbAsync();
            return newBTC.Id;
        }
    }
}
