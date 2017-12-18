using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Service.Dto;

namespace Service.Contracts
{
    public class DataService : IDataService
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        private readonly SqlConnection _connection = new SqlConnection(ConnectionString);

        public void CreateAdDto(AdDto adDto)
        {
            _connection.ConnectionString = ConnectionString;

            using (var command = new SqlCommand("CreateAd", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", adDto.Title);
                command.Parameters.AddWithValue("@UserName", adDto.UserName);
                command.Parameters.AddWithValue("@Description", adDto.Description);
                command.Parameters.AddWithValue("@Picture", adDto.Picture);
                command.Parameters.AddWithValue("@Price", adDto.Price);
                command.Parameters.AddWithValue("@CategoryId", adDto.CategoryId);
                command.Parameters.AddWithValue("@CreationDate", adDto.CreationDate);
                command.Parameters.AddWithValue("@LocationId", adDto.LocationId);
                command.Parameters.AddWithValue("@TypeId", adDto.TypeId);
                command.Parameters.AddWithValue("@ConditionId", adDto.ConditionId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void EditeAdDto(AdDto adDto)
        {
            _connection.ConnectionString = ConnectionString;

            using (var command = new SqlCommand("EditeAd", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", adDto.Id);
                command.Parameters.AddWithValue("@Name", adDto.Title);
                command.Parameters.AddWithValue("@UserName", adDto.UserName);
                command.Parameters.AddWithValue("@Description", adDto.Description);
                command.Parameters.AddWithValue("@Picture", adDto.Picture);
                command.Parameters.AddWithValue("@Price", adDto.Price);
                command.Parameters.AddWithValue("@CategoryId", adDto.CategoryId);
                command.Parameters.AddWithValue("@CreationDate", adDto.CreationDate);
                command.Parameters.AddWithValue("@LocationId", adDto.LocationId);
                command.Parameters.AddWithValue("@TypeId", adDto.TypeId);
                command.Parameters.AddWithValue("@ConditionId", adDto.ConditionId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public void DeleteAdDto(int adId)
        {
            _connection.ConnectionString = ConnectionString;

            using (var command = new SqlCommand("DeleteAd", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", adId);
                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();
            }
        }

        public List<AdDto> GetAdsDto()
        {
            _connection.ConnectionString = ConnectionString;
            var adsList = new List<AdDto>();

            using (var cmd = new SqlCommand("GetAds", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ad = new AdDto
                        {
                            Id = (int)reader["Id"],
                            UserName = (string)reader["UserName"],
                            Title = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Picture = reader["Picture"].ToString(),
                            Price = (decimal)reader["Price"],
                            CategoryId = (int)reader["CategoryId"],
                            CreationDate = (DateTime)reader["CreationDate"],
                            LocationId = (int)reader["LocationId"],
                            TypeId = (int)reader["TypeId"],
                            ConditionId = (int)reader["ConditionId"]
                        };
                        adsList.Add(ad);
                    }
                }
                _connection.Close();
            }
            return adsList;
        }

        public List<AdDto> GetAdsByCategoryDto(int categoryId)
        {
            var resultCollection = new List<int>();
            var ads = new List<AdDto>();
            var categoryIdList = GetChildId(categoryId, resultCollection, GetCategoriesDto());

            foreach (var id in categoryIdList)
                ads.AddRange(GetAdsByParentCategoryDto(id));
            return ads;
        }

        public AdDetailsDto GetAdDetailsDto(int adId)
        {
            var adDetails = new AdDetailsDto();

            _connection.ConnectionString = ConnectionString;

            using (var command = new SqlCommand("GetAdDetails", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", adId);
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        adDetails.Id = adId;
                        adDetails.UserName = (string)reader["UserName"];
                        adDetails.Title = reader["Name"].ToString();
                        adDetails.Description = reader["Description"].ToString();
                        adDetails.Picture = reader["Picture"].ToString();
                        adDetails.Price = (decimal)reader["Price"];
                        adDetails.CategoryName = reader["CategoryName"].ToString();
                        adDetails.CreationDate = (DateTime)reader["CreationDate"];
                        adDetails.LocationName = reader["LocationName"].ToString();
                        adDetails.TypeName = reader["TypeName"].ToString();
                        adDetails.ConditionName = reader["ConditionName"].ToString();
                    }
                }
                _connection.Close();
            }
            return adDetails;
        }

        public List<CategoryDto> GetCategoriesDto()
        {
            _connection.ConnectionString = ConnectionString;
            var categoriesList = new List<CategoryDto>();

            using (var command = new SqlCommand("GetCategories", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var category = new CategoryDto
                        {
                            CategoryId = (int)reader["CategoryId"],
                            CategoryName = reader["CategoryName"].ToString(),
                            ParentCategoryId = (int)reader["ParentCategoryId"]
                        };
                        categoriesList.Add(category);
                    }
                }
                _connection.Close();
            }
            return categoriesList;
        }

        public List<TypeDto> GetTypesDto()
        {
            _connection.ConnectionString = ConnectionString;
            var typesList = new List<TypeDto>();

            using (var command = new SqlCommand("GetTypes", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var typeDto = new TypeDto
                        {
                            TypeId = (int)reader["TypeId"],
                            TypeName = reader["TypeName"].ToString()
                        };
                        typesList.Add(typeDto);
                    }
                }
                _connection.Close();
            }
            return typesList;
        }

        public List<UserDto> GetUsersDto()
        {
            _connection.ConnectionString = ConnectionString;
            var usersList = new List<UserDto>();

            using (var command = new SqlCommand("GetUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var userDto = new UserDto
                        {
                            UserName = reader["UserName"].ToString(),
                            RoleName = (string)reader["RoleName"]
                        };
                        usersList.Add(userDto);
                    }
                }
                _connection.Close();
            }
            return usersList;
        }

        public UserDto GetUserDtoByName(string userName)
        {
            _connection.ConnectionString = ConnectionString;
            var userDto = new UserDto();

            using (var command = new SqlCommand("GetUserDetails", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", userName);
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userDto.UserName = reader["UserName"].ToString();
                        userDto.RoleName = reader["RoleName"].ToString();
                    }
                }
                _connection.Close();
            }
            return userDto;
        }

        public bool IsValidUser(string userName, string password)
        {
            _connection.ConnectionString = ConnectionString;

            using (var command = new SqlCommand("IsValidUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        public List<ConditionDto> GetConditionsDto()
        {
            _connection.ConnectionString = ConnectionString;
            var conditionList = new List<ConditionDto>();

            using (var command = new SqlCommand("GetConditions", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var conditionDto = new ConditionDto
                        {
                            ConditionId = (int)reader["ConditionId"],
                            ConditionName = reader["ConditionName"].ToString()
                        };
                        conditionList.Add(conditionDto);
                    }
                }
                _connection.Close();
            }
            return conditionList;
        }

        public List<EmailDto> GetEmailsDto()
        {
            _connection.ConnectionString = ConnectionString;
            var emailList = new List<EmailDto>();

            using (var command = new SqlCommand("GetEmails", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var emailDto = new EmailDto
                        {
                            EmailId = (int)reader["EmailId"],
                            UserName = reader["UserName"].ToString(),
                            EmailValue = reader["EmailValue"].ToString()
                        };
                        emailList.Add(emailDto);
                    }
                }
                _connection.Close();
            }
            return emailList;
        }

        public List<LocationDto> GetLocationsDto()
        {
            _connection.ConnectionString = ConnectionString;
            var locationList = new List<LocationDto>();

            using (var command = new SqlCommand("GetLocations", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var locationDto = new LocationDto
                        {
                            LocationId = (int)reader["LocationId"],
                            LocationName = reader["LocationName"].ToString()
                        };
                        locationList.Add(locationDto);
                    }
                }
                _connection.Close();
            }
            return locationList;
        }

        public List<PhoneDto> GetPhonesDto()
        {
            _connection.ConnectionString = ConnectionString;
            var phoneList = new List<PhoneDto>();

            using (var command = new SqlCommand("GetPhones", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var phoneDto = new PhoneDto
                        {
                            PhoneId = (int)reader["PhoneId"],
                            UserName = reader["UserName"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString()
                        };
                        phoneList.Add(phoneDto);
                    }
                }
                _connection.Close();
            }
            return phoneList;
        }

        public List<RoleDto> GetRolesDto()
        {
            _connection.ConnectionString = ConnectionString;
            var roleList = new List<RoleDto>();

            using (var command = new SqlCommand("GetRoles", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var roleDto = new RoleDto
                        {
                            RoleId = (int)reader["ConditionId"],
                            RoleName = reader["ConditionName"].ToString()
                        };
                        roleList.Add(roleDto);
                    }
                }
                _connection.Close();
            }
            return roleList;
        }

        private static List<int> GetChildId(int parentId, ICollection<int> resultCollection,
            IEnumerable<CategoryDto> list)
        {
            resultCollection.Add(parentId);
            var categories = list as CategoryDto[] ?? list.ToArray();
            foreach (var category in categories)
                if (category.ParentCategoryId == parentId)
                    GetChildId(category.CategoryId, resultCollection, categories);
            return resultCollection.ToList();
        }

        private IEnumerable<AdDto> GetAdsByParentCategoryDto(int categoryId)
        {
            _connection.ConnectionString = ConnectionString;
            var adsList = new List<AdDto>();

            using (var command = new SqlCommand("GetAdsByCategory", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@categoryId", categoryId);
                _connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ad = new AdDto
                        {
                            Id = (int)reader["Id"],
                            UserName = (string)reader["UserName"],
                            Title = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Picture = reader["Picture"].ToString(),
                            Price = (decimal)reader["Price"],
                            CategoryId = (int)reader["CategoryId"],
                            CreationDate = (DateTime)reader["CreationDate"],
                            LocationId = (int)reader["LocationId"],
                            TypeId = (int)reader["TypeId"],
                            ConditionId = (int)reader["ConditionId"]
                        };
                        adsList.Add(ad);
                    }
                }
                _connection.Close();
            }
            return adsList;
        }
    }
}