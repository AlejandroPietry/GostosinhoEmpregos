using GostosinhoEmpregos.BLL.BLL.master;
using GostosinhoEmpregos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GostosinhoEmpregos.Controllers
{
    [Controller]
    public class VagaController : Controller
    {
        //GET /Vaga/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //GET /Vaga/VerVaga
        public IActionResult VerVaga(int idVaga)
        {
            ViewBag.Vaga = Vaga.RecuperarVagaPorId(idVaga);
            return View();
        }

        [HttpPost]
        public IActionResult Create(VagaViewModel vaga)
        {
            if (ModelState.IsValid)
            {
                if (vaga.DataValidade == null || vaga.DataValidade < DateTime.Now)
                    vaga.DataValidade = DateTime.Now.AddDays(15);

                Vaga.Insert(vaga.Funcao, vaga.Descricao, vaga.DataValidade, vaga.Cidade, decimal.Parse(vaga.Cpf), vaga.NomeResponsavel);
                return Redirect("~/Home");
            }
            return View();
        }
    }
}
