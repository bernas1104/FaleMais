using System.Linq;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Context;
using FaleMaisPersistence.Repositories.Interfaces;

namespace FaleMaisPersistence.Repositories {
  public class PricesRepository : BaseRepository<Price>, IPricesRepository {
    public PricesRepository(FaleMaisDbContext dbContext) : base(dbContext) {}

    public Price FindByFromToAreaCode(byte fromAreaCode, byte toAreaCode) {
      var price = dbContext.Prices.FirstOrDefault(
        x => x.FromAreaCode == fromAreaCode && x.ToAreaCode == toAreaCode
      );

      return price;
    }
  }
}
