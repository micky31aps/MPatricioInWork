using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Agenda
    {
        public int IdTelefono { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public List<object> Agendas { get; set; }
    }
}
