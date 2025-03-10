using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Producto
	{

		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryGetAll = (from productoBD in context.Productoes
										select productoBD).ToList();
					if (querryGetAll != null)
					{
						result.Objects = new List<object>();
						foreach (var productoBD in querryGetAll)
						{
							ML.Producto producto = new ML.Producto();
							producto.IdProducto = productoBD.IdProducto;
							producto.Nombre = productoBD.Nombre;
							producto.Descripcion = productoBD.Descripcion;
							producto.Costo = (decimal)productoBD.Costo;
							producto.Stock = (int)productoBD.Stock;

							result.Objects.Add(producto);
						}
						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "No se encontraron registros";
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
		public static ML.Result GetById(int IdProducto)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryGetById = (from productoBD in context.Productoes
										 where productoBD.IdProducto == IdProducto
										 select productoBD).FirstOrDefault();
					if (querryGetById != null)
					{

						ML.Producto producto = new ML.Producto();
						producto.IdProducto = querryGetById.IdProducto;
						producto.Nombre = querryGetById.Nombre;
						producto.Descripcion = querryGetById.Descripcion;
						producto.Costo = (decimal)querryGetById.Costo;
						producto.Stock = (int)querryGetById.Stock;

						result.Object = producto;
						result.Correct = true;

					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "No se encontraron registros";
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
		public static ML.Result ADD(ML.Producto producto)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					DL.Producto productoBD = new DL.Producto();

					productoBD.Nombre = producto.Nombre;
					productoBD.Descripcion = producto.Descripcion;
					productoBD.Costo = (decimal)producto.Costo;
					productoBD.Stock = (int)producto.Stock;
					context.Productoes.Add(productoBD);
					int querryInsert = context.SaveChanges();
					if (querryInsert > 0)
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
				result.ErrorMessage = "Ocurrió un error: " + ex.Message;
			}

			return result;
		}
		public static ML.Result Update(ML.Producto producto)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryUpdate = (from productoBD in context.Productoes
										where productoBD.IdProducto == producto.IdProducto
										select productoBD).FirstOrDefault();


					querryUpdate.Nombre = producto.Nombre;
					querryUpdate.Descripcion = producto.Descripcion;
					querryUpdate.Costo = (decimal)producto.Costo;
					querryUpdate.Stock = (int)producto.Stock;

					int querryInsert = context.SaveChanges();

					if (querryInsert > 0)
					{
						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "No se realizo la actualización del registro :";
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
		public static ML.Result Delete(int IdProducto)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryDelete = (from productoBD in context.Productoes
										where productoBD.IdProducto == IdProducto
										select productoBD).FirstOrDefault();


					if (querryDelete != null)
					{
						context.Productoes.Remove(querryDelete);
					}
					int querryRemove = context.SaveChanges();
					if (querryRemove > 0)
					{
						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "No se elimino el registro";
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
