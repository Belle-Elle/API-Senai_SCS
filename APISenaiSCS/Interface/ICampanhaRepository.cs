using APISenaiSCS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Interface
{
    public class ICampanhaRepository
    {

        Campanhas Cadastrar(Campanhas campanha);
        Campanhas Alterar(Campanhas campanha);
        void Excluir(Campanhas campanha);
        IEnumerable<Campanhas> Listar();


    }
}
