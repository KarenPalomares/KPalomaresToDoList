using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class UsuarioTarea
    {
        public int IdUsuario { get; set; }
        public int IdTarea { get; set; }
       
        public ML.Tarea tarea { get; set; }
        public ML.Usuario usuario { get; set; }
    }
}
