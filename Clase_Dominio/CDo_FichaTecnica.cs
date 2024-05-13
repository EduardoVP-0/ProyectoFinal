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
    public class CDo_FichaTecnica
    {
        CD_FichaTecnica ObjFichaTecnica = new CD_FichaTecnica();

        public void AgregarFicha(CE_FichaTecnica Fichas)
        {
            ObjFichaTecnica.AgregarFicha(Fichas);
        }

        public void EditarFicha(CE_FichaTecnica Fichas)
        {
            ObjFichaTecnica.EditarFicha(Fichas);
        }

        public DataTable MostrarFicha(int Id_Precio)
        {
            return ObjFichaTecnica.MostrarFicha(Id_Precio);
        }
    }
}
