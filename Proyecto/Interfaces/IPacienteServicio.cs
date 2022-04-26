using Modelos;

namespace Proyecto.Interfaces;

public interface IPacienteServicio
{
    Task<bool> Enviar(Pacientes paciente);
    Task<IEnumerable<Pacientes>> GetList();

}