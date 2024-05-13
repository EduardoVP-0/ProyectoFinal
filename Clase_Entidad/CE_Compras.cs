using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_Compras
    {
        private int _Id_Compra;
        private string _No_Compra;
        private int _Id_Proveedor;
        private string _Nombre;
        private DateTime _Fecha_Compra;
        private string _Comprobante;
        private decimal _Total;
        private string _Estado;

        private string _Buscar;

        public int Id_Compra { get => _Id_Compra; set => _Id_Compra = value; }
        public string No_Compra { get => _No_Compra; set => _No_Compra = value; }
        public int Id_Proveedor { get => _Id_Proveedor; set => _Id_Proveedor = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public DateTime Fecha_Compra { get => _Fecha_Compra; set => _Fecha_Compra = value; }
        public string Comprobante { get => _Comprobante; set => _Comprobante = value; }
        public decimal Total { get => _Total; set => _Total = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
    }
}
