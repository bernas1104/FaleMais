using System.Collections.Generic;
using FaleMaisDomain.Entities;

namespace FaleMaisPersistence.Repositories.Interfaces {
  public interface IAreaCodesRepository {
    public AreaCode Create(AreaCode data);
    public AreaCode FindByAreaCode(byte id);
    public IEnumerable<AreaCode> FindAll();
    public void SaveChanges();
  }
}
