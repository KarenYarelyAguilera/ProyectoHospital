using Modelos;

namespace Proyecto.Interfaces;

public interface IExpedientesServicio
{
    Task<bool> Guardar(Expedientes expedientes);
    Task<IEnumerable<Expedientes>> GetList();
}