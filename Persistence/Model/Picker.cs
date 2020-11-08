using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Model
{
    public class Picker
    {
        [Required] public string Name { get; set; }
        [Required] public bool IsAvailable { get; set; }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int EmployeeId { get; set; }
        public Order PickingOrder { get; set; }
    }
}