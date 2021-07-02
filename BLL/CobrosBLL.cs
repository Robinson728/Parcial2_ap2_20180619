using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parcial2_ap2_20180619.Models;
using Parcial2_ap2_20180619.DAL;

namespace Parcial2_ap2_20180619.BLL
{
    public class CobrosBLL
    {
        public static bool Guardar(Cobros cobros)
        {
            return Insertar(cobros);
        }

        private static bool Insertar(Cobros cobros)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                foreach (var item in cobros.Detalle)
                {
                    item.Venta = contexto.Ventas.Find(item.VentaId);
                    item.Venta.Balance -= item.Cobrado;
                    VentasBLL.Guardar(item.Venta);
                }

                contexto.Cobros.Add(cobros);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var eliminado = Buscar(id);

                if (eliminado != null)
                {
                    contexto.Cobros.Remove(eliminado);
                    paso = contexto.SaveChanges() > 0;

                    if (paso)
                    {
                        foreach (var cobroDetalle in eliminado.Detalle)
                        {
                            var ventas = VentasBLL.Buscar(cobroDetalle.VentaId);
                            if (ventas != null)
                            {
                                ventas.Balance += cobroDetalle.Cobrado;
                                VentasBLL.Guardar(ventas);
                            }
                        }
                    }
                }                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        public static Cobros Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Cobros cobros;

            try
            {
                cobros = contexto.Cobros
                    .Include(r => r.Detalle)
                    .ThenInclude(r => r.Venta)
                    .Include(r => r.Cliente)
                    .Where(r => r.CobroId == id)
                    .SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return cobros;
        }

        public static List<Cobros> GetList(Expression<Func<Cobros, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Cobros> lista = new List<Cobros>();

            try
            {
                lista = contexto.Cobros.Where(criterio).ToList();
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
