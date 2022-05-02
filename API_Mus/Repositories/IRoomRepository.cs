using API_Mus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mus.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetRooms();
        Task<Room> Get(int ID);
        Task<Room> Create(Room room);
        Task Update(Room room);
        Task Delete(int id);
    }
}
