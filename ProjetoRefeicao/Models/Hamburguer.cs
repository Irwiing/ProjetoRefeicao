﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoRefeicao.Models
{
    public class Hamburguer : Lanche
    {
        public List<Ingrediente> Ingredientes { get; set; }
    }
}