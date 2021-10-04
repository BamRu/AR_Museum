using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_DB.Data.Tables
{
    [Table("Placment")]
    public class Placement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UUID { get; set; }

        [ForeignKey("room")]
        public int? UUID_Room { get; set; }

        [ForeignKey("model")]
        public int UUID_Model { get; set; }

        [ForeignKey("position")]
        public int UUID_Position { get; set; }

        [ForeignKey("rotation")]
        public int UUID_Rotation { get; set; }

        public Room room { get; set; }
        public Model model { get; set; }
        public Position position { get; set; }
        public Rotation rotation { get; set; }

    }
}
