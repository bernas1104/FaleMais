using Flunt.Notifications;
using Flunt.Validations;

namespace FaleMaisServices.ViewModels {
  public class CityViewModel : Notifiable, IValidatable {
    public byte AreaCode { get; set; }
    public string Name { get; set; }

    public void Validate() {
      AddNotifications(
        new Contract()
          .IsNotNull(AreaCode, "Area Code", "Is required")
          .IfNotNull(AreaCode, contract => contract.IsBetween(
            AreaCode, 1, 100, "Area Code", "Must be between 1 and 100"
          ))
          .IsNotNullOrEmpty(Name, "Name", "Is required")
          .IfNotNull(Name, contract =>
            contract
              .HasMinLen(Name, 3, "Name", "Must have at least 3 characters")
              .HasMaxLen(Name, 50, "Name", "Must have at most 50 characters")
          )
      );
    }
  }
}
