using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ED_DB.Data.Tables
{
 [Table("Room")]
    public class Room
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UUID_Room { get; set; }
        [Unique]
        public string Name { get; set; }
    }

}
