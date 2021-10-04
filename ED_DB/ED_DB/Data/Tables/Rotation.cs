using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_DB.Data.Tables
{
    [Table("Rotation")]
    public class Rotation
    {
        [Key]//, ForeignKey("placement")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UUID { get; set; }
        public double w { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

    }
}
