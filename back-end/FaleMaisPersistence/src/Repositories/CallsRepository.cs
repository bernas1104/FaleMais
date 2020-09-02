using System.Collections.Generic;
using System.Linq;
using FaleMaisDomain.Entities;
using FaleMaisPersistence.Context;
using FaleMaisPersistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FaleMaisPersistence.Repositories {
  public class CallsRepository : BaseRepository<Call>, ICallsRepository {
    public CallsRepository(FaleMaisDbContext dbContext) : base(dbContext) {}

    public Call FindByFromToAreaCode(byte fromAreaCode, byte toAreaCode) {
      var call = dbContext.Calls.FirstOrDefault(
        x => x.FromAreaCode == fromAreaCode && x.ToAreaCode == toAreaCode
      );

      return call;
    }
  }
}
