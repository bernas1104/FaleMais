using Flunt.Notifications;
using Flunt.Validations;

namespace FaleMaisServices.ViewModels {
  public class PriceViewModel : Notifiable, IValidatable {
    public string Id { get; set; }
    public byte FromAreaCode { get; set; }
    public byte ToAreaCode { get; set; }
    public double PricePerMinute { get; set; }

    public void Validate() {
      AddNotifications(
        new Contract()
          .IsNotNull(FromAreaCode, "From Area Code", "Is required")
          .IfNotNull(FromAreaCode, contract => (
            contract.IsBetween(
              FromAreaCode, 1, 100, "From Area Code", "Must be between 1 and 100"
            )
          ))
          .IsNotNull(ToAreaCode, "To Area Code", "Is required")
          .IfNotNull(ToAreaCode, contract => (
            contract.IsBetween(
              ToAreaCode, 1, 100, "To Area Code", "Must be between 1 and 100"
            )
            .AreNotEquals(
              ToAreaCode, FromAreaCode, "To Area Code", "Must be different than 'From Area Code'"
            )
          ))
      );
    }
  }
}
