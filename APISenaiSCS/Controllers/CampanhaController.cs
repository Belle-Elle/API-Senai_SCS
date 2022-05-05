using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Controllers
{
    public class CampanhaController
    {

        Equipamento Cadastrar(Equipamento equipamento);
        Equipamento Alterar(Equipamento equipamento);
        void Excluir(Equipamento equipamento);
        IEnumerable<Equipamento> Listar();
        

    }
}
