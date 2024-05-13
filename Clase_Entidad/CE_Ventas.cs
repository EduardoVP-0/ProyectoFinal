using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_Ventas
    {
        private int _Id_Venta;
        private string _No_Venta;
        private int _Id_Proveedor;
        private string _Nombre;
        private DateTime _Fecha_Venta;
        private string _Comprobante;
        private decimal _Total;
        private string _Estado;

        public int Id_Venta { get => _Id_Venta; set => _Id_Venta = value; }
        public string No_Venta { get => _No_Venta; set => _No_Venta = value; }
        public int Id_Proveedor { get => _Id_Proveedor; set => _Id_Proveedor = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public DateTime Fecha_Venta { get => _Fecha_Venta; set => _Fecha_Venta = value; }
        public string Comprobante { get => _Comprobante; set => _Comprobante = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
    }
}
