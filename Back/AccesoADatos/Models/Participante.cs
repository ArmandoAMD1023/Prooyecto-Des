using System;
using System.Collections.Generic;

namespace AccesoADatos.Models;

public partial class Participante
{
    public int IdParticipante { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public string? UsuarioTwitter { get; set; }

    public string? Avatar { get; set; }

    public string? Ocupacion { get; set; }

    public bool AceptoTerminos { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();
}
