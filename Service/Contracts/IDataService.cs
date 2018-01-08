using Service.Dto;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service.Contracts
{
    [ServiceContract]
    public interface IDataService
    {
        #region Ads

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
        List<ConditionDto> GetConditionsDto();

        [OperationContract]
        List<TypeDto> GetTypesDto();

        [OperationContract]
        List<LocationDto> GetLocationsDto();
        #endregion

        #region Users

        [OperationContract]
        void CreateUserDto(UserDto userDto);

        [OperationContract]
        void EditeUserDto(UserDto userDto);

        [OperationContract]
        void EditePasswordDto(string userName, string password);

        [OperationContract]
        void DeleteUserDto(string userName);

        [OperationContract]
        List<UserDto> GetUsersDto();

        [OperationContract]
        UserDto GetUserDtoByName(string userName);

        [OperationContract]
        bool IsValidUser(string userName, string password);

        [OperationContract]
        List<RoleDto> GetRolesDto();

        [OperationContract]
        List<PhoneDto> GetPhonesDto(string userName);

        [OperationContract]
        void CreatePhoneDto(PhoneDto phoneDto);

        [OperationContract]
        void EditePhoneDto(PhoneDto phoneDto);

        [OperationContract]
        void DeletePhoneDto(int phoneId);

        [OperationContract]
        List<EmailDto> GetEmailsDto(string userName);

        [OperationContract]
        void CreateEmailDto(EmailDto emailDto);

        [OperationContract]
        void EditeEmailDto(EmailDto emailDto);

        [OperationContract]
        void DeleteEmailDto(int emailId);

        #endregion
    }
}