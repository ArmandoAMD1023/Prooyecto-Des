using AccesoADatos.Context;
using AccesoADatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoADatos.Operaciones
{
    public class ConferenciasDAO
    {
        private readonly ConferenciasContext contexto;

        public ConferenciasDAO()
        {
            contexto = new ConferenciasContext();
        }

        // Método para seleccionar todos los participantes
        public List<Participante> SeleccionarTodos()
        {
            return contexto.Participantes.ToList();
        }
        public Participante Seleccionar(int id)
        {
            var participante = contexto.Participantes.Find(id);

            if (participante == null)
            {
                return null; // Devuelve un código 404 si no se encuentra el asistente
            }
            return participante;
        }

        public List<Participante> ObtenerInformacionBasicaParticipantes()
        {
            var informacionBasica = contexto.Participantes
                .Select(p => new Participante
                {
                    Nombre = p.Nombre,
                    Apellidos = p.Apellidos,
                    UsuarioTwitter = p.UsuarioTwitter,
                    Avatar = p.Avatar,
                    Ocupacion = p.Ocupacion
                })
                .ToList();

            return informacionBasica;
        }

        // Método para insertar un nuevo participante
        public bool Insertar(string nombre, string apellidos, string email, string usuarioTwitter, string avatar, string ocupacion, bool aceptoTerminos)
        {
            try
            {
                Participante participante = new Participante
                {
                    Nombre = nombre,
                    Apellidos = apellidos,
                    Email = email,
                    UsuarioTwitter = usuarioTwitter,
                    Avatar = avatar,
                    Ocupacion = ocupacion,
                    AceptoTerminos = aceptoTerminos
                };

                contexto.Participantes.Add(participante);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar participante: {ex.Message}");
                return false;
            }
        }

        // Método para actualizar un participante existente, modificando solo ciertos campos
        public bool Actualizar(int id, string nombre, string apellidos, string email, string usuarioTwitter, string avatar)
        {
            try
            {
                var participante = contexto.Participantes.Find(id);
                if (participante == null)
                {
                    return false; // Participante no encontrado
                }

                participante.Nombre = nombre ?? participante.Nombre; // Solo actualiza si el nuevo valor no es nulo
                participante.Apellidos = apellidos ?? participante.Apellidos;
                participante.Email = email ?? participante.Email;
                participante.UsuarioTwitter = usuarioTwitter ?? participante.UsuarioTwitter;
                participante.Avatar = avatar ?? participante.Avatar;

                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar participante: {ex.Message}");
                return false;
            }
        }
    }
}
