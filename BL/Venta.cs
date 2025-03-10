using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Venta
	{
		public static ML.Result Add(ML.Venta venta)
		{
			ML.Result result = new ML.Result();

			try
			{

				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					DL.Venta ventaBD = new DL.Venta();
					ventaBD.IdCliente = venta.cliente.IdCliente;
					ventaBD.Total = (decimal)venta.Total;

					context.Ventas.Add(ventaBD);

					int queryInsert = context.SaveChanges();

					
					result.Object = ventaBD.IdVenta;

					if (queryInsert > 0)
					{
						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "No se agregaron registros";
					}
				}
			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = "Error al guardar: " + ex.Message;
			}

			return result;
		}

	}
}
