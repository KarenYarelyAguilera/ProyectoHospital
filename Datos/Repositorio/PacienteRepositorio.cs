using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Datos.Repositorio;

public class PacienteRepositorio : IPacienteRepositorio
{
    private string CadenaConexion;


    public PacienteRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }

    public async Task<IEnumerable<Pacientes>> GetList()
    {
        IEnumerable<Pacientes> lista = new List<Pacientes>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM Paciente;";
            lista = await conexion.QueryAsync<Pacientes>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;
    }

    public async Task<bool> Guardar(Pacientes pacientes)
    {
        int Enviar;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE Doctores SET IdDoctor=@IdDoctor, Nombre = @Nombre, Identidad = @Identidad, FechaNacimiento = @FechaNacimiento, Sexo = @Sexo, NumeroTelefono = @NumeroTelefono, Direccion = @Direccion" +
                "Especialidad = @Especialidad, Turno = @Turno WHERE IdDoctor=@IdDoctor;";
            Enviar = await conexion.ExecuteAsync(sql, new { pacientes.Nombre, pacientes.Identidad, pacientes.FechaNacimiento, pacientes.Sexo, pacientes.NumeroTelefono});
            return Enviar > 0;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
    public async Task<IEnumerable<Pacientes>> GetLista()
    {
        IEnumerable<Pacientes> lista = new List<Pacientes>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM Paciente;";
            lista = await conexion.QueryAsync<Pacientes>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;
    }

    public Task<bool> Enviar(Pacientes pacientes)
    {
        throw new NotImplementedException();
    }
}

