using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoRefeicao.Models
{
    public class Pizza : Refeicao
    {
        public List<Ingrediente> Ingredientes { get; set; }
    }
}