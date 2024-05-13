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
    public class CDo_Ventas
    {
        CD_Ventas ObjVentas = new CD_Ventas();

        public void AgregarVenta(CE_Ventas Ventas)
        {
            ObjVentas.AgregarVenta(Ventas);
        }

        public DataTable MostrarVenta()
        {
            return ObjVentas.MostrarVenta();
        }
    }
}
