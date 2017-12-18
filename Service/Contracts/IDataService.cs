using System.Collections.Generic;
using System.ServiceModel;
using Service.Dto;

namespace Service.Contracts
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        void CreateAdDto(AdDto adDto);

        [OperationContract]
        void EditeAdDto(AdDto adDto);

        [OperationContract]
        void DeleteAdDto(int adId);

        [OperationContract]
        List<AdDto> GetAdsDto();

        [OperationContract]
        List<AdDto> GetAdsByCategoryDto(int categoryId);

        [OperationContract]
        AdDetailsDto GetAdDetailsDto(int adId);

        [OperationContract]
        List<CategoryDto> GetCategoriesDto();

        [OperationContract]
        UserDto GetUserDtoByName(string userName);

        [OperationContract]
        bool IsValidUser(string userName, string password);

        [OperationContract]
        List<ConditionDto> GetConditionsDto();

        [OperationContract]
        List<EmailDto> GetEmailsDto();

        [OperationContract]
        List<LocationDto> GetLocationsDto();

        [OperationContract]
        List<PhoneDto> GetPhonesDto();

        [OperationContract]
        List<RoleDto> GetRolesDto();

        [OperationContract]
        List<TypeDto> GetTypesDto();

        [OperationContract]
        List<UserDto> GetUsersDto();
    }
}