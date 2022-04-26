using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios;

public class PacienteServicio : IPacienteServicio
{
    private readonly MySQLConfiguration _configuration;
    private IPacienteRepositorio PacienteRepositorio;

    public PacienteServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        PacienteRepositorio = new PacienteRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Enviar(Pacientes pacientes)
    {
        return await PacienteRepositorio.Enviar(pacientes);
    }

    public async Task<IEnumerable<Pacientes>> GetList()
    {
        return await PacienteRepositorio.GetList();
    }


}
