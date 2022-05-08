using APISenaiSCS.Context;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly HotspotContext ctx;

        public UsuarioRepository(HotspotContext appContext)
        {
            ctx = appContext;
        }

        public Usuario Login(string NIF, string senha)
        {

            var usuario = ctx.Usuarios.FirstOrDefault(u => u.NIF == NIF);


            if (usuario != null)
            {
                return usuario;
            }


            return null;

        }
    }
}
