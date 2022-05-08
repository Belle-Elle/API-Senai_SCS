using APISenaiSCS.Context;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Repositories
{
    public class CampanhaRepository : ICampanhaRepository 
    {
        private readonly HotspotContext ctx;

        public CampanhaRepository(HotspotContext appContext)
        {
            ctx = appContext;
        }

        public Campanhas Alterar(Campanhas equipamento)
        {
            ctx.Entry(equipamento).State = EntityState.Modified;
            ctx.SaveChangesAsync();
            return equipamento;
        }

        public Campanhas Cadastrar(Campanhas campanha)
        {
            ctx.Campanhas.Add(campanha);
            ctx.SaveChangesAsync();

            return campanha;
        }

        public void Excluir(Campanhas campanha)
            
        {
            ctx.Campanhas.Remove(campanha);
            ctx.SaveChangesAsync();
        }

        public IEnumerable<Campanhas> Listar()
        {
            return ctx.Campanhas.ToList();
        }



    }
}
