using Common.Common;
using Common.Models;

namespace SocietyManagementUI.Models
{
    public class AddFlatViewModel : Flat
    {
        public List<Wing> WingIdAndName { get; set; }
        public SocietyRoleType RoleType { get; set; }
    }
}
