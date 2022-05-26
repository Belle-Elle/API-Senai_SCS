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
       private readonly APISnaiSCSContext ctx;

        public CampanhaRepository(APISnaiSCSContext appContext)
        {
            ctx = appContext;
        }

        public void Atualizar(int Id, campanha campanhaAtualizada)
        {
            campanha campanhaBuscada = ctx.campanhas.Find(Id);


            campanhaBuscada.imagem = campanhaAtualizada.imagem;


            ctx.campanhas.Update(campanhaBuscada);
            ctx.SaveChanges();
        }

        public campanha BuscarPorId(int id)
        {
            return ctx.campanhas.FirstOrDefault(e => e.id == id);
        }

        public campanha Cadastrar(campanha novaCampanha)
        {
            ctx.campanhas.Add(novaCampanha);
            ctx.SaveChangesAsync();
            return novaCampanha;
            

        }

        public void Deletar(int id)
        {
            ctx.campanhas.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<campanha> Listar()
        {
            return ctx.campanhas.ToList();
        }

    }
}