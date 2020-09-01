using System.Linq;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Context;
using FaleMaisPersistence.Repositories.Interfaces;

namespace FaleMaisPersistence.Repositories {
  public class CitiesRepository : BaseRepository<City>, ICitiesRepository {
    public CitiesRepository(FaleMaisDbContext dbContext) : base(dbContext) {}

    public City FindByAreaCode(byte areaCode) {
      var city = dbContext.Cities.FirstOrDefault(c => c.AreaCode == areaCode);

      return city;
    }
  }
}
