using APISenaiSCS.Domains;
using System.Collections.Generic;

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
        usuario Login(string NIF, string senha);

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Prontuarios</returns>
        List<usuario> Listar();

        /// <summary>
        /// Busca um Usuario através do seu id
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será buscado</param>
        /// <returns>Um Usuario encontrado</returns>
        usuario BuscarPorId(int idUsuario);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os dados que serão cadastrados</param>
        void Cadastrar(usuario novoUsuario);

        /// <summary>
        /// Atualiza um Prontuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioioAtualizado com as novas informações</param>
        void Atualizar(int idUsuario, usuario usuarioAtualizado);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será deletado</param>
        void Deletar(int idUsuario);

    }
}