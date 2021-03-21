using ProjetoRefeicao.Models;
using ProjetoRefeicao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjetoRefeicao.Controllers
{
    public class IngredientesController : ApiController
    {
        private IngredienteRepository _ingredienteRepository;
        public IngredientesController()
        {
            _ingredienteRepository = new IngredienteRepository();
        }

        public IEnumerable<Ingrediente> Get()
        {
            return _ingredienteRepository.Select();
        }

        public Ingrediente Get([FromUri] int id)
        {
            return _ingredienteRepository.Select(id);
        }

        public bool Delete([FromUri] int id)
        {
            return _ingredienteRepository.Delete(id);
        }

        public bool Post([FromBody] Ingrediente ingrediente)
        {
            return _ingredienteRepository.Insert(ingrediente);
        }
    }
}
