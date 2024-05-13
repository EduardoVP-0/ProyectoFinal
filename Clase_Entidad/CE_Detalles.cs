using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_Detalles
    {
        private int _Id_Detalle;
        private int _Id_Compra;
        private int _Id_Ingrediente;
        private string _Nombre;
        private int _Cantidad;
        private decimal _Precio;
        private decimal _Coste_Total;

        public int Id_Detalle { get => _Id_Detalle; set => _Id_Detalle = value; }
        public int Id_Compra { get => _Id_Compra; set => _Id_Compra = value; }
        public int Id_Ingrediente { get => _Id_Ingrediente; set => _Id_Ingrediente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
        public decimal Coste_Total { get => _Coste_Total; set => _Coste_Total = value; }
    }
}
