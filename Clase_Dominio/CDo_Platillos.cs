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
    public class CDo_Platillos
    {
        CD_Platillos ObjPlatillos = new CD_Platillos();

        public void AgregarPlatillo(CE_Platillos Platillos)
        {
            ObjPlatillos.AgregarPlatillo(Platillos);
        }
        
        public void EditarPlatillo(CE_Platillos Platillos)
        {
            ObjPlatillos.EditarPlatillo(Platillos);
        }

        public void EliminarPlatillo(CE_Platillos Platillos)
        {
            ObjPlatillos.EliminarPlatillo(Platillos);
        }

        public DataTable BuscarPlatillo_Codigo(CE_Platillos Platillos)
        {
            return ObjPlatillos.BuscarPlatillo_Codigo(Platillos);
        }

        public DataTable BuscarPlatillo_Nombre(CE_Platillos Platillos)
        {
            return ObjPlatillos.BuscarPlatillo_Nombre(Platillos);
        }

        public DataTable BuscarPlatillo_Categoria(CE_Platillos Platillos)
        {
            return ObjPlatillos.BuscarPlatillo_Categoria(Platillos);
        }

        public DataTable BuscarPlatillo_Estado(CE_Platillos Platillos)
        {
            return ObjPlatillos.BuscarPlatillo_Estado(Platillos);
        }
    }
}
