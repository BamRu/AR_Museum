using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mus.Models
{

    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
