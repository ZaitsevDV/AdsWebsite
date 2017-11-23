using DataTier.AdService;

namespace DataTier.Clients
{
    public class AdClient : IAdClient
    {
        AdDto IAdClient.GetAdDto(int id)
        {
            var result = default(AdDto);
            using (var client = new AdService.AdServiceClient())
            {
                client.Open();

                result = client.GetAdDto(id);

                client.Close();
            }
            return result;
        }
    }
}
