using System.Collections.Generic;
using System.Linq;
using Common.Models;
using DataTier.AdService;

namespace DataTier.Business
{
    public class Convert : IConvert
    {
        public Ad ToAd(AdDto adDto)
        {
            return new Ad()
            {
                Id = adDto.Id,
                UserId = adDto.UserId,
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
            return new Category()
            {
                Id = categoryDto.Id,
                CategoryName = categoryDto.CategoryName,
                ParientCategoryId = categoryDto.ParientCategoryId
            };
        }

        public User ToUser(UserDto userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email1 = userDto.Email1,
                Email2 = userDto.Email2,
                Phone1 = userDto.Phone1,
                Phone2 = userDto.Phone2
            };
        }

        public IEnumerable<Category> ToCategories(IEnumerable<CategoryDto> categoriesDto)
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
