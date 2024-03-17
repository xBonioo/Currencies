using Currencies.Contracts.Helpers.Controls;

namespace Currencies.Contracts.Helpers.Forms;

public class RoleEditForm
{
    public StringControl Name { get; set; }
    public BoolControl IsActive { get; set; }
}
