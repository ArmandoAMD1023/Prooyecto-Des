using System;
using System.Collections.Generic;

namespace AccesoADatos.Models;

public partial class Conferencia
{
    public int IdConferencia { get; set; }

    public DateTime? Horario { get; set; }

    public string? TituloConferencia { get; set; }

    public string? Conferencista { get; set; }

    public string? Registro { get; set; }

    public virtual ICollection<Asistencium> Asistencia { get; set; } = new List<Asistencium>();
}
