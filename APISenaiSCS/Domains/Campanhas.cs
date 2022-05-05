using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Domains
{
    public class Campanhas
    {

        [Key]
        public int Id { get; set; }
        public string Imagem { get; set; }
        
    }
}
