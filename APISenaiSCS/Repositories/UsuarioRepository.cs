using APISenaiSCS.Contexts;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using System.Collections.Generic;
using System.Linq;

namespace APISenaiSCS.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        APISnaiSCSContext ctx = new APISnaiSCSContext();

        public void Atualizar(int idUsuario, usuario usuarioAtualizado)
        {
            usuario usuarioBuscado = ctx.usuarios.Find(idUsuario);


            usuarioBuscado.senha = usuarioAtualizado.senha;

            ctx.usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();

        }

        public usuario BuscarPorId(int idUsuario)
        {
            return ctx.usuarios
                .Select(u => new usuario()
                {
                    id = u.id,
                    NIF = u.NIF,
                })
                .FirstOrDefault(u => u.id == idUsuario);
        }

        public void Cadastrar(usuario novoUsuario)
        {
            ctx.usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<usuario> Listar()
        {
            return ctx.usuarios.ToList();
        }

        public usuario Login(string NIF, string senha)
        {
            return ctx.usuarios.FirstOrDefault(e => e.NIF == NIF && e.senha == senha);
        }
    }
}
