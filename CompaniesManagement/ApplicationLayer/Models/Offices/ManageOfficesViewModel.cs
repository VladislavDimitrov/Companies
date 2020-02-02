using System.Collections.Generic;

namespace ApplicationLayer.Models.Offices
{
    public class ManageOfficesViewModel
    {
        public ManageOfficesViewModel()
        {

        }
        public string Input { get; set; }
        public List<OfficeViewModel> Offices { get; set; } = new List<OfficeViewModel>(50);
    }
}
