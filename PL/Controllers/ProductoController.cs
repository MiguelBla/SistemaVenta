using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
	public class ProductoController : Controller
	{
		// GET: Venta
		public ActionResult GetAll()
		{
			ML.Result result = BL.Producto.GetAll();

			ML.Producto producto = new ML.Producto();

			if (result.Correct == true)
			{
				producto.Productos = result.Objects;
			}

			return View(producto);
		}

		[HttpPost]
		public ActionResult Formulario(ML.Producto producto)
		{
			if (producto.IdProducto == 0)
			{
				ML.Result result = BL.Producto.ADD(producto);
			}
			else
			{
				ML.Result result = BL.Producto.Update(producto);
			}

			return RedirectToAction("GetAll");
		}


		[HttpGet]
		public ActionResult Formulario(int? IdProducto)
		{
			ML.Producto producto = new ML.Producto();

			if (IdProducto == null)
			{

			}
			else
			{
				ML.Result result = BL.Producto.GetById(IdProducto.Value);
				if (result.Correct)
				{
					producto = (ML.Producto)result.Object;
				}
			}
			return View(producto);
		}

		public ActionResult Delete(int IdProducto)
		{
			if (IdProducto != 0)
			{
				ML.Result result = BL.Producto.Delete(IdProducto);
			}
			return RedirectToAction("GetAll");

		}
	}
}