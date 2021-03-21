using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoRefeicao.Models
{
    public abstract class Lanche : Refeicao
    {
        public string Nome { get; set; }
        public string TipoCarne { get; set; }
        public bool Salada { get; set; }
        public int QtdCarnes { get; set; }
    }
}