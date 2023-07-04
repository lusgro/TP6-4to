using Microsoft.AspNetCore.Mvc;
using TP6.Models;

namespace TP6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Partidos = BD.ListarPartidos();
        return View();
    }
    public IActionResult VerDetallePartido(int idPartido)
    {
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        ViewBag.Candidatos = BD.ListarCandidatos(idPartido);
        return View("DetallePartido");
    }
    public IActionResult VerDetalleCandidato(int idCandidato, int idPartido)
    {
        ViewBag.Candidato = BD.VerInfoCandidato(idCandidato);
        ViewBag.Partido = BD.VerInfoPartido(idPartido);
        return View("DetalleCandidato");
    }
    public IActionResult AgregarCandidato(int idPartido)
    {
        ViewBag.Partido = idPartido;
        return View("AgregarCandidato");
    }
    [HttpPost]
    public IActionResult GuardarCandidato(int idPartido, string apellido, string nombre, string fechaNacimiento, string foto, string postulacion)
    {
        DateTime nacimiento = DateTime.Parse(fechaNacimiento);
        Candidato can = new Candidato(0, idPartido, apellido, nombre, nacimiento, foto, postulacion);
        BD.AgregarCandidato(can);
        return RedirectToAction("VerDetallePartido", new { idPartido = idPartido });
    }
    public IActionResult EliminarCandidato(int idCandidato, int idPartido)
    {
        BD.EliminarCandidato(idCandidato);
        return RedirectToAction("VerDetallePartido", new { idPartido = idPartido});
    }
    public IActionResult Elecciones()
    {
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
}