using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Mus.Models
{

    public class Placement
    {
 
        public Placement(){}

        public Placement(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        private ILazyLoader LazyLoader { get; set; }

        public int UUID { get; set; }

        public int contentID { get; set; }

        //public int UUID_Room { get; set; }
        private Room _room;
        public Room Room
        { 
            get => LazyLoader.Load(this,ref _room); 
            set => _room = value; 
        }


        //[JsonIgnore]
        //public int UUID_Model { get; set; }
        //public Model Model { get; set; }

        //public int UUID_Position { get; set; }
        private Position _position;
        public Position Position
        {
            get => LazyLoader.Load(this, ref _position);
            set => _position = value;
        }

        private Rotation _rotation;
        //public int UUID_Rotation { get; set; }
        public Rotation Rotation
        {
            get => LazyLoader.Load(this, ref _rotation);
            set => _rotation = value;
        }

    }
}
