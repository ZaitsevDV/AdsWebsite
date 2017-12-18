using System.Collections.Generic;
using AW.Data.DataService;

namespace AW.Data.Clients
{
    public class Client : IClient
    {

        public void CreateAdDto(AdDto adDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.CreateAdDto(adDto);

                client.Close();
            }
        }

        public void EditeAdDto(AdDto adDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.EditeAdDto(adDto);

                client.Close();
            }
        }

        public void DeleteAdDto(int adId)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.DeleteAdDto(adId);

                client.Close();
            }
        }

        public List<AdDto> GetAdsByCategoryDto(int categoryId)
        {
            List<AdDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<AdDto>(client.GetAdsByCategoryDto(categoryId));

                client.Close();
            }
            return result;
        }

        public AdDetailsDto GetAdDetailsDto(int id)
        {
            AdDetailsDto result;
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

        public List<ConditionDto> GetConditionsDto()
        {
            List<ConditionDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<ConditionDto>(client.GetConditionsDto());

                client.Close();
            }
            return result;
        }

        public List<EmailDto> GetEmailsDto()
        {
            List<EmailDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<EmailDto>(client.GetEmailsDto());

                client.Close();
            }
            return result;
        }

        public List<LocationDto> GetLocationsDto()
        {
            List<LocationDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<LocationDto>(client.GetLocationsDto());

                client.Close();
            }
            return result;
        }

        public List<PhoneDto> GetPhonesDto()
        {
            List<PhoneDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<PhoneDto>(client.GetPhonesDto());

                client.Close();
            }
            return result;
        }

        public List<RoleDto> GetRolesDto()
        {
            List<RoleDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<RoleDto>(client.GetRolesDto());

                client.Close();
            }
            return result;
        }

        public List<TypeDto> GetTypesDto()
        {
            List<TypeDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<TypeDto>(client.GetTypesDto());

                client.Close();
            }
            return result;
        }
    }
}