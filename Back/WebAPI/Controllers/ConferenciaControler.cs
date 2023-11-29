using Microsoft.AspNetCore.Mvc;
using AccesoADatos.Models;
using AccesoADatos.Operaciones;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ConferenciaController : ControllerBase
    {
        private ConferenciaDAO conferenciaDAO = new ConferenciaDAO();

        [HttpGet("conferencias")]
        public List<Conferencia> ObtenerTodasLasConferencias()
        {
            return conferenciaDAO.SeleccionarTodas();
        }

        [HttpPost("conferencia")]
        public ActionResult<bool> InsertarConferencia([FromBody] Conferencia conferencia)
        {
            try
            {
                bool resultado = conferenciaDAO.Insertar(
                    (DateTime)conferencia.Horario,
                    conferencia.TituloConferencia,
                    conferencia.Conferencista,
                    conferencia.Registro
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
