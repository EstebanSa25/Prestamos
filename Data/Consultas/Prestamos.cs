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
   public class Prestamos:ConsultClass<PrestamoModelData>
    {
        public async Task<PrestamoModelData> CreatePrestamo(decimal monto,int id_usuario)
        {
            var sql = $"INSERT PRESTAMO OUTPUT INSERTED.* VALUES({monto},{id_usuario},{(int)EstadoPrestamo.Pendiente})";
            bool exito = await Procedimientos.CARGAR_TABLA(datos, sql);
            if (exito && datos.Tables.Count > 0)
            {
                var obj = new PrestamoModelData();
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    obj.ID = row.Field<int>("ID");
                    obj.MONTO = row.Field<decimal>("MONTO");
                    obj.ID_USUARIO = row.Field<int>("ID_USUARIO");
                    obj.ESTADO_ID = (EstadoPrestamo)row.Field<int>("ESTADO_ID");
                }
                return obj;
            }
            else
            {
                return null;
            }
        }
        public async Task<List<PrestamoModelData>> GetAllPrestamo(int? id)
        {
            var sql = $"SELECT p.*,u.EMAIL FROM PRESTAMO p INNER JOIN USUARIO u ON u.ID=p.ID_USUARIO";
            if(id != null && id > 0) {
                sql +=$" where ID_USUARIO={id}";
            }
            bool exito = await Procedimientos.CARGAR_TABLA(datos, sql);
            if (exito && datos.Tables.Count > 0)
            {
                foreach (DataRow row in datos.Tables[0].Rows)
                {
                    var prestamo = new PrestamoModelData();
                    prestamo.ID = row.Field<int>("ID");
                    prestamo.MONTO = row.Field<decimal>("MONTO");
                    prestamo.ID_USUARIO = row.Field<int>("ID_USUARIO");
                    prestamo.ESTADO_ID = (EstadoPrestamo)row.Field<int>("ESTADO_ID");
                    prestamo.EMAIL = row.Field<string>("EMAIL");
                    Data.Add(prestamo);
                }
                return Data;
            }
            else
            {
                return null;
            }
        }
        public async Task<bool> UpdateState(int id,EstadoPrestamo estado)
        {
            var sql = $"UPDATE PRESTAMO SET ESTADO_ID={(int)estado} WHERE ID={id}";
            var exito =  await Procedimientos.CARGAR_TABLA(datos, sql);
            return exito ? true : false;
        }
    }
}
