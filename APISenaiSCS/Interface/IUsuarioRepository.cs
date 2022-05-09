using APISenaiSCS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Interface
{
    interface IUsuarioRepository
    {

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="NIF">E-mail do usuário</param>
        /// <param name="senha">Senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        Usuario Login(string NIF, string senha);

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Prontuarios</returns>
        List<Usuario> Listar();

        /// <summary>
        /// Busca um Usuario através do seu id
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será buscado</param>
        /// <returns>Um Usuario encontrado</returns>
        Usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os dados que serão cadastrados</param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Atualiza um Prontuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioioAtualizado com as novas informações</param>
        void Atualizar(int idUsuario, Usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será deletado</param>
        void Deletar(int idUsuario);
    }
}
