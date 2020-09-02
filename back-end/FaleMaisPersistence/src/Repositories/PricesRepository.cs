using System.Collections.Generic;
using System.Linq;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Context;
using FaleMaisPersistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FaleMaisPersistence.Repositories {
  public class PricesRepository : BaseRepository<Price>, IPricesRepository {
    public PricesRepository(FaleMaisDbContext dbContext) : base(dbContext) {}

    public Price FindByFromToAreaCode(byte fromAreaCode, byte toAreaCode) {
      var price = dbContext.Prices.FirstOrDefault(
        x => x.FromAreaCode == fromAreaCode && x.ToAreaCode == toAreaCode
      );

      return price;
    }

    public IEnumerable<Price> FindByFromToAreaCodeWithCities(byte fromAreaCode) {
      var prices = dbContext.Prices.AsNoTracking()
        .Include(x => x.ToCity)
        .Where(x => x.FromAreaCode == fromAreaCode)
        .AsEnumerable();

      return prices;
    }
  }
}
