using AW.Common.Models;
using AW.Data.DataService;
using System.Collections.Generic;
using System.Linq;

namespace AW.Data.Business
{
    public class Convert : IConvert
    {
        public Ad ToAd(AdDto adDto)
        {
            return new Ad
            {
                Id = adDto.Id,
                UserName = adDto.UserName,
                Title = adDto.Title,
                Description = adDto.Description,
                Picture = adDto.Picture,
                Price = adDto.Price,
                Category = adDto.CategoryId,
                CreationDate = adDto.CreationDate,
                LocationId = adDto.LocationId,
                TypeId = adDto.TypeId,
                Condition = adDto.ConditionId
            };
        }

        public AdDto ToAdDto(Ad ad)
        {
            return new AdDto
            {
                Id = ad.Id,
                UserName = ad.UserName,
                Title = ad.Title,
                Description = ad.Description,
                Picture = ad.Picture,
                Price = ad.Price,
                CategoryId = ad.Category,
                CreationDate = ad.CreationDate,
                LocationId = ad.LocationId,
                TypeId = ad.TypeId,
                ConditionId = ad.Condition
            };
        }

        public AdDetails ToAdDetails(AdDetailsDto adDetailsDto)
        {
            return new AdDetails
            {
                Id = adDetailsDto.Id,
                UserName = adDetailsDto.UserName,
                Title = adDetailsDto.Title,
                Description = adDetailsDto.Description,
                Picture = adDetailsDto.Picture,
                Price = adDetailsDto.Price,
                CategoryName = adDetailsDto.CategoryName,
                CreationDate = adDetailsDto.CreationDate,
                LocationName = adDetailsDto.LocationName,
                TypeName = adDetailsDto.TypeName,
                ConditionName = adDetailsDto.ConditionName
            };
        }

        public List<Condition> ToConditions(List<ConditionDto> conditionDto)
        {
            return conditionDto.Select(item => new Condition()
                {
                    ConditionId = item.ConditionId,
                    ConditionName = item.ConditionName
                })
                .ToList();
        }

        public List<Email> ToEmails(List<EmailDto> emailDto)
        {
            return emailDto.Select(item => new Email()
                {
                    EmailId = item.EmailId,
                    UserName = item.UserName,
                    EmailValue = item.EmailValue
                })
                .ToList();
        }

        public List<Location> ToLocations(List<LocationDto> locationDto)
        {
            return locationDto.Select(item => new Location()
                {
                    LocationId = item.LocationId,
                    LocationName = item.LocationName
                })
                .ToList();
        }

        public List<Phone> ToPhones(List<PhoneDto> phoneDto)
        {
            return phoneDto.Select(item => new Phone()
                {
                    PhoneId = item.PhoneId,
                    UserName = item.UserName,
                    PhoneNumber = item.PhoneNumber
            })
                .ToList();
        }

        public List<Role> ToRoles(List<RoleDto> roleDto)
        {
            return roleDto.Select(item => new Role()
                {
                    RoleId = item.RoleId,
                    RoleName = item.RoleName
                })
                .ToList();
        }

        public List<AdType> ToTypes(List<TypeDto> typeDto)
        {
            return typeDto.Select(item => new AdType()
                {
                    TypeId = item.TypeId,
                    TypeName = item.TypeName
                })
                .ToList();
        }

        public Category ToCategory(CategoryDto categoryDto)
        {
            return new Category
            {
                CategoryId = categoryDto.CategoryId,
                CategoryName = categoryDto.CategoryName,
                ParentCategoryId = categoryDto.ParentCategoryId
            };
        }

        public User ToUser(UserDto userDto)
        {
            return new User
            {
                UserName = userDto.UserName,
                Roles = new[] {new Role {RoleName = userDto.RoleName}}
            };
        }

        public List<Category> ToCategories(List<CategoryDto> categoriesDto)
        {
            return categoriesDto.Select(ToCategory).ToList();
        }

        public IEnumerable<Ad> ToAds(IEnumerable<AdDto> adsDto)
        {
            return adsDto.Select(ToAd).ToList();
        }

        public IEnumerable<User> ToUsers(IEnumerable<UserDto> usersDto)
        {
            return usersDto.Select(ToUser).ToList();
        }

    }
}