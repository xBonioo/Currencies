using Currencies.Contracts.Helpers.Controls;

namespace Currencies.Contracts.Helpers.Forms;

public class UserCurrencyAmountEditForm
{
    public StringControl UserId { get; set; }
    public IntegerControl CurrencyId { get; set; }
    public DecimalControl Amount { get; set; }
    public BoolControl IsActive { get; set; }
}

