using FaleMaisDomain.Entities;

namespace FaleMaisPersistence.Repositories.Interfaces {
  public interface ICitiesRepository {
    public City Create(City data);
    public City FindByAreaCode(byte areaCode);
    public void SaveChanges();
  }
}
