using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_ap2_20180619.Models
{
    public class CobrosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int CobroId { get; set; }
        public double Cobrado { get; set; }
        public bool Pagado { get; set; }
        public int VentaId { get; set; }
        public virtual Ventas Venta { get; set; }
    }
}
