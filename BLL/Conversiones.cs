using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parcial2_ap2_20180619.BLL
{
    public class Conversiones
    {
        public static int ToInt(string valor)
        {
            int retorno;

            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static double ToDouble(string valor)
        {
            double retorno;

            double.TryParse(valor, out retorno);

            return retorno;
        }
    }
}
