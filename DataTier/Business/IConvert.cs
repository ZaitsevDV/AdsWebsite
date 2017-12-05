using Common.Models;
using DataTier.AdService;
using System.Collections.Generic;

namespace DataTier.Business
{
    public interface IConvert
    {
        Ad ToAd(AdDto adDto);
        Category ToCategory(CategoryDto categoryDto);
        User ToUser(UserDto userDto);
        IEnumerable<Ad> ToAds(IEnumerable<AdDto> adsDto);
        List<Category> ToCategories(List<CategoryDto> catDtos);
        IEnumerable<User> ToUsers(IEnumerable<UserDto> usersDtos);
    }
}
