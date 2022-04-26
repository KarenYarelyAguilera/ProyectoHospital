using Datos.Interfaces;
using Datos.Repositorio;
using Datos.Repositorios;
using Modelos;
using Proyecto.Data;
using Proyecto.Interfaces;

namespace Proyecto.Servicios;

public class UsuarioServicio : IUsuarioServicio
{
    private readonly MySQLConfiguration _configuration;
    private IUsuarioRepositorio usuarioRepositorio;

    public UsuarioServicio(MySQLConfiguration configuration)
    {
        _configuration = configuration;
        usuarioRepositorio = new UsuarioRepositorio(configuration.CadenaConexion);
    }

    public async Task<IEnumerable<Usuario>> GetLista()
    {
        return await usuarioRepositorio.GetLista();
    }

    public async Task<Usuario> GetPorCodigo(string codigo)
    {
        return await usuarioRepositorio.GetPorCodigo(codigo);
    }
}
