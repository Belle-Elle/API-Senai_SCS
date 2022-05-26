﻿using APISenaiSCS.Domains;
using System.Collections;
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
        /// Busca uma campanha através do ID
        /// </summary>
        /// <param name="id">ID da campanha que será buscada</param>
        /// <returns>Uma campanha sera buscada</returns>
        campanha BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario com os dados que serão cadastrados</param>
        campanha Cadastrar(campanha novaCampanha);

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
