using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DESKfurniture.Models
{
    public class DeskUsageViewModel
    {
        public List<Desk> Desk { get; set; }
        public SelectList Usage { get; set; }
        public string DeskUsage { get; set; }
        public string SearchString { get; set; }
    }
}
