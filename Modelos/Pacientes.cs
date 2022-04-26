using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Modelos;

public class Pacientes
{
    public string Nombre { get; set; }
    public string Identidad { get; set; }
    public string FechaNacimiento { get; set; }
    public string Sexo { get; set; }
    public string NumeroTelefono { get; set; }

    public string TipodeSangre { get; set; }

}
