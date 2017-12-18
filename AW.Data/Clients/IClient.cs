using System.Collections.Generic;
using AW.Data.DataService;

namespace AW.Data.Clients
{
    public interface IClient
    {
        void CreateAdDto(AdDto adDto);

        void EditeAdDto(AdDto adDto);

        void DeleteAdDto(int adId);
        
        List<AdDto> GetAdsDto();

        List<AdDto> GetAdsByCategoryDto(int categoryId);

        AdDetailsDto GetAdDetailsDto(int id);

        List<CategoryDto> GetCategoriesDto();

        List<UserDto> GetUsersDto();

        UserDto GetUserDtoByName(string userName);

        bool IsValidUser(string userName, string password);

        List<ConditionDto> GetConditionsDto();

        List<EmailDto> GetEmailsDto();

        List<LocationDto> GetLocationsDto();

        List<PhoneDto> GetPhonesDto();

        List<RoleDto> GetRolesDto();

        List<TypeDto> GetTypesDto();

    }
}