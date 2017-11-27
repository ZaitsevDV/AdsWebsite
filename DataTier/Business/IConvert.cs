using System.Collections.Generic;
using Common.Models;
using DataTier.AdService;

namespace DataTier.Business
{
    public interface IConvert
    {
        Ad ToAd(AdDto adDto);
        Category ToCategory(CategoryDto categoryDto);
        User ToUser(UserDto userDto);
        IEnumerable<Ad> ToAds(IEnumerable<AdDto> adsDto);
        IEnumerable<Category> ToCategories(IEnumerable<CategoryDto> catDtos);
        IEnumerable<User> ToUsers(IEnumerable<UserDto> usersDtos);
    }
}
