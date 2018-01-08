using AW.Data.DataService;
using System.Collections.Generic;

namespace AW.Data.Clients
{
    public class Client : IClient
    {
        #region Ads

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

        #endregion

        #region Users

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

        public void CreateUserDto(UserDto userDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.CreateUserDto(userDto);

                client.Close();
            }
        }

        public void EditeUserDto(UserDto userDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.EditeUserDto(userDto);

                client.Close();
            }
        }

        public void EditePasswordDto(string userName, string password)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.EditePasswordDto(userName, password);

                client.Close();
            }
        }

        public void DeleteUserDto(string userName)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.DeleteUserDto(userName);

                client.Close();
            }
        }

        public List<PhoneDto> GetPhonesDto(string userName)
        {
            List<PhoneDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();
                result = new List<PhoneDto>(client.GetPhonesDto(userName));
                client.Close();
            }
            return result;
        }

        public void CreatePhoneDto(PhoneDto phoneDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.CreatePhoneDto(phoneDto);

                client.Close();
            }
        }

        public void EditePhoneDto(PhoneDto phoneDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.EditePhoneDto(phoneDto);

                client.Close();
            }
        }

        public void DeletePhoneDto(int phoneId)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.DeletePhoneDto(phoneId);

                client.Close();
            }
        }

        public List<EmailDto> GetEmailsDto(string userName)
        {
            List<EmailDto> result;
            using (var client = new DataServiceClient())
            {
                client.Open();

                result = new List<EmailDto>(client.GetEmailsDto(userName));

                client.Close();
            }
            return result;
        }

        public void CreateEmailDto(EmailDto emailDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.CreateEmailDto(emailDto);

                client.Close();
            }
        }

        public void EditeEmailDto(EmailDto emailDto)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.EditeEmailDto(emailDto);

                client.Close();
            }
        }

        public void DeleteEmailDto(int emailId)
        {
            using (var client = new DataServiceClient())
            {
                client.Open();

                client.DeleteEmailDto(emailId);

                client.Close();
            }
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
        #endregion
    }
}