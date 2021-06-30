using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Parcial2_ap2_20180619.DAL;
using Parcial2_ap2_20180619.Models;

namespace Parcial2_ap2_20180619.BLL
{
    public class ClientesBLL
    {
        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes clientes;

            try
            {
                clientes = contexto.Clientes.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Clientes> lista = new List<Clientes>();

            try
            {
                lista = contexto.Clientes.Where(criterio).ToList();
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
