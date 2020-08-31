using System;

namespace FaleMaisDomain.Entities {
  public class City {
    public byte AreaCode { get; set; }
    public string Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
  }
}