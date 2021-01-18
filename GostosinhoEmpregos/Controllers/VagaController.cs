using GostosinhoEmpregos.BLL.BLL.master;
using GostosinhoEmpregos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GostosinhoEmpregos.Controllers
{
    public class VagaController : Controller
    {
        //GET /Vaga/Create
        public IActionResult Create()
        {
            return View();
        }
        //GET /Vaga/VerVaga
        public IActionResult VerVaga(int idVaga)
        {
            ViewBag.VagaDados = null;
            return View();
        }

        [HttpPost]
        public IActionResult SalvarVaga(VagaViewModel vaga)
        {
            if (vaga.DataValidade == null || vaga.DataValidade < DateTime.Now)
                vaga.DataValidade = DateTime.Now.AddDays(15);

            Vaga.Insert(vaga.Funcao, vaga.Descricao, vaga.DataValidade, vaga.Cidade, decimal.Parse(vaga.Cpf),vaga.NomeResponsavel);
            return Redirect("~/Home");
        }
    }
}
