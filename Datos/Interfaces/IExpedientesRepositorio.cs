using Modelos;

namespace Datos.Interfaces;

public interface IExpedientesRepositorio
{
    Task<bool> Guardar(Expedientes expedientes);
    Task<IEnumerable<Expedientes>> GetList();
}
