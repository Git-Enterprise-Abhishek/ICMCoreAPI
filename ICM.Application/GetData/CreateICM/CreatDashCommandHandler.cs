using AutoMapper;
using ICM.Application.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICM.Application.GetData.CreateICM
{
    public class CreatDashCommandHandler : IRequestHandler<CreateDashRequest, int>
    {
        private readonly ICMDbContext _cMDbContext;
        private readonly IMapper _mapper;

        public CreatDashCommandHandler(ICMDbContext cMDbContext, IMapper mapper)
        {
            _cMDbContext = cMDbContext;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateDashRequest request, CancellationToken cancellationToken)
        {
            var newDash = _mapper.Map<ICM.Domain.Entities.Dash>(request);
            _cMDbContext.Dashes.Add(newDash);
            await _cMDbContext.SaveToDbAsync();
            return newDash.Id;
        }
    }
}
