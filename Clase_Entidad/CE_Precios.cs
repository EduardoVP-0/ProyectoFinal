using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_Precios
    {
        private int _Id_Precio;
        private int _Id_Platillo;
        private string _Nombre;
        private int _Porciones;
        private decimal _Precio_Invertido;
        private decimal _Precio_Venta;

        public int Id_Precio { get => _Id_Precio; set => _Id_Precio = value; }
        public int Id_Platillo { get => _Id_Platillo; set => _Id_Platillo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Porciones { get => _Porciones; set => _Porciones = value; }
        public decimal Precio_Invertido { get => _Precio_Invertido; set => _Precio_Invertido = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
    }
}
