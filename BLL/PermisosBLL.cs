using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoTarea6.DAL;
using ProyectoTarea6.Entidades;

namespace ProyectoTarea6.BLL
{
    public class PermisosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                paso = contexto.Roles.Any(e => e.RolID == id);
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
        private static bool Insertar(Permisos permisos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Add(permisos);
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

        private static bool Modificar(Permisos permisos)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(permisos).State = EntityState.Modified;
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

        public static bool Guardar(Permisos permisos)
        {
            if (!Existe(permisos.PermisoID))
                return Insertar(permisos);
            else
                return Modificar(permisos);
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var roles = contexto.Roles.Find(id);

                if (roles != null)
                {
                    contexto.Remove(roles);
                    paso = contexto.SaveChanges() > 0;
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

        public static Permisos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Permisos permisos;

            try
            {
                permisos = contexto.Permisos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return permisos;
        }
        public static List<Permisos> GetPermisos()
        {
            List<Permisos> lista = new List<Permisos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Permisos.ToList();
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
