
using APISenaiSCS.Contexts;
using APISenaiSCS.Domains;
using APISenaiSCS.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISenaiSCS.Controllers
{
    public class CampanhaController : ControllerBase
    {
        private readonly APISnaiSCSContext _context;

        public CampanhaController(APISnaiSCSContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<campanha>>> GetCampanhas()
        {
            return await _context.campanhas.ToListAsync();
        }

        // GET: api/Campanhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<campanha>> GetCampanhas(int id)
        {
            var campanha = await _context.campanhas.FindAsync(id);

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }


        [HttpPost]
        public async Task<ActionResult<campanha>> PostCampanhas([FromForm] campanha campanha, IFormFile arquivo)
        {

            #region Upload da Imagem com extensões permitidas apenas
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

            if (uploadResultado == "")
            {
                return BadRequest("Arquivo não encontrado");
            }

            if (uploadResultado == "Extensão não permitida")
            {
                return BadRequest("Extensão de arquivo não permitida");
            }

            campanha.imagem = uploadResultado;
            #endregion


            _context.campanhas.Add(campanha);
            await _context.SaveChangesAsync();

            return Created("Campanhas", campanha);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampanhas(int id)
        {
            var campanha = await _context.campanhas.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            _context.campanhas.Remove(campanha);
            await _context.SaveChangesAsync();

            // Removendo Arquivo do servidor
            Upload.RemoverArquivo(campanha.imagem);

            return NoContent();
        }

    }
}
