using System.Data.SqlClient;
using Dapper;
namespace TP6.Models;

public static class BD
{
    private static string _connectionString { get; set; } = @"Server=localhost;DataBase=Elecciones2023;Trusted_Connection=True;";

    public static void AgregarCandidato(Candidato can)
    {
        string query = "INSERT INTO Candidato (IdPartido, Apellido, Nombre, FechaNacimiento, Foto, Postulacion) VALUES (@IdPartido, @Apellido, @Nombre, @FechaNacimiento, @Foto, @Postulacion)";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { IdPartido = can.idPartido, Apellido = can.apellido, Nombre = can.nombre, FechaNacimiento = can.fechaNacimiento, Foto = can.foto, Postulacion = can.postulacion });
        }
    }
    
    public static void EliminarCandidato(int idCandidato)
    {
        string query = "DELETE FROM Candidato WHERE IdCandidato = @idCandidato";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Execute(query, new { IdCandidato = idCandidato });
        }
    }

    public static Partido VerInfoPartido(int idPartido)
    {
        string query = "SELECT * FROM Partido WHERE IdPartido = @idPartido";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            Partido partido = connection.QueryFirstOrDefault<Partido>(query, new { idPartido = idPartido });
            return partido;
        }
    }


    public static Candidato VerInfoCandidato(int idCandidato)
    {
        Candidato candidato = null;
        string query = "SELECT * FROM Candidato WHERE IdCandidato = @idCandidato";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            candidato = connection.QueryFirstOrDefault<Candidato>(query, new { idCandidato = idCandidato });
        }
        return candidato;
    }

    public static List<Partido> ListarPartidos()
    {
        List<Partido> partidos = new List<Partido>();
        string query = "SELECT * FROM Partido";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            partidos = connection.Query<Partido>(query).ToList();
        }
        return partidos;
    }

    public static List<Candidato> ListarCandidatos(int idPartido)
    {
        List<Candidato> candidatos = new List<Candidato>();
        string query = "SELECT * FROM Candidato WHERE IdPartido = @idPartido";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            candidatos = connection.Query<Candidato>(query, new { idPartido = idPartido }).ToList();
        }
        return candidatos;
    }
}