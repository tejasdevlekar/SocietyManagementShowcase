using Common.Common;
using Common.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SocietyManagementUI.Models
{
    public class SwimmingPoolActionEditViewModel : SwimmingPool
    {
        public List<SelectListItem> HealthStatusItems { get; set; }

        public SwimmingPoolActionEditViewModel()
        {
            HealthStatusItems = new List<SelectListItem>();
            HealthStatusItems.Add(new SelectListItem()
            {
                Disabled = true,
                Text = "Choose Health Status",
                Value = string.Empty,
                Selected = true
            });
            foreach (StatusHealth health in Enum.GetValues(typeof(StatusHealth)))
            {
                HealthStatusItems.Add(new SelectListItem
                {
                    Value = ((int)health).ToString(),
                    Text = health.ToString()
                });
            }
        }


    }
}
