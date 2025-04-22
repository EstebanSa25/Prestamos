using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class PrestamoModelData
    {
        public int ID { get; set; }
        public decimal MONTO { get; set; }
        public int ID_USUARIO { get; set; }
        public EstadoPrestamo ESTADO_ID { get; set; } = EstadoPrestamo.Pendiente;
        public string EMAIL { get; set; }
    }
    public enum EstadoPrestamo
    {
        Pendiente=1,
        Aprobado=2,
        Rechazado=3
    }
}
