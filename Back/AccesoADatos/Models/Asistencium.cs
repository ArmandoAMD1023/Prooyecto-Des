using System;
using System.Collections.Generic;

namespace AccesoADatos.Models;

public partial class Asistencium
{
    public int IdAsistencia { get; set; }

    public int IdParticipante { get; set; }

    public int IdConferencia { get; set; }

    public bool ConfirmacionAsistencia { get; set; }

    public virtual Conferencia? IdConferenciaNavigation { get; set; }

    public virtual Participante? IdParticipanteNavigation { get; set; }
}
