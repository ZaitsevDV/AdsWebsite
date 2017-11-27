using System.Collections.Generic;
using DataTier.AdService;

namespace DataTier.Clients
{
    public class AdClient : IAdClient
    {
        public AdDto GetAdDetailsDto(int id)
        {
            AdDto result;
            using (var client = new AdServiceClient())
            {
                client.Open();

                result = client.GetAdDetailsDto(id);

                client.Close();
            }
            return result;
        }

        public List<AdDto> GetAdsDto()
        {
            List<AdDto> result;
            using (var client = new AdServiceClient())
            {
                client.Open();

                result = new List<AdDto>(client.GetAdsDto());

                client.Close();
            }
            return result;
        }

        public List<CategoryDto> GetCategoriesDto()
        {
            List<CategoryDto> result;
            using (var client = new AdServiceClient())
            {
                client.Open();

                result = new List<CategoryDto>(client.GetCategoriesDto());

                client.Close();
            }
            return result;
        }

        public List<UserDto> GetUsersDto()
        {
            List<UserDto> result;
            using (var client = new AdServiceClient())
            {
                client.Open();

                result = new List<UserDto>(client.GetUsersDto());

                client.Close();
            }
            return result;
        }
    }
}
