using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoRefeicao.Models
{
    public abstract class Refeicao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}