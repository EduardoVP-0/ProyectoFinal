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
    public class CDo_Detalles
    {
        CD_Detalles ObjDetalles = new CD_Detalles();

        public void AgregarDetalle(CE_Detalles Detalles)
        {
            ObjDetalles.AgregarDetalle(Detalles);
        }

        public void AnularDetalle(CE_Detalles Detalles)
        {
            ObjDetalles.AnularDetalle(Detalles);
        }

        public DataTable MostrarDetalle(int Id_Compra)
        {
            return ObjDetalles.MostrarDetalle(Id_Compra);
        }
    }
}
