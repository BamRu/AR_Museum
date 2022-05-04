using Microsoft.EntityFrameworkCore.Infrastructure;
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
        public IList<Placement> _placement;
        public Room()
        {

        }
        private Room(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }

        //[ResponseBody]
        public IList<Placement> Placement 
        { 
            get=> LazyLoader.Load(this,ref _placement); 
            set=> _placement = value;
        }
    }

}
