using ProjetoRefeicao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRefeicao.Repositories
{
    interface IPizzaRepository
    {
        bool Insert(Pizza newPizza);

        List<Pizza> Select();
                
        Pizza Select(int id);

        bool Delete(int id);
    }
}
