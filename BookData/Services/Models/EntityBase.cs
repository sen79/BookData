using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookData.Services.Models
{
    public class EntityBase
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
