using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
	public class Cliente
	{
		public static ML.Result GetAll()
		{
			ML.Result result = new ML.Result();

			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryGetAll = context.ClientGetAll().ToList();

					if (querryGetAll != null && querryGetAll.Any()) // Verifica que la lista no sea nula y tenga elementos
					{
						result.Objects = new List<object>();

						foreach (var clienteBD in querryGetAll)
						{
							ML.Cliente cliente = new ML.Cliente
							{
								IdCliente = (int)clienteBD.IdCliente,
								Nombre = clienteBD.Nombre,
								ApellidoPaterno = clienteBD.ApellidoPaterno,
								ApellidoMaterno = clienteBD.ApellidoMaterno,
								Direccion = clienteBD.Direccion,
								Correo = clienteBD.Correo,
								Telefono = clienteBD.Telefono
							};

							result.Objects.Add(cliente);
						}

						result.Correct = true;
					}
					else
					{
						result.Correct = false;
						result.ErrorMessage = "No se encontraron registros en la base de datos.";
					}
				}
			}
			catch (Exception ex)
			{
				result.Correct = false;
				result.ErrorMessage = "Ocurrió un error al obtener los clientes: " + ex.Message;
			}

			return result;
		}
		public static ML.Result GetById(int IdCliente)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryGetById = context.ClienteGetById(IdCliente).FirstOrDefault();
					if (querryGetById != null)
					{
						ML.Cliente cliente = new ML.Cliente();
						cliente.IdCliente = (int)querryGetById.IdCliente;
						cliente.Nombre = querryGetById.Nombre;
						cliente.ApellidoPaterno = querryGetById.ApellidoPaterno;
						cliente.ApellidoMaterno = querryGetById.ApellidoMaterno;
						cliente.Direccion = querryGetById.Direccion;
						cliente.Correo = querryGetById.Correo;
						cliente.Telefono = querryGetById.Telefono;

						result.Object = cliente;
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
				result.ErrorMessage = "Ocurrió un error " + ex.Message;
			}



			return result;
		}
		public static ML.Result Add(ML.Cliente cliente)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryInsert = context.ClienteAdd(cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno, cliente.Telefono, cliente.Correo, cliente.Direccion);
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
		public static ML.Result Update(ML.Cliente cliente)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryUpdate = context.ClienteUpdate(cliente.IdCliente, cliente.Nombre, cliente.ApellidoPaterno, cliente.ApellidoMaterno, cliente.Telefono, cliente.Correo, cliente.Direccion);
					if (querryUpdate > 0)
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
		public static ML.Result Delete(int IdCliente)
		{
			ML.Result result = new ML.Result();
			try
			{
				using (DL.SistemaVentasEntities context = new DL.SistemaVentasEntities())
				{
					var querryDelete = context.ClienteDelete(IdCliente);
					if (querryDelete > 0)
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
