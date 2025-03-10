using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult GetAll()
        {
			ML.Result result = BL.Cliente.GetAll();

			ML.Cliente cliente = new ML.Cliente();

			if (result.Correct == true)
			{
				cliente.Clientes = result.Objects;
			}
		
			return View(cliente);
	
        }
		[HttpPost]
		public ActionResult Formulario(ML.Cliente cliente)
		{
			if (cliente.IdCliente == 0)
			{
				ML.Result result = BL.Cliente.Add(cliente);
			}
			else
			{
				ML.Result result = BL.Cliente.Update(cliente);
			}

			return RedirectToAction("GetAll");
		}

		[HttpGet]
		public ActionResult Formulario(int? IdCliente)
		{
			ML.Cliente cliente = new ML.Cliente();

			if (IdCliente == null)
			{

			}
			else
			{
				ML.Result result = BL.Cliente.GetById(IdCliente.Value);
				if (result.Correct)
				{
					cliente = (ML.Cliente)result.Object;
				}
			}
			return View(cliente);
		}

		public ActionResult Delete(int IdCliente)
		{

			if (IdCliente != 0)
			{
				ML.Result result = BL.Cliente.Delete(IdCliente);
			}
			return RedirectToAction("GetAll");

		}
	}
}