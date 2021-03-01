using System;
using ProyectoTarea6.Entidades;
using ProyectoTarea6.DAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProyectoTarea6.BLL
{
    public class UsuariosBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                paso = contexto.Usuarios.Any(e => e.UsuarioID == id);
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

        private static bool Insertar(Usuarios usuario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Add(usuario);
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

        private static bool Modificar(Usuarios usuario)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.Entry(usuario).State = EntityState.Modified;
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
        public static bool Guardar(Usuarios usuario)
        {
            if (Existe(usuario.UsuarioID))
                return Modificar(usuario);
            else
                return Insertar(usuario);
        }

        public static bool Eliminar(int id)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                var usuario = contexto.Usuarios.Find(id);

                if (usuario != null)
                {
                    contexto.Remove(usuario);
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

        public static Usuarios Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Usuarios usuario;

            try
            {
                usuario = contexto.Usuarios.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return usuario;
        }

        public static bool ExisteAlias(string alias)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Usuarios.Any(e => e.AliasUsuario == alias);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
    }
}
