using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class Conexion
    {
        public static SqlConnection Db = new SqlConnection();
        private const string dbString= "Server=localhost;Database=PrestamosDB;User=sa;Password=pwd;";
        public static async Task CONECTARAsync()
        {
            try
            {
                Db.ConnectionString = dbString;

                if (Db.State != ConnectionState.Open)
                    await Db.OpenAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                throw;
            }
        }

        public static void DESCONECTAR()
        {
            if (Db.State != ConnectionState.Closed)
                Db.Close();
        }
    }

   
}
