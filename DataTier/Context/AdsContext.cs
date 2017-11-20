using System.Data.Entity;
using Common.Models;

namespace DataTier.Context
{
    internal class AdsContext : DbContext
    {
        public AdsContext() : base("DefaultConnection")
        {
        }

        public DbSet<Ad> Ads { get; set; }
    }
}