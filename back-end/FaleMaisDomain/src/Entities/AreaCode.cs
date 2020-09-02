using System;
using System.Collections.Generic;

namespace FaleMaisDomain.Entities {
  public class AreaCode {
    public byte Id { get; set; }
    public string Name { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Call> FromTo { get; set; }
    public ICollection<Call> ToFrom { get; set; }
  }
}
