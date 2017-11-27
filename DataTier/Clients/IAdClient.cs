using System.Collections.Generic;
using DataTier.AdService;

namespace DataTier.Clients
{
    public interface IAdClient
    {
        List<AdDto> GetAdsDto();

        AdDto GetAdDetailsDto(int id);

        List<CategoryDto> GetCategoriesDto();

        List<UserDto> GetUsersDto();
    }
}
