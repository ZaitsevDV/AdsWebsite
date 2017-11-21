using Common.Models;
using DataTier.AdService;

namespace DataTier.Business
{
    public interface IConvert
    {
        Ad ToAd(AdDto adDto);
    }
}
