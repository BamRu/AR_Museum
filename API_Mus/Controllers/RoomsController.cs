using API_Mus.Models;
using API_Mus.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Mus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet("/GetRooms")]      
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _roomRepository.GetRooms();
        }

        [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("/GetPlasments")]
        public async Task<IEnumerable<Placement>> GetPlasments()
        {
            return await _roomRepository.GetPlacment();
        }

        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRooms(int id)
        {
            return await _roomRepository.Get(id);
        }

        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<Room>> PostBooks([FromBody] Room room)
        {
            var newroom = await _roomRepository.Create(room);
            return CreatedAtAction(nameof(GetRooms), new { id = newroom.Id }, newroom);
        }

        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpPut]
        public async Task<ActionResult> PutBooks(int id, [FromBody] Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            await _roomRepository.Update(room);

            return NoContent();
        }

        //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var roomToDelete = await _roomRepository.Get(id);
            if (roomToDelete == null)
                return NotFound();

            await _roomRepository.Delete(roomToDelete.Id);
            return NoContent();
        }
    }
}
