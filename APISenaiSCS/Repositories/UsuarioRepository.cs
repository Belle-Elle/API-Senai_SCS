using APISenaiSCS.Contexts;
using APISenaiSCS.Domains;
using APISenaiSCS.Interface;
using System.Collections.Generic;
using System.Linq;

namespace APISenaiSCS.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        CampanhaContext ctx = new CampanhaContext();

        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuarios.Find(idUsuario);


            usuarioBuscado.Senha = usuarioAtualizado.Senha;

            ctx.Usuarios.Update(usuarioBuscado);
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
                return ctx.Usuarios
                 .Select(u => new Usuario()
                 {
                     Id = u.Id,
                     Nif = u.Nif,
                 })
                 .FirstOrDefault(u => u.Id == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int idUsuario)
        {
            ctx.Usuarios.Remove(BuscarPorId(idUsuario));

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string NIF, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Nif == NIF && e.Senha == senha);
        }
    }
}
