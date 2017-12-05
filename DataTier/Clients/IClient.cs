using DataTier.AdService;
using System.Collections.Generic;

namespace DataTier.Clients
{
    public interface IClient
    {
        List<AdDto> GetAdsDto();

        AdDto GetAdDetailsDto(int id);

        List<CategoryDto> GetCategoriesDto();

        List<UserDto> GetUsersDto();

        UserDto GetUserDtoByName(string userName);
    }
}
