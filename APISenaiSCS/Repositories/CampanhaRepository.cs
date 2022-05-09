using APISenaiSCS.Context;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APISenaiSCS.Repositories
{
    public class CampanhaRepository : ICampanhaRepository
    {
        private readonly HotspotContext ctx;

        public CampanhaRepository(HotspotContext appContext)
        {
            ctx = appContext;
        }

        public void Atualizar(int IdCampanhas, Campanhas campanhaAtualizada)
        {
            Campanhas campanhaBuscada = ctx.Campanhas.Find(IdCampanhas);


            campanhaBuscada.Imagem = campanhaAtualizada.Imagem;
       

            ctx.Campanhas.Update(campanhaBuscada);
            ctx.SaveChanges();
        }

        public Campanhas BuscarPorId(int IdCampanhas)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(Campanhas novaCampanha)
        {
            ctx.Campanhas.Add(novaCampanha);

            ctx.SaveChanges();
        }

        public void Deletar(int IdCampanhas)
        {
            ctx.Campanhas.Remove(BuscarPorId(IdCampanhas));

            ctx.SaveChanges();
        }

        public List<Campanhas> Listar()
        {
            return ctx.Campanhas.ToList();
        }
    }
}
