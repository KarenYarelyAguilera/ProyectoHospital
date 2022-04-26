using Modelos;

namespace Datos.Interfaces;

public interface IDoctorRepositorio
{
    Task<bool>Enviar(Doctores doctores);
    Task<IEnumerable<Doctores>> GetLista();
    Task<Doctores> GetPorIdDoctor(string idDoctor);
}

