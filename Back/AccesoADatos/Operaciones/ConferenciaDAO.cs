using AccesoADatos.Context;
using AccesoADatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccesoADatos.Operaciones
{
    public class ConferenciaDAO
    {
        private readonly ConferenciasContext contexto;

        public ConferenciaDAO()
        {
            contexto = new ConferenciasContext();
        }

        // Método para seleccionar todas las conferencias
        public List<Conferencia> SeleccionarTodas()
        {
            return contexto.Conferencias.ToList();
        }

        // Método para insertar una nueva conferencia
        public bool Insertar(DateTime horario, string tituloConferencia, string conferencista, string registro)
        {
            try
            {
                Conferencia conferencia = new Conferencia
                {
                    Horario = horario,
                    TituloConferencia = tituloConferencia,
                    Conferencista = conferencista,
                    Registro = registro
                };

                contexto.Conferencias.Add(conferencia);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar conferencia: {ex.Message}");
                return false;
            }
        }
    }
}
