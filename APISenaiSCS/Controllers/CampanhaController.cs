
using APISenaiSCS.Contexts;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using APISenaiSCS.Repositories;
using APISenaiSCS.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APISenaiSCS.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaController : ControllerBase
    {
        /// <summary>
        /// Objeto _campanhaRepository que irá receber todos os métodos definidos na interface ICampanhasRepository
        /// </summary>
        private ICampanhaRepository _campanhaRepository { get; set; }


        public CampanhaController()
        {
            _campanhaRepository = new CampanhaRepository();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Uma lista de eventos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_campanhaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // GET: api/Campanhas/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retora a resposta da requisição fazendo a chamada para o método
                return Ok(_campanhaRepository.(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }}


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
