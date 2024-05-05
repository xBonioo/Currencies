using Currencies.Common.Enum;
using Currencies.Contracts.Helpers.Controls;

namespace Currencies.Contracts.Helpers.Forms;

public class ExchangeRateEditForm
{
    public IntegerControl FromCurrencyId { get; set; }
    public IntegerControl ToCurrencyId { get; set; }
    public DecimalControl Rate { get; set; }
    public EnumControl<Direction> Direction { get; set; }
    public BoolControl IsActive { get; set; }
}
