using APISenaiSCS.Context;
using APISenaiSCS.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Controllers
{
    public class CampanhaController : ControllerBase
    {
        private readonly HotspotContext _context;

        public CampanhaController(HotspotContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campanhas>>> GetCampanhas()
        {
            return await _context.Campanhas.ToListAsync();
        }

        // GET: api/Campanhas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campanhas>> GetCampanhas(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }


        [HttpPost]
        public async Task<ActionResult<Campanhas>> PostCampanhas([FromForm] Campanhas campanha, IFormFile arquivo)
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

            campanha.Imagem = uploadResultado;
            #endregion


            _context.Campanhas.Add(campanha);
            await _context.SaveChangesAsync();

            return Created("Campanhas", campanha);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampanhas(int id)
        {
            var campanha = await _context.Campanhas.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            _context.Campanhas.Remove(campanha);
            await _context.SaveChangesAsync();

            // Removendo Arquivo do servidor
           // Upload.RemoverArquivo(campanha.Imagem);

            return NoContent();
        }

    }
}
