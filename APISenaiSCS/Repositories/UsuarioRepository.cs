using Microsoft.EntityFrameworkCore;
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
                    NIF = u.NIF,
                    
                   
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
            return ctx.Usuarios.FirstOrDefault(e => e.NIF == NIF && e.Senha == senha);
        }
    }
}
