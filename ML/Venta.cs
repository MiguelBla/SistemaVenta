using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
	public class Venta
	{
		
		public int IdVenta { get; set; }

		[Required(ErrorMessage = "El cliente es obligatorio.")]
		public Cliente cliente { get; set; }

		[Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0.")]
		public double Total { get; set; }

		[Required(ErrorMessage = "La fecha es obligatoria.")]
		public DateTime Fecha { get; set; }
	}
}
