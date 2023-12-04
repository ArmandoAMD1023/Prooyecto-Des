using Microsoft.AspNetCore.Mvc;
using AccesoADatos.Models;
using AccesoADatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ParticipanteController : ControllerBase
    {
        private ConferenciasDAO conferenciasDAO = new ConferenciasDAO();

        [HttpGet("participantes")]
        public List<Participante> ObtenerTodosLosParticipantes()
        {
            return conferenciasDAO.SeleccionarTodos();
        }

        [HttpGet("participantes/informacion-basica")]
        public List<Participante> ObtenerInformacionBasicaParticipantes()
        {
            return conferenciasDAO.ObtenerInformacionBasicaParticipantes();
        }

        [HttpPost("participante")]
        public ActionResult<bool> InsertarParticipante([FromBody] Participante participante)
        {
            try
            {
                bool resultado = conferenciasDAO.Insertar(
                    participante.Nombre,
                    participante.Apellidos,
                    participante.Email,
                    participante.UsuarioTwitter,
                    participante.Avatar,
                    participante.Ocupacion,
                    participante.AceptoTerminos
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
        [HttpGet("participante/{id}")]
        public ActionResult<Participante> Seleccionar(int id)
        {
            var participante = conferenciasDAO.Seleccionar(id);

            if (participante == null)
            {
                return NotFound(); // Devuelve un código 404 si no se encuentra el asistente
            }

            return Ok(participante);
        }

        [HttpPut("participante/{id}")]
        public ActionResult<bool> ActualizarParticipante(int id, [FromBody] Participante participante)
        {
            try
            {
                bool resultado = conferenciasDAO.Actualizar(
                    id,
                    participante.Nombre,
                    participante.Apellidos,
                    participante.Email,
                    participante.UsuarioTwitter,
                    participante.Avatar,
                    participante.Ocupacion 
                );

                if (resultado)
                {
                    return Ok(true); // 200 OK
                }
                else
                {
                    return NotFound(false); // 404 Not Found
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // 500 Internal Server Error
            }
        }
    }
}
