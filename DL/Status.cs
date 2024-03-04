using System;
using System.Collections.Generic;

namespace DL;

public partial class Status
{
    public int IdStatus { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<UsuarioTareaStatus> UsuarioTareaStatuses { get; set; } = new List<UsuarioTareaStatus>();
}
