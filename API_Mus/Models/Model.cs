using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Mus.Models
{
    public class Model
    {
        public int UUID { get; set; }

        public string Name { get; set; }

    }
}
