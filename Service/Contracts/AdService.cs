using System.Collections.Generic;
using Service;
using Service.Dto;

namespace Service.Contracts
{
    public class AdService : IAdService
    {
        public AdDto GetAdDto(int id)
        {
            return new AdDto() { Id = 1, Name = "Computer" };
        }
    }
}