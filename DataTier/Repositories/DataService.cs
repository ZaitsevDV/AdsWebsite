using Common.Models;
using System.Collections.Generic;
using DataTier.Business;
using DataTier.Clients;

namespace DataTier.Repositories
{
    public class DataService : IDataService
    {
        private readonly IAdClient _adClient;
        private readonly IConvert _convert;

        public DataService(IAdClient client, IConvert convert)
        {
            _adClient = client;
            _convert = convert;
        }

        public Ad GetAd(int id)
        {
            var dto = _adClient.GetAdDto(id);

            if (dto != null)
            {
                return _convert.ToAd(dto);
            }
            return default(Ad);
        }

        public Ad AddAd(Ad ad)
        {
            throw new System.NotImplementedException();
        }

        public Ad DeleteAd(int id)
        {
            throw new System.NotImplementedException();
        }

        //public Ad GetAd(int id)
        //{
        //    throw new System.NotImplementedException();
        //}

        public IEnumerable<Ad> GetAds()
        {
            throw new System.NotImplementedException();
        }

        public Ad UpdateAd(Ad ad)
        {
            throw new System.NotImplementedException();
        }
    }
}