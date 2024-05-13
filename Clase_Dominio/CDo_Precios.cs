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
    public class CDo_Precios
    {
        CD_Precios ObjPrecios = new CD_Precios();

        public void AgregarPrecio(CE_Precios Precios)
        {
            ObjPrecios.AgregarPrecio(Precios);
        }

        public void EditarPrecio(CE_Precios Precios)
        {
            ObjPrecios.EditarPrecio(Precios);
        }

        public void EliminarPrecio(CE_Precios Precios)
        {
            ObjPrecios.EliminarPrecio(Precios);
        }

        public DataTable MostrarPrecio()
        {
            return ObjPrecios.MostrarPrecio();
        }

        /*public DataTable BuscarPrecio_Nombre()
        {
            return ObjPrecios.BuscarPrecio_Nombre(Precios);
        }*/
    }
}
