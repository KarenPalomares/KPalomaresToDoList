using System;
using System.Collections.Generic;

namespace DL;

public partial class UsuarioTareaStatus
{
    public int IdUsuario { get; set; }

    public int IdStatus { get; set; }

    public int IdTarea { get; set; }

    public virtual Status IdStatusNavigation { get; set; } = null!;

    public virtual Tarea IdTareaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
