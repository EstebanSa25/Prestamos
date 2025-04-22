using Config;
using Data.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Consultas
{
   public class Login: ConsultClass<UsuarioModel>
    {
        public Login()
        {
            
        }
        public async Task<UsuarioModel> ValidateLogin (string email,string pwd)
        {

            string sql = $"SELECT * FROM USUARIO where EMAIL='{email}'";
            bool exito = await Procedimientos.CARGAR_TABLA(datos, sql);
            if (exito && datos.Tables.Count > 0 && datos.Tables[0].Rows.Count > 0)
            {
                string passwordDB="";
                var usuario = new UsuarioModel();
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    usuario.ID = Convert.ToInt32(row["ID"]);
                    usuario.EMAIL = row["EMAIL"].ToString();
                    usuario.ROL_ID = (ROL) Convert.ToInt32(row["ROL_ID"]);
                    passwordDB = row["PASS"].ToString();
                }
                var pwdHas = BcryptAdapter.Compare(pwd, passwordDB);
                if (pwdHas)
                {
                    return usuario;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
    }
}
