using DataTier.AdService;

namespace DataTier.Clients
{
    public interface IAdClient
    {
        AdDto GetAdDto(int id);
    }
}
