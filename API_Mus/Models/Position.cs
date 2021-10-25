using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Mus.Models
{
    public class Position
    {
        public int UUID { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

    }
}
