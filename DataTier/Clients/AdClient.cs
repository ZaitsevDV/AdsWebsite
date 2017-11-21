using DataTier.AdService;

namespace DataTier.Clients
{
    public class AdClient : IAdClient
    {
        AdDto IAdClient.GetaAdDto()
        {
            var result = default(AdDto);
            using (var client = new AdService.AdServiceClient())
            {
                client.Open();

                result = client.GetAdDto();

                client.Close();
            }
            return result;
        }
    }
}
