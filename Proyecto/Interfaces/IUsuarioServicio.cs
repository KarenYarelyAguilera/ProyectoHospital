using Modelos;
namespace Proyecto.Interfaces;

public interface IUsuarioServicio
{
  
    Task<IEnumerable<Usuario>> GetLista();
    Task<Usuario> GetPorCodigo(string IdUsuario);
}
