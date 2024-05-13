using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_Entidad
{
    public class CE_Platillos
    {
        private int _Id_Platillo;
        private string _Codigo;
        private string _Nombre;
        private string _Categoria;
        private string _Descripcion;
        private string _Estado;
        private byte[] _Foto;

        private string _Buscar;

        public int Id_Platillo { get => _Id_Platillo; set => _Id_Platillo = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public byte[] Foto { get => _Foto; set => _Foto = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
    }
}
