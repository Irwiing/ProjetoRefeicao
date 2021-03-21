using ProjetoRefeicao.Models;
using ProjetoRefeicao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace ProjetoRefeicao.Controllers
{
    public class PizzaController : ApiController
    {
        private PizzaRepository _pizzaRepository;
        public PizzaController()
        {
            _pizzaRepository = new PizzaRepository();
        }

        public IEnumerable<Pizza> Get()
        {
            return _pizzaRepository.Select();
        }

        public bool Post([FromBody] Pizza pizza)
        {
            return _pizzaRepository.Insert(pizza);
        }
        public Pizza Get([FromUri] int id)
        {
            return _pizzaRepository.Select(id);
        }

        public bool Delete([FromUri] int id)
        {
            return _pizzaRepository.Delete(id);
        }

    }
}