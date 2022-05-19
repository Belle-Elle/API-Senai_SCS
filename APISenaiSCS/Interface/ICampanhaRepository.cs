using APISenaiSCS.Domains;
using System.Collections.Generic;

namespace APISenaiSCS.Interface
{
    interface ICampanhaRepository
    {

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Uma lista de Prontuarios</returns>
        List<campanha> Listar();


        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os dados que serão cadastrados</param>
        void Cadastrar(campanha novaCampanha);

        /// <summary>
        /// Atualiza um Prontuario existente
        /// </summary>
        /// <param name="idUsuario">ID do Usuario que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto usuarioioAtualizado com as novas informações</param>
        void Atualizar(int idCampanhas, campanha campanhaAtualizada);

        /// <summary>
        /// Deleta um Usuario existente
        /// </summary>
        /// <param name="IdCampanhas">ID do Usuario que será deletado</param>
        void Deletar(int idCampanhas);


        //Campanhas Cadastrar(Campanhas campanha);
        // Campanhas Alterar(Campanhas campanha);
        // void Excluir(Campanhas campanha);
        // IEnumerable<Campanhas> Listar(Campanhas campanha);


    }
}
