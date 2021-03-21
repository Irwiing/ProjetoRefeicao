using ProjetoRefeicao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRefeicao.Repositories
{
    public interface IIngredienteRepository
    {
        bool Insert(Ingrediente newIngrediente);

        List<Ingrediente> Select();
        Ingrediente Select(int id);

        bool Delete(int id);


        List<Ingrediente> SelectAllFromPizza(int id);
    }
}
