using Microsoft.AspNetCore.Mvc;
using AccesoADatos.Models;
using AccesoADatos.Operaciones;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private AsistenciaDAO asistenciaDAO = new AsistenciaDAO();

        [HttpGet("asistencias")]
        public List<Asistencium> ObtenerTodasLasAsistencias()
        {
            return asistenciaDAO.SeleccionarTodas();
        }

        [HttpGet("asistenciasDetalladas")]
        public ActionResult<IEnumerable<Asistencium>> ObtenerTodasLasAsistenciasConDetalles()
        {
            try
            {
                var asistencias = asistenciaDAO.SeleccionarTodasConDetalles();

                var jsonOptions = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    // ... otras opciones según sea necesario
                };

                var jsonResult = JsonSerializer.Serialize(asistencias, jsonOptions);

                return Content(jsonResult, "application/json");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("asistencia/{id}")]
        public ActionResult<Asistencium> ObtenerAsistenciaPorId(int id)
        {
            var asistencia = asistenciaDAO.Seleccionar(id);

            if (asistencia != null)
            {
                return Ok(asistencia); // 200 OK
            }
            else
            {
                return NotFound(); // 404 Not Found
            }
        }

        [HttpPost("asistencia")]
        public ActionResult<bool> InsertarAsistencia([FromBody] Asistencium asistencia)
        {
            try
            {
                bool resultado = asistenciaDAO.Insertar(
                    asistencia.IdParticipante,
                    asistencia.IdConferencia,
                    asistencia.ConfirmacionAsistencia
                );

                if (resultado)
                {
                    return Ok(true); // 200 OK
                }
                else
                {
                    return BadRequest(false); // 400 Bad Request
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500 Internal Server Error
            }
        }
    }
}
