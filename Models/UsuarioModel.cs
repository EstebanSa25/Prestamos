using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class UsuarioModel
    {
        public int ID { get; set; }
        public string EMAIL { get; set; }
        public ROL ROL_ID { get; set; }
    }
    public enum ROL
    {
        USUARIO = 1,
        ADMINISTRADOR = 2
    }
}
