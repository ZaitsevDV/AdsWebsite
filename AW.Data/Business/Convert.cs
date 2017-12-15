using System.Collections.Generic;
using System.Linq;
using AW.Common.Models;
using AW.Data.DataService;

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
                Name = adDto.Name,
                Description = adDto.Description,
                Picture = adDto.Picture,
                Price = adDto.Price,
                Category = adDto.CategoryId,
                CreationDate = adDto.CreationDate,
                LocationId = adDto.LocationId,
                Type = adDto.TypeId,
                Condition = adDto.ConditionId
            };
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