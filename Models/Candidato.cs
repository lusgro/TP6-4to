namespace TP6.Models;

public class Candidato
{
    public int idCandidato { get; set; }
    public int idPartido { get; set; }
    public string apellido { get; set; }
    public string nombre { get; set; }
    public DateTime fechaNacimiento { get; set; }
    public string foto { get; set; }
    public string postulacion { get; set; }

    public Candidato(int idCandidato, int idPartido, string apellido, string nombre, DateTime fechaNacimiento, string foto, string postulacion)
    {
        this.idCandidato = idCandidato;
        this.idPartido = idPartido;
        this.apellido = apellido;
        this.nombre = nombre;
        this.fechaNacimiento = fechaNacimiento;
        this.foto = foto;
        this.postulacion = postulacion;
    }
}