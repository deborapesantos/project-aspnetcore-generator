using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TemplateHexagonal.Ports.API.ViewModels.Request
{
    public class GetAllRequestViewModel
    {
        [DefaultValue(1)]
        public int Index { get; set; }

        [DefaultValue(10)] 
        public int Size { get; set; }
        
        public int? PortalSearchId { get; set; }
        
        public DateTime? StartDate { get; set; }
        
        public DateTime? EndDate { get; set; }
        
        public string? Presentation { get; set; }
    }
}
