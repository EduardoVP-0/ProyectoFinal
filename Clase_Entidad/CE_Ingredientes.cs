using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_Ingredientes
    {
        private int _Id_Ingrediente;
        private string _Codigo;
        private string _Nombre;
        private string _Categoria;
        private decimal _Precio;
        private string _Unidad_Medida;

        private string _Buscar;

        public int Id_Ingrediente { get => _Id_Ingrediente; set => _Id_Ingrediente = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }
        public decimal Precio { get => _Precio; set => _Precio = value; }
        public string Unidad_Medida { get => _Unidad_Medida; set => _Unidad_Medida = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
    }
}
