using System;

namespace FaleMaisDomain.Entities {
  public class Call {
    public byte FromAreaCode { get; set; }
    public byte ToAreaCode { get; set; }
    public double PricePerMinute { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public AreaCode From { get; set; }
    public AreaCode To { get; set; }
  }
}
