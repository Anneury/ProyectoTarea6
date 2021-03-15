using Microsoft.EntityFrameworkCore;
using ProyectoTarea6.DAL;
using ProyectoTarea6.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ProyectoTarea6.BLL
{
    public class RolesBLL
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
        private static bool Insertar(Roles roles)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Add(roles);
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

        private static bool Modificar(Roles roles)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Database.ExecuteSqlRaw($"Delete FROM RolesDetalle where RolID={roles.RolID}");
                foreach (var anterior in roles.Detalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(roles).State = EntityState.Modified;
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

        public static bool Guardar(Roles roles)
        {
            if (!Existe(roles.RolID))
                return Insertar(roles);
            else
                return Modificar(roles);
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var rol = contexto.Roles.Find(id);
                if (rol != null)
                {
                    contexto.Entry(rol).State = EntityState.Deleted;
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

        public static Roles Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Roles roles;

            try
            {
                roles = contexto.Roles.Include(e => e.Detalle).Where(p => p.RolID == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return roles;
        }

        public static List<Roles> GetRoles()
        {
            Contexto contexto = new Contexto();
            List<Roles> lista = new List<Roles>();

            try
            {
                lista = contexto.Roles.ToList();
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
        public static List<Roles> GetList(Expression<Func<Roles, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Roles> lista = new List<Roles>();

            try
            {
                lista = contexto.Roles.Where(criterio).ToList();
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
