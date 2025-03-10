using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
	public class Producto
	{
		
		public int IdProducto { get; set; }

		[Required(ErrorMessage = "El nombre del producto es obligatorio.")]
		[StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
		public string Nombre { get; set; }

		[StringLength(200, ErrorMessage = "La descripción no puede tener más de 200 caracteres.")]
		public string Descripcion { get; set; }

		[Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a 0.")]
		public decimal Costo { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser un número negativo.")]
		public int Stock { get; set; }

		public List<object> Productos { get; set; }
	}
}
