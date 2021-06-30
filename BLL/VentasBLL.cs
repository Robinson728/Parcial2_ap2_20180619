using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parcial2_ap2_20180619.DAL;
using Parcial2_ap2_20180619.Models;

namespace Parcial2_ap2_20180619.BLL
{
    public class VentasBLL
    {
        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas ventas;

            try
            {
                ventas = contexto.Ventas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ventas;
        }

        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Ventas> lista = new List<Ventas>();

            try
            {
                lista = contexto.Ventas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
