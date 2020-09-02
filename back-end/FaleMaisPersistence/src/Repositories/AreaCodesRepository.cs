using System.Collections.Generic;
using System.Linq;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Context;
using FaleMaisPersistence.Repositories.Interfaces;

namespace FaleMaisPersistence.Repositories {
  public class AreaCodesRepository : BaseRepository<AreaCode>, IAreaCodesRepository {
    public AreaCodesRepository(FaleMaisDbContext dbContext) : base(dbContext) {}

    public AreaCode FindByAreaCode(byte id) {
      var city = dbContext.AreaCodes.FirstOrDefault(c => c.Id == id);

      return city;
    }

    public IEnumerable<AreaCode> FindAll() {
      var states = dbContext.AreaCodes.AsEnumerable();

      return states;
    }
  }
}
