using APISenaiSCS.Contexts;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using System.Collections.Generic;
using System.Linq;

namespace APISenaiSCS.Repositories
{
    public class CampanhaRepository : ICampanhaRepository
    {
        APISnaiSCSContext ctx = new APISnaiSCSContext();

        public CampanhaRepository(APISnaiSCSContext appContext)
        {
            ctx = appContext;
        }

        public void Atualizar(int IdCampanhas, campanha campanhaAtualizada)
        {
            campanha campanhaBuscada = ctx.campanhas.Find(IdCampanhas);


            campanhaBuscada.imagem = campanhaAtualizada.imagem;


            ctx.campanhas.Update(campanhaBuscada);
            ctx.SaveChanges();
        }

        public campanha BuscarPorId(int idCampanhas)
        {
            throw new System.NotImplementedException();
        }

        public void Cadastrar(campanha novaCampanha)
        {
            ctx.campanhas.Add(novaCampanha);

            ctx.SaveChanges();
        }

        public void Deletar(int idCampanhas)
        {
            ctx.campanhas.Remove(BuscarPorId(idCampanhas));

            ctx.SaveChanges();
        }

        public List<campanha> Listar()
        {
            return ctx.campanhas.ToList();
        }

    }
}