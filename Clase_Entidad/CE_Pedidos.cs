using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_Pedidos
    {
        private int _Id_Pedido;
        private int _Id_Venta;
        private int _Id_Platillo;
        private string _Nombre;
        private int _Cantidad;
        private decimal _Coste_Total;

        public int Id_Pedido { get => _Id_Pedido; set => _Id_Pedido = value; }
        public int Id_Venta { get => _Id_Venta; set => _Id_Venta = value; }
        public int Id_Platillo { get => _Id_Platillo; set => _Id_Platillo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Coste_Total { get => _Coste_Total; set => _Coste_Total = value; }
    }
}
