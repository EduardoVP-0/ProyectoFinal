using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_FichaTecnica
    {
        private int _Id_Ficha;
        private int _Id_Precio;
        private int _Id_Ingrediente;
        private string _Nombre;
        private int _Cantidad;
        private decimal _Precio;
        private decimal _Costo_Total;

        public int Id_Ficha { get => _Id_Ficha; set => _Id_Ficha = value; }
        public int Id_Precio { get => _Id_Precio; set => _Id_Precio = value; }
        public int Id_Ingrediente { get => _Id_Ingrediente; set => _Id_Ingrediente = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
        public decimal Costo_Total { get => _Costo_Total; set => _Costo_Total = value; }
    }
}
