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
    public class CDo_Compras
    {
        CD_Compras ObjCompras = new CD_Compras();

        public void AgregarCompra(CE_Compras Compras)
        {
            ObjCompras.AgregarCompra(Compras);
        }

        public void AnularCompra(CE_Compras Compras)
        {
            ObjCompras.AnularCompra(Compras);
        }

        public DataTable MostrarCompra()
        {
            return ObjCompras.MostrarCompra();
        }
    }
}
