using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AR_Musiam_Backend
{
    
    public class Object
    {
        public int UUID { get; set; }
        public string Name { get; set; }
    }
    public class Position
    {
        public int UUID { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }

    public class Rotation
    {
        public int UUID { get; set; }
        public int w { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int z { get; set; }

    }

    public class Placment
    {
        public int UUID_Room { get; set; }

        public int UUID_Object { get; set; }
        public int UUID_Position { get; set; }
        public int UUID_Rotation { get; set; }
    }
}
