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

public class ExpedientesRepositorio : IExpedientesRepositorio
{
    private string CadenaConexion;


    public ExpedientesRepositorio(string cadenaConexion)
    {
        CadenaConexion = cadenaConexion;
    }

    private MySqlConnection Conexion()
    {
        return new MySqlConnection(CadenaConexion);
    }

    public async Task<IEnumerable<Expedientes>> GetList()
    {
        IEnumerable<Expedientes> lista = new List<Expedientes>();

        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "SELECT * FROM ExpedientePaciente;";
            lista = await conexion.QueryAsync<Expedientes>(sql);
        }
        catch (Exception ex)
        {
        }
        return lista;
    }

    public async Task<bool> Guardar(Expedientes expedientes)
    {
        int Guardar;
        try
        {
            using MySqlConnection conexion = Conexion();
            await conexion.OpenAsync();
            string sql = "UPDATE ExpedientePaciente SET IdExpedientePaciente=@IdExpedientePaciente, IdRegistroPaciente = @IdRegistroPaciente IdDoctor = @IdDoctor" +
                "FechaConsulta = @FechaConsulta, Diagnostico  = @Diagnostico WHERE IdExpedientePaciente=@IdExpedientePaciete;";
            Guardar = await conexion.ExecuteAsync(sql, new { expedientes.FechaConsulta, expedientes.Diagnostico });
            return Guardar > 0;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
}
