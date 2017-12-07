using DataTier.AdService;
using System.Collections.Generic;

namespace DataTier.Clients
{
    public class Client : IClient
    {
        public AdDto GetAdDetailsDto(int id)
        {
            AdDto result;
            using (var client = new DataServiceClient())
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
            using (var client = new DataServiceClient())
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
            using (var client = new DataServiceClient())
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
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<UserDto>(client.GetUsersDto());

                client.Close();
            }
            return result;
        }

        public UserDto GetUserDtoByName(string userName)
        {
            UserDto result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = client.GetUserDtoByName(userName);

                client.Close();
            }
            return result;
        }

        public bool IsValidUser(string userName, string password)
        {
            bool result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = client.IsValidUser(userName, password);

                client.Close();
            }
            return result;
        }
    }
}