using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios;

public class ExpedientesServicio : IExpedientesServicio
{
    private readonly MySQLConfiguration _configuration;
    private IExpedientesRepositorio ExpedientesRepositorio;

    public ExpedientesServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        ExpedientesRepositorio = new ExpedientesRepositorio(configuration.CadenaConexion);
    }

    public async Task<bool> Guardar(Expedientes expedientes)
    {
        return await ExpedientesRepositorio.Guardar(expedientes);
    }

    public async Task<IEnumerable<Expedientes>> GetList()
    {
        return await ExpedientesRepositorio.GetList();
    }

}
