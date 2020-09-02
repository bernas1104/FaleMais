using System.Collections.Generic;
using FaleMaisDomain.Entities;

namespace FaleMaisPersistence.Repositories.Interfaces {
  public interface IPricesRepository {
    public Price Create(Price data);
    public Price FindByFromToAreaCode(byte fromAreaCode, byte toAreaCode);
    public IEnumerable<Price> FindByFromToAreaCodeWithCities(byte fromAreaCode);
    public void SaveChanges();
  }
}
