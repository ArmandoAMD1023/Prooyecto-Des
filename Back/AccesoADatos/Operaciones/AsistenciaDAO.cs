using AccesoADatos.Context;
using AccesoADatos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoADatos.Operaciones
{
    public class AsistenciaDAO
    {
        private readonly ConferenciasContext contexto;

        public AsistenciaDAO()
        {
            contexto = new ConferenciasContext();
        }

        // Método para seleccionar todas las asistencias
        public List<Asistencium> SeleccionarTodas()
        {
            return contexto.Asistencia.ToList();
        }

        public List<Asistencium> SeleccionarTodasConDetalles()
        {
            return contexto.Asistencia
                .Include(a => a.IdConferenciaNavigation) // Incluye la información de la conferencia
                .Include(a => a.IdParticipanteNavigation) // Incluye la información del participante
                .ToList();
        }


        // Método para seleccionar una asistencia en específico por id
        public Asistencium Seleccionar(int id)
        {
            return contexto.Asistencia.Find(id);
        }

        // Método para insertar una nueva asistencia
        public bool Insertar(int idParticipante, int idConferencia, bool confirmacionAsistencia)
        {
            try
            {
                Asistencium asistencia = new Asistencium
                {
                    IdParticipante = idParticipante,
                    IdConferencia = idConferencia,
                    ConfirmacionAsistencia = confirmacionAsistencia
                };

                contexto.Asistencia.Add(asistencia);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar asistencia: {ex.Message}");
                return false;
            }
        }
    }
}
