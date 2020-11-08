using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Model
{
    public class Item
    {
        //something about itemId being made in db, idk
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ItemId { get; set; }
        [Required, StringLength(255)] public string Name{ get; set; }
        //[Required] public float SizeAndWeight{ get; set; }
    }
}