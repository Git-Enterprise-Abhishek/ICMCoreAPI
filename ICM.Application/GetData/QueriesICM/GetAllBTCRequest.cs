using MediatR;

namespace ICM.Application.GetData.QueriesICM
{
    public class GetAllBTCRequest :IRequest<List<GetAllBTCResponse>>
    {
    }
}