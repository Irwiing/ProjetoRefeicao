using ProjetoRefeicao.Models;
using ProjetoRefeicao.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoRefeicao.Repositories
{
    public class PizzaRepository : IPizzaRepository
    {
        private ConnectionDB _conn;
        private IngredienteRepository _ingredienteRepository;
        public PizzaRepository()
        {
            _ingredienteRepository = new IngredienteRepository();
        }

        public bool Delete(int id)
        {
            bool status = false;
            string sql = $"delete from TB_PIZZA where id = {id} ";

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Insert(Pizza newPizza)
        {
            string sqlPizza = $"INSERT INTO TB_PIZZA (descricao, valor) output INSERTED.ID VALUES ('{newPizza.Descricao}', '{newPizza.Valor}')";
            var status = false;
            using (_conn = new ConnectionDB())
            {
                var idPizza = _conn.ExecQueryReturnId(sqlPizza);

                newPizza.Ingredientes.ForEach(ingrediente =>
                {
                    string sql = $"INSERT INTO TB_PEDIDO_PIZZA (id_pizza, id_ingrediente) VALUES ('{idPizza}', '{ingrediente.Id}')";
                    status = _conn.ExecQuery(sql);
                });
            };
            return status;
        }

        public List<Pizza> Select()
        {
            string sqlPizza = $"SELECT id, descricao, valor FROM TB_PIZZA";

            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sqlPizza);
                var pizzas = TransformSQLReaderToList(returnData);

                pizzas.ForEach(pizza =>
                {
                    pizza.Ingredientes = _ingredienteRepository.SelectAllFromPizza(pizza.Id);

                });

                return pizzas;
            }

        }

        public Pizza Select(int id)
        {
            string sql = $"select id, descricao, valor from TB_PIZZA where id = {id}";

            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                var pizza = TransformSQLReaderToObject(returnData);

                pizza.Ingredientes = _ingredienteRepository.SelectAllFromPizza(pizza.Id);
                return pizza;
            }
        }

        private List<Pizza> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Pizza>();

            while (returnData.Read())
            {
                var item = new Pizza()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Valor = decimal.Parse(returnData["valor"].ToString())
                };

                list.Add(item);
            }
            return list;
        }

        private Pizza TransformSQLReaderToObject(SqlDataReader returnData)
        {
            if (returnData.Read())
            {
                return new Pizza
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Valor = decimal.Parse(returnData["valor"].ToString())
                };

            }

            return null;
        }
    }
}