using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
	public class VentaDesglose
	{
		
		public int IdDesgloce { get; set; }

		public Venta venta { get; set; }

		public Producto producto { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser al menos 1.")]
		public int Cantidad { get; set; }

		public List<VentaDesglose> VentaDesgloses { get; set; }
	}
}
