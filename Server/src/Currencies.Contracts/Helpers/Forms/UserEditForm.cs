using Currencies.Contracts.Helpers.Controls;

namespace Currencies.Contracts.Helpers.Forms
{
    public class UserEditForm
    {
        public StringControl Email { get; set; }
        public StringControl UserName { get; set; }
        public StringControl FirstName { get; set; }
        public StringControl SecondName { get; set; }
        public BoolControl IsActive { get; set; }
    }
}
