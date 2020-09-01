using FaleMaisPersistence.Context;

namespace FaleMaisPersistence.Repositories {
  public class BaseRepository<TClass> {
    protected readonly FaleMaisDbContext dbContext;

    public BaseRepository(FaleMaisDbContext dbContext) {
      this.dbContext = dbContext;
    }

    public TClass Create(TClass data) {
      dbContext.Add(data);

      SaveChanges();

      return data;
    }

    public void SaveChanges() => dbContext.SaveChanges();
  }
}
