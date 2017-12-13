using System.Collections.Generic;
using DataTier.DataService;

namespace DataTier.Clients
{
    public interface IClient
    {
        List<AdDto> GetAdsDto();

        List<AdDto> GetAdsByCategoryDto(int categoryId);

        AdDto GetAdDetailsDto(int id);

        List<CategoryDto> GetCategoriesDto();

        List<UserDto> GetUsersDto();

        UserDto GetUserDtoByName(string userName);

        bool IsValidUser(string userName, string password);
    }
}