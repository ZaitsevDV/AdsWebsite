using System.Collections.Generic;
using System.ServiceModel;
using Service.Dto;

namespace Service.Contracts
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        List<AdDto> GetAdsDto();

        [OperationContract]
        AdDto GetAdDetailsDto(int id);

        [OperationContract]
        List<CategoryDto> GetCategoriesDto();

        [OperationContract]
        List<UserDto> GetUsersDto();

        [OperationContract]
        UserDto GetUserDtoByName(string userName);

    }
}