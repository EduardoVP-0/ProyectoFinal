using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Clase_Datos;
using Clase_Entidad;

namespace Clase_Dominio
{
    public class CDo_Proveedores
    {
        CD_Proveedores ObjProveedores = new CD_Proveedores();

        public void AgregarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedores.AgregarProveedor(Proveedores);
        }

        public void EditarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedores.EditarProveedor(Proveedores);
        }

        public void EliminarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedores.EliminarProveedor(Proveedores);
        }

        public DataTable BuscarProveedor_Codigo(CE_Proveedores Proveedores)
        {
            return ObjProveedores.BuscarProveedor_Codigo(Proveedores);
        }

        public DataTable BuscarProveedor_Nombre(CE_Proveedores Proveedores)
        {
            return ObjProveedores.BuscarProveedor_Nombre(Proveedores);
        }

        public DataTable BuscarProveedor_Matricula(CE_Proveedores Proveedores)
        {
            return ObjProveedores.BuscarProveedor_Matricula(Proveedores);
        }
        public DataTable BuscarProveedor_Categoria(CE_Proveedores Proveedores)
        {
            return ObjProveedores.BuscarProveedor_Categoria(Proveedores);
        }
    }
}
