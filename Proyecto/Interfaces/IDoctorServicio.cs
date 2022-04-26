using Modelos;

namespace Proyecto.Interfaces;

public interface IDoctorServicio
{
    Task<bool> Enviar(Doctores doctores);
    Task<IEnumerable<Doctores>> GetLista();

    Task<Doctores> GetPorIdDoctor(string idDoctor);
}
