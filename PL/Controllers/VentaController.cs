using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
	public class VentaController : Controller
	{
		// GET: Venta
		public ActionResult GetAll()
		{

			ML.Result result = BL.Cliente.GetAll();

			ML.Venta venta = new ML.Venta();
			venta.cliente = new ML.Cliente();

			if (result.Correct == true)
			{
				venta.cliente.Clientes = result.Objects;
			}

			return View(venta);

		}

		[HttpPost]
		public ActionResult GuardarCompra(ML.VentaDesglose ventaDesgloce)
		{
			ML.Result result = BL.Venta.Add(ventaDesgloce.venta);
			if (result.Correct) {
				ventaDesgloce.venta.IdVenta = (int)result.Object;
				if (ventaDesgloce.venta.IdVenta > 0) {
					result = BL.VentaDesglose.Add(ventaDesgloce);
				}
			}

			return Json(result);
		}

		[HttpGet]
		public ActionResult Formulario(int IdCliente)
		{
			ML.VentaDesglose ventaDesglose  = new ML.VentaDesglose();
			ventaDesglose.venta = new ML.Venta();
			ventaDesglose.producto = new ML.Producto();
			ventaDesglose.venta.cliente =new ML.Cliente();
			ML.Result resultCliente = BL.Cliente.GetById(IdCliente);
			if (resultCliente.Correct)
			{
				ventaDesglose.venta.cliente =(ML.Cliente)resultCliente.Object;
			}
			ML.Result  result = BL.Producto.GetAll();
			
			if (result.Correct) { 
				ventaDesglose.producto.Productos = result.Objects;
			}
			
			return View(ventaDesglose);
		}
	}
}
