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
        List<AdDto> GetAdsByCategoryDto(int categoryId);

        [OperationContract]
        AdDto GetAdDetailsDto(int adId);

        [OperationContract]
        List<CategoryDto> GetCategoriesDto();

        [OperationContract]
        List<UserDto> GetUsersDto();

        [OperationContract]
        UserDto GetUserDtoByName(string userName);

        [OperationContract]
        bool IsValidUser(string userName, string password);
    }
}