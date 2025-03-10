using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class VentaDesglose
	{
		public static ML.Result Add(ML.VentaDesglose ventaDesglose)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					if (ventaDesglose.VentaDesgloses != null && ventaDesglose.VentaDesgloses.Count > 0)
					{
						foreach (var ventaLista in ventaDesglose.VentaDesgloses)
						{
							var querryInsert = context.VentaDesgloseAdd(ventaDesglose.venta.IdVenta, ventaLista.producto.IdProducto, ventaLista.Cantidad);

							if (querryInsert <= 0)
							{

								result.Correct = false;
								result.ErrorMessage = "Error al agregar un registro.";
								return result;
							}
						}
						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "No se proporcionaron registros.";
					}
				}

			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = "Ocurrió un error: " + ex.Message;
			}

			return result;
		}

	}
}
