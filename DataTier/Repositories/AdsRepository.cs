using Common.Models;
using DataTier.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataTier.Repositories
{
    public class AdsRepository : IAdsRepository
    {
        public AdsRepository()
        { }

        public async Task<Ad> GetAdAsync(int id)
        {
            Ad result = null;

            using (var adsContext = new AdsContext())
            {
                result = await adsContext.Ads.FirstOrDefaultAsync(f => f.Id == id);
            }

            return result;
        }

        public async Task<Ad> AddAdAsync(Ad ad)
        {
            Ad result = null;

            using (var adsContext = new AdsContext())
            {
                result = adsContext.Ads.Add(ad);
                await adsContext.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Ad>> GetAdsAsync()
        {
            var result = new List<Ad>();

            using (var adsContext = new AdsContext())
            {
                result = await adsContext.Ads.ToListAsync();
            }

            return result;
        }

        public async Task DeleteAdAsync(int id)
        {
            using (var adsContext = new AdsContext())
            {
                var ad = await adsContext.Ads.FirstOrDefaultAsync(f => f.Id == id);

                adsContext.Entry(ad).State = EntityState.Deleted;

                await adsContext.SaveChangesAsync();
            }
        }

        public async Task<Ad> UpdateAdAsync(Ad ad)
        {
            using (var adContext = new AdsContext())
            {
                adContext.Entry(ad).State = EntityState.Modified;

                await adContext.SaveChangesAsync();
            }

            return ad;
        }
    }
}