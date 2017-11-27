using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Service.Dto;

namespace Service.Contracts
{
    public class AdService : IAdService
    {
        private readonly SqlConnection _connection = new SqlConnection();

        private readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["AdsDataBase"].ConnectionString;

        public AdDto[] GetAdsDto()
        {
            _connection.ConnectionString = _connectionString;
            var adsList = new List<AdDto>();
            try
            {
                using (var command = new SqlCommand("GetAds", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    _connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var ad = new AdDto()
                            {
                                Id = (int)reader["Id"],
                                UserId = (int)reader["UserId"],
                                Name = reader["Name"].ToString(),
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
            }
            catch (Exception e)
            {
            }
            return adsList.ToArray();
        }

        public AdDto GetAdDetailsDto(int adId)
        {
            _connection.ConnectionString = _connectionString;
            var adDetails = new AdDto();

            using (var command = new SqlCommand("GetAdDetails", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", adId);

                _connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        adDetails.Id = (int)reader["Id"];
                        adDetails.UserId = (int)reader["UserId"];
                        adDetails.Name = reader["Name"].ToString();
                        adDetails.Description = reader["Description"].ToString();
                        adDetails.Picture = reader["Picture"].ToString();
                        adDetails.Price = (decimal)reader["Price"];
                        adDetails.CategoryId = (int)reader["CategoryId"];
                        adDetails.CreationDate = (DateTime)reader["CreationDate"];
                        adDetails.LocationId = (int)reader["LocationId"];
                        adDetails.TypeId = (int)reader["TypeId"];
                        adDetails.ConditionId = (int)reader["ConditionId"];
                    }
                }
                _connection.Close();
            }
            return adDetails;
        }

        public List<CategoryDto> GetCategoriesDto()
        {
            _connection.ConnectionString = _connectionString;
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
                            Id = (int)reader["Id"],
                            CategoryName = reader["CategoryName"].ToString(),
                            ParientCategoryId = (int)reader["ParientCategoryId"]
                        };
                        categoriesList.Add(category);
                    }
                }
                _connection.Close();
            }
            return categoriesList;
        }

        public List<UserDto> GetUsersDto()
        {
            _connection.ConnectionString = _connectionString;
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
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Phone1 = reader["Phone1"].ToString(),
                            Phone2 = reader["Phone2"].ToString(),
                            Email1 = reader["Email1"].ToString(),
                            Email2 = reader["Email2"].ToString(),
                        };
                        usersList.Add(userDto);
                    }
                }
                _connection.Close();
            }
            return usersList;
        }
    }
}
