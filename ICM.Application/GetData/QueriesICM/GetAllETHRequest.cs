using MediatR;

namespace ICM.Application.GetData.QueriesICM
{
    public class GetAllETHRequest : IRequest<List<GetAllETHResponse>>
    {
    }
}