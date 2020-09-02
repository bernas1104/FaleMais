using System.Collections.Generic;
using FaleMaisDomain.Entities;

namespace FaleMaisPersistence.Repositories.Interfaces {
  public interface ICallsRepository {
    public Call Create(Call data);
    public Call FindByFromToAreaCode(byte fromAreaCode, byte toAreaCode);
    public void SaveChanges();
  }
}
