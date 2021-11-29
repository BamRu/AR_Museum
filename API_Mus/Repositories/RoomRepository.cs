using API_Mus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mus.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDBContext _context;
        public RoomRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            var RoomToDelete = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(RoomToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<IEnumerable<Placement>> GetPlacment()
        {
            return await _context.Placements.ToListAsync();
        }

        public async Task<Room> Get(int ID)
        {
            return await _context.Rooms.FindAsync(ID);
        }

        public async Task Update(Room room)
        {
            _context.Rooms.Update(room);

           

            await _context.SaveChangesAsync();
        }

    }
}
