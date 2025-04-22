using Data.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Consultas
{
    public class UsuarioConsult: ConsultClass<UsuarioModel>
    {
         public DataSet datos = new DataSet();

        public List<UsuarioModel> Data = new List<UsuarioModel>();


        public async Task GetAllUsers()
        {
            string sql = "SELECT * FROM USUARIO";

            bool exito = await Procedimientos.CARGAR_TABLA(datos, sql);

            if (exito && datos.Tables.Count > 0)
            {
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    var usuario = new UsuarioModel();
                    usuario.ID = Convert.ToInt32(row["ID"]);
                    usuario.EMAIL = row["EMAIL"].ToString();
                    usuario.ROL_ID = (ROL)Convert.ToInt32(row["ROL_ID"]);
                    Data.Add(usuario);
                }
            }
            else
            {
                Console.WriteLine("Error al cargar datos.");
            }
        }
    }
}
