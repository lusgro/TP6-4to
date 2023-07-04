namespace TP6.Models;

public class Partido
{
    public int idPartido { get; set; }
    public string nombre { get; set; }
    public string logo { get; set; }
    public string sitioWeb { get; set; }
    public DateTime fechaFundacion { get; set; }
    public int cantidadDiputados { get; set; }
    public int cantidadSenadores { get; set; }

    public Partido(int idPartido, string nombre, string logo, string sitioWeb, DateTime fechaFundacion, int cantidadDiputados, int cantidadSenadores)
    {
        this.idPartido = idPartido;
        this.nombre = nombre;
        this.logo = logo;
        this.sitioWeb = sitioWeb;
        this.fechaFundacion = fechaFundacion;
        this.cantidadDiputados = cantidadDiputados;
        this.cantidadSenadores = cantidadSenadores;
    }
}