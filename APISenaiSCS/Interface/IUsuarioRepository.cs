﻿using APISenaiSCS.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APISenaiSCS.Interface
{
    public class IUsuarioRepository
    {

        Usuario Login(string NIF, string senha);

    }
}