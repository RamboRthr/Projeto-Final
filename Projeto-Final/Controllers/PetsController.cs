using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Final.Models;

namespace Projeto_Final.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly UserManagementContext _context;

        public PetsController(UserManagementContext context)
        {
            _context = context;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pets>>> GetPets()
        {
            return await _context.Pets.ToListAsync();
        }

        // GET:  api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pets>> GetPets(int id)
        {
            var pets = await _context.Pets.FindAsync(id);

            if (pets == null)
            {
                return NotFound();
            }

            return pets;
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPets(int id, Pets pets)
        {
            if (id != pets.Id)
            {
                return BadRequest();
            }

            _context.Entry(pets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pets>> PostPets(Pets pets)
        {
            pets.Current_owner = _context.Users.Single(user => user.Id == pets.Current_owner.Id);
            _context.Pets.Add(pets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPets", new { id = pets.Id }, pets);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePets(int id)
        {
            var pets = await _context.Pets.FindAsync(id);
            if (pets == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetsExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
