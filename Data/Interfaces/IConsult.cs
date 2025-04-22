using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public class ConsultClass<T>
    {
        public DataSet datos = new DataSet();
        public  List<T> Data { get; set; } = new List<T>();
        public Dictionary<string, bool> ListaNombreParametros { get; set; } = new Dictionary<string, bool>();
       public List<string> ListaValoresConfig { get; set; } = new List<string>();
    }
}
