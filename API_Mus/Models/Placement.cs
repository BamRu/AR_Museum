using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Mus.Models
{

    public class Placement
    {
 
        public int UUID { get; set; }

        public int UUID_Room { get; set; }
        public Room Room { get; set; }

        public int UUID_Model { get; set; }
        public Model Model { get; set; }

        public int UUID_Position { get; set; }
        public Position Position { get; set; }

        public int UUID_Rotation { get; set; }
        public Rotation Rotation { get; set; }

    }
}
