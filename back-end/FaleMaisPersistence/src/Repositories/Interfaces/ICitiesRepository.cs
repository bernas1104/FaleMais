using System.Collections.Generic;
using FaleMaisDomain.Entities;

namespace FaleMaisPersistence.Repositories.Interfaces {
  public interface ICitiesRepository {
    public City Create(City data);
    public City FindByAreaCode(byte areaCode);
    public IEnumerable<City> FindAll();
    public void SaveChanges();
  }
}
