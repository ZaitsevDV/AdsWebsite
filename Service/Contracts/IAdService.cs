using System.ServiceModel;
using Service.Dto;

namespace Service.Contracts
{
    [ServiceContract]
    public interface IAdService
    {
        [OperationContract]
        AdDto GetAdDto(int id);
    }
}