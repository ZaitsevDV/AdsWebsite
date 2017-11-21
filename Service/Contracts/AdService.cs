using Service.DTO;

namespace Service.Contracts
{
    public class AdService : IAdService
    {
        public AdDto GetAdDto()
        {
            return new AdDto() { Id = 1, Name = "Computer" };
        }
    }
}