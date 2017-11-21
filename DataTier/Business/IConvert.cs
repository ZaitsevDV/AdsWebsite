using Common.Models;
using Service.DTO;

namespace DataTier.Business
{
    public interface IConvert
    {
        Ad ToAd(AdDto adDto);
    }
}
