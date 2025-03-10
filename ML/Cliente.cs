using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ML
{
	public class Cliente
	{
		
		public int IdCliente { get; set; }

		[Required(ErrorMessage = "El nombre es obligatorio.")]
		[StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "El apellido paterno es obligatorio.")]
		[StringLength(50, ErrorMessage = "El apellido paterno no puede tener más de 50 caracteres.")]
		public string ApellidoPaterno { get; set; }

		[StringLength(50, ErrorMessage = "El apellido materno no puede tener más de 50 caracteres.")]
		public string ApellidoMaterno { get; set; }

		[Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
		public string Telefono { get; set; }

		[EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
		public string Correo { get; set; }

		[Required(ErrorMessage = "La dirección es obligatoria.")]
		public string Direccion { get; set; }

		public List<object> Clientes { get; set; }
	}
}



