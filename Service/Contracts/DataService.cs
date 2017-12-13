using Service.Dto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Service.Contracts
{
    public class DataService : IDataService
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlConnection _connection = new SqlConnection(connectionString);

        public List<AdDto> GetAdsDto()
        {
            _connection.ConnectionString = connectionString;
            _connection.Open();
            var adsList = new List<AdDto>();

            using (var cmd = new SqlCommand("GetAds", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ad = new AdDto
                        {
                            Id = (int)reader["Id"],
                            UserName = (string)reader["UserName"],
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
            }
            return adsList;
        }


        public List<AdDto> GetAdsByCategoryDto(int categoryId)
        {
            var resultCollection = new List<int>();
            var ads = new List<AdDto>();
            var categoryIdList = GetChildId(categoryId, resultCollection, GetCategoriesDto());

            foreach (var id in categoryIdList)
            {
                ads.AddRange(GetAdsByParentCategoryDto(id));
            }
            return ads;
        }

        public AdDto GetAdDetailsDto(int adId)
        {
            var ad = new AdDto();

            _connection.ConnectionString = connectionString;
            _connection.Open();

            using (var command = new SqlCommand("GetAdDetails", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", adId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ad.Id = (int) reader["Id"];
                        ad.UserName = (string) reader["UserName"];
                        ad.Name = reader["Name"].ToString();
                        ad.Description = reader["Description"].ToString();
                        ad.Picture = reader["Picture"].ToString();
                        ad.Price = (decimal) reader["Price"];
                        ad.CategoryId = (int) reader["CategoryId"];
                        ad.CreationDate = (DateTime) reader["CreationDate"];
                        ad.LocationId = (int) reader["LocationId"];
                        ad.TypeId = (int) reader["TypeId"];
                        ad.ConditionId = (int) reader["ConditionId"];
                    }
                }
            }
            return ad;
        }

        public List<CategoryDto> GetCategoriesDto()
        {
            _connection.ConnectionString = connectionString;
            _connection.Open();
            var categoriesList = new List<CategoryDto>();

            using (var command = new SqlCommand("GetCategories", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

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
            }
            return categoriesList;
        }

        public List<UserDto> GetUsersDto()
        {
            _connection.ConnectionString = connectionString;
            _connection.Open();
            var usersList = new List<UserDto>();

            using (var command = new SqlCommand("GetUsers", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

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
            }
            return usersList;
        }

        public UserDto GetUserDtoByName(string userName)
        {
            _connection.ConnectionString = connectionString;
            _connection.Open();
            var userDto = new UserDto();

            using (var command = new SqlCommand("GetUserDetails", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", userName);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userDto.UserName = reader["UserName"].ToString();
                        userDto.RoleName = reader["RoleName"].ToString();
                    }
                }
            }
            return userDto;
        }

        public bool IsValidUser(string userName, string password)
        {
            _connection.ConnectionString = connectionString;
            _connection.Open();

            using (var command = new SqlCommand("IsValidUser", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", password);

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read();
                }
            }
        }

        private static List<int> GetChildId(int parentId, ICollection<int> resultCollection, IEnumerable<CategoryDto> list)
        {
            resultCollection.Add(parentId);

            var categories = list as CategoryDto[] ?? list.ToArray();
            foreach (var category in categories)
            {
                if (category.ParentCategoryId == parentId)
                    GetChildId(category.CategoryId, resultCollection, categories);
            }

            return resultCollection.ToList();
        }

        private IEnumerable<AdDto> GetAdsByParentCategoryDto(int categoryId)
        {
            //_connection.ConnectionString = connectionString;
            //_connection.Open();
            var adsList = new List<AdDto>();

            using (var command = new SqlCommand("GetAdsByCategory", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@categoryId", categoryId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ad = new AdDto
                        {
                            Id = (int)reader["Id"],
                            UserName = (string)reader["UserName"],
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
            }
            return adsList;
        }

    }
}
