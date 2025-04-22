using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
    public static class Procedimientos
    {
        internal static async Task<bool> CARGAR_TABLA(DataSet tablaTemporal, string sql)
        {
            try
            {
                await Conexion.CONECTARAsync();

                using (var comando = new SqlCommand(sql, Conexion.Db))
                using (var lector = await comando.ExecuteReaderAsync())
                {
                    var tabla = new DataTable();
                    tabla.Load(lector);
                    tablaTemporal.Tables.Clear();
                    tablaTemporal.Tables.Add(tabla);
                }

                Conexion.DESCONECTAR();
                return true;
            }
            catch (Exception)
            {
                Conexion.DESCONECTAR();
                return false;
            }
        }
    }
}
