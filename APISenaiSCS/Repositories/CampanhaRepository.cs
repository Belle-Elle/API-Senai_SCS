using APISenaiSCS.Contexts;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace APISenaiSCS.Repositories
{
    public class CampanhaRepository : ICampanhaRepository
    {
        CampanhaContext ctx = new CampanhaContext();

        public void Atualizar(int idCampanhas, Campanha campanhaAtualizada)
        {
            Campanha campanhaBuscada = ctx.Campanhas.Find(idCampanhas);


            campanhaBuscada.Imagem = campanhaAtualizada.Imagem;


            ctx.Campanhas.Update(campanhaBuscada);
            ctx.SaveChanges();
        }

        public Campanha BuscarPorId(int idCampanhas)
        {
            return ctx.Campanhas.FirstOrDefault(e => e.Id == idCampanhas);
        }

        public Campanha Cadastrar(Campanha novaCampanha)
        {
            ctx.Campanhas.Add(novaCampanha);
            ctx.SaveChangesAsync();
            return novaCampanha;
        }

        public void Deletar(int idCampanhas)
        {
            ctx.Campanhas.Remove(BuscarPorId(idCampanhas));

            ctx.SaveChanges();
        }

        public List<Campanha> Listar()
        {
            return ctx.Campanhas.ToList();
        }
    }
}