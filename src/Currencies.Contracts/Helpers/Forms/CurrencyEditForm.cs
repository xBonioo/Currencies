using Currencies.Contracts.Helpers.Controls;

namespace Currencies.Contracts.Helpers.Forms;

public class CurrencyEditForm
{
    public StringControl Name { get; set; }
    public StringControl Symbol { get; set; }
    public StringControl Description { get; set; }
    public BoolControl IsActive { get; set; }
}
