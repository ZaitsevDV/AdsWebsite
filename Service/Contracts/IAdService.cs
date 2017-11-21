using System.ServiceModel;
using Service.DTO;

namespace Service.Contracts
{
    [ServiceContract]
    public interface IAdService
    {
        [OperationContract]
        AdDto GetAdDto();
    }
}