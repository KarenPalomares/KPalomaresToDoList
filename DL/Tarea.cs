using System;
using System.Collections.Generic;

namespace DL;

public partial class Tarea
{
    public int IdTarea { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaDeVencimiento { get; set; }

    public virtual ICollection<UsuarioTareaStatus> UsuarioTareaStatuses { get; set; } = new List<UsuarioTareaStatus>();
}
