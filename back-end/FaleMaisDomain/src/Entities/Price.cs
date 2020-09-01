using System;

namespace FaleMaisDomain.Entities {
  public class Price {
    public string Id { get; set; }
    public byte FromAreaCode { get; set; }
    public byte ToAreaCode { get; set; }
    public double PricePerMinute { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public City FromCity { get; set; }
    public City ToCity { get; set; }
  }
}