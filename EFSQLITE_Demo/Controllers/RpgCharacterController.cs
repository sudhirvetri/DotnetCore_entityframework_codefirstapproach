using Microsoft.AspNetCore.Http;
using EFSQLITE_Demo.Data;
using System.Linq;
using System.Collections.Generic; // For List<T>
using System.Threading.Tasks; // For async/await
using Microsoft.AspNetCore.Mvc; // For ActionResult
using Microsoft.EntityFrameworkCore; // For ToListAsync



namespace EFSQLITE_Demo.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class RpgCharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public RpgCharacterController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<RpgCharacter>>> AddCharacter(RpgCharacter character)
        {
            _context.rpgcharacter.Add(character);
            await _context.SaveChangesAsync();

            return Ok(await _context.rpgcharacter.ToListAsync());


        }

        [HttpGet]
        public async Task<ActionResult<List<RpgCharacter>>> GetAllCharacter()
        {
            return Ok(await _context.rpgcharacter.ToListAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<RpgCharacter>>> GetCharacter(int id)
        {
            var character = await _context.rpgcharacter.FindAsync(id);
            if (character == null)
            {
                return BadRequest("Character not found. ");
            }

            return Ok(character);
        }
    }

}