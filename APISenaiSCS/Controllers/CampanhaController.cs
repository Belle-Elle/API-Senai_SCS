using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using APISenaiSCS.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using APISenaiSCS.Contexts;
using APISenaiSCS.Repositories;

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


        private readonly ICampanhaRepository ctx;

        public CampanhaController(ICampanhaRepository appContext)
        {
            ctx = appContext;
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
                return Ok(ctx.Listar());
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
                return Ok(ctx.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
        


        [HttpPost]
        public IActionResult PostCampanhas([FromForm] campanha campanha, IFormFile arquivo)
        {
            #region
            string[] extensoesPermitidas = { "jpg", "png", "jpeg", "gif" };
            string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

            try { 
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

                ctx.Cadastrar(campanha);
                //wait ctx.SaveChangesAsync();

                return Created("Campanhas", campanha);
            }
            catch (Exception error)
            {
                BadRequest(error);
                throw;
            }
        }

       
    }
}

