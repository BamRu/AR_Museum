using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_DB.Data.Tables
{
    [Table("Model")]
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UUID { get; set; }
        [Unique]
        public string Name { get; set; }

    }
}
