using ED_DB.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var cont = new Data.MyDbContext())
                {
                    var rooms = new Data.Tables.Room { Name = "Test" };
                    cont.Room.Add(rooms);
                    cont.SaveChanges();

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


            Console.ReadKey();

        }

        public List<Room> Get_Rooms()
        {
            List<Room> lists = new List<Room>();


            return lists;
        }
        public void GetRoom(int Room)
        {

        }

        public void PostRoom(Room Room)
        {

        }

        /*
        public Room PRoom (Room Room)
        {

        }
        */

        public void DeleteRoom (int Room)
        {

        }
    }
}
