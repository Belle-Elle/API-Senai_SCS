using System;
using System.Collections.Generic;

#nullable disable

namespace APISenaiSCS.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nif { get; set; }
        public string Senha { get; set; }
    }
}
