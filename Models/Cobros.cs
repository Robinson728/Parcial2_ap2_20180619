using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_ap2_20180619.Models
{
    public class Cobros
    {
        [Key]
        public int CobroId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public virtual Clientes Cliente { get; set; }
        public double Totales { get; set; }
        public double Cobrado { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("CobroId")]
        public virtual List<CobrosDetalle> Detalle { get; set; }

        public Cobros()
        {
            Fecha = DateTime.Now;
            Detalle = new List<CobrosDetalle>();
        }
    }
}
