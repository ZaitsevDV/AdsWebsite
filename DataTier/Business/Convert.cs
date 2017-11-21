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
                Name = adDto.Name
            };
        }
    }
}
