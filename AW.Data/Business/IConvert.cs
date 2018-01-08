using System.Collections.Generic;
using AW.Common.Models;
using AW.Data.DataService;

namespace AW.Data.Business
{
    public interface IConvert
    {
        Ad ToAd(AdDto adDto);
        Category ToCategory(CategoryDto categoryDto);
        List<Ad> ToAds(List<AdDto> adsDto);
        List<Category> ToCategories(List<CategoryDto> catDtos);
        AdDetails ToAdDetails(AdDetailsDto adDetailsDto);
        List<Condition> ToConditions(List<ConditionDto> conditionDto);
        List<Location> ToLocations(List<LocationDto> locationDto);
        List<AdType> ToTypes(List<TypeDto> types);

        AdDto ToAdDto(Ad ad);

        User ToUser(UserDto userDto);
        List<User> ToUsers(List<UserDto> usersDtos);
        List<Phone> ToPhones(List<PhoneDto> phoneDto);
        List<Email> ToEmails(List<EmailDto> emailDto);
        List<Role> ToRoles(List<RoleDto> roleDto);

        UserDto ToUserDto(User user);
        PhoneDto ToPhoneDto(Phone phone);
        EmailDto ToEmailDto(Email email);
    }
}