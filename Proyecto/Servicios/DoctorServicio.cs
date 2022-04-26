using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios;

public class DoctorServicio : IDoctorServicio
{
    private readonly MySQLConfiguration _configuration;
    private IDoctorRepositorio doctorRepositorio;

    public DoctorServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        doctorRepositorio = new DoctorRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Enviar(Doctores doctores)
    {
        return await doctorRepositorio.Enviar(doctores);
    }

    public async Task<IEnumerable<Doctores>> GetLista()
    {
        return await doctorRepositorio.GetLista();
    }

    public async Task<Doctores> GetPorIdDoctor(string idDoctor)
    {
        return await doctorRepositorio.GetPorIdDoctor(idDoctor);
    }
}
