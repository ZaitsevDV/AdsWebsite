using System.Collections.Generic;
using AW.Data.DataService;

namespace AW.Data.Clients
{
    public interface IClient
    {
        //Ads
        void CreateAdDto(AdDto adDto);
        void EditeAdDto(AdDto adDto);
        void DeleteAdDto(int adId);
        List<AdDto> GetAdsDto();
        List<AdDto> GetAdsByCategoryDto(int categoryId);
        AdDetailsDto GetAdDetailsDto(int id);
        List<CategoryDto> GetCategoriesDto();
        List<LocationDto> GetLocationsDto();
        List<TypeDto> GetTypesDto();
        List<ConditionDto> GetConditionsDto();

        //Users
        void CreateUserDto(UserDto userDto);
        void EditeUserDto(UserDto userDto);
        void EditePasswordDto(string userName, string password);
        void DeleteUserDto(string userName);
        List<UserDto> GetUsersDto();
        UserDto GetUserDtoByName(string userName);
        bool IsValidUser(string userName, string password);
        List<RoleDto> GetRolesDto();
        List<PhoneDto> GetPhonesDto(string userName);
        void CreatePhoneDto(PhoneDto phoneDto);
        void EditePhoneDto(PhoneDto phoneDto);
        void DeletePhoneDto(int phoneId);
        List<EmailDto> GetEmailsDto(string userName);
        void CreateEmailDto(EmailDto emailDto);
        void EditeEmailDto(EmailDto emailDto);
        void DeleteEmailDto(int emailId);
    }
}