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
        private ICampanhaRepository _campanhaRepository { get; set; }


        //public CampanhaController(ICampanhaRepository appContext)
        //{
        //    ctx = appContext;
        //}

        public CampanhaController()
        {
           _campanhaRepository  = new CampanhaRepository();
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
                return Ok(_campanhaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }



        [HttpPost]
        public IActionResult PostCampanhas([FromForm] Campanha campanha, IFormFile file)
        {

            try
            {
                #region Upload da Imagem com extensões permitidas apenas
                if (file == null)
                    return BadRequest("É necessário enviar um arquivo de imagem válido!");

                string[] AllowedExtensions = { "jpg", "png", "jpeg", "gif" };
                string UploadResult = Upload.UploadFile(file, AllowedExtensions);

                if (UploadResult == "")
                {
                    return BadRequest("Arquivo não encontrado");
                }

                if (UploadResult == "Extensão não permitida")
                {
                    return BadRequest("Extensão de arquivo não permitida");
                }

                campanha.Imagem = UploadResult;
                #endregion

                _campanhaRepository.Cadastrar(campanha);
                return Created("Campanha", campanha);
            }

            catch (Exception error)
            {
                BadRequest(error);
                throw;
            }

        }

    }
        
}

