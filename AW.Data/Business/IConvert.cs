using System.Collections.Generic;
using AW.Common.Models;
using AW.Data.DataService;

namespace AW.Data.Business
{
    public interface IConvert
    {
        Ad ToAd(AdDto adDto);
        AdDto ToAdDto(Ad ad);
        Category ToCategory(CategoryDto categoryDto);
        User ToUser(UserDto userDto);
        IEnumerable<Ad> ToAds(IEnumerable<AdDto> adsDto);
        List<Category> ToCategories(List<CategoryDto> catDtos);
        IEnumerable<User> ToUsers(IEnumerable<UserDto> usersDtos);
        AdDetails ToAdDetails(AdDetailsDto adDetailsDto);
        List<Condition> ToConditions(List<ConditionDto> conditionDto);
        List<Email> ToEmails(List<EmailDto> emailDto);
        List<Location> ToLocations(List<LocationDto> locationDto);
        List<Phone> ToPhones(List<PhoneDto> phoneDto);
        List<Role> ToRoles(List<RoleDto> roleDto);
        List<AdType> ToTypes(List<TypeDto> types);
    }
}