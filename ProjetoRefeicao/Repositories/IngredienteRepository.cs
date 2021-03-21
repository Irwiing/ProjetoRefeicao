using ProjetoRefeicao.Models;
using ProjetoRefeicao.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoRefeicao.Repositories
{
    public class IngredienteRepository : IIngredienteRepository
    {
        private ConnectionDB _conn;

        public bool Insert(Ingrediente newIngrediente)
        {
            bool status = false;
            string sql = $"INSERT INTO TB_INGREDIENTE (descricao) VALUES ('{newIngrediente.Descricao}')";

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Delete(int id)
        {
            bool status = false;
            string sql = $"delete from TB_INGREDIENTE where id = {id} ";

            using (_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public List<Ingrediente> Select()
        {
            string sql = $"SELECT id, descricao FROM TB_INGREDIENTE";

            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData);
            }

        }
        public Ingrediente Select(int id)
        {
            string sql = $"select id, descricao from TB_INGREDIENTE where id = {id}";

            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToObject(returnData);
            }
        }
        public List<Ingrediente> SelectAllFromPizza(int id)
        {
            string sql = $"select i.id, i.descricao from TB_PEDIDO_PIZZA pp join TB_INGREDIENTE i on i.id = pp.id_ingrediente where id_pizza = {id}";

            using (_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformSQLReaderToList(returnData);
            }
        }
        private List<Ingrediente> TransformSQLReaderToList(SqlDataReader returnData)
        {
            var list = new List<Ingrediente>();

            while (returnData.Read())
            {
                var item = new Ingrediente()
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                };

                list.Add(item);
            }
            return list;
        }

        private Ingrediente TransformSQLReaderToObject(SqlDataReader returnData)
        {
            if (returnData.Read())
            {
                return new Ingrediente
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString()
                };

            }

            return null;
        }
    }
}