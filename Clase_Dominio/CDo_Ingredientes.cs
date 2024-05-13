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
    public class CDo_Ingredientes
    {
        CD_Ingredientes ObjIngredientes = new CD_Ingredientes();

        public void AgregarIngrediente(CE_Ingredientes Ingredientes)
        {
            ObjIngredientes.AgregarIngrediente(Ingredientes);
        }

        public void EditarIngrediente(CE_Ingredientes Ingredientes)
        {
            ObjIngredientes.EditarIngrediente(Ingredientes);
        }

        public void EliminarIngrediente(CE_Ingredientes Ingredientes)
        {
            ObjIngredientes.EliminarIngrediente(Ingredientes);
        }

        public DataTable BuscarIngrediente_Codigo(CE_Ingredientes Ingredientes)
        {
            return ObjIngredientes.BuscarIngrediente_Codigo(Ingredientes);
        }

        public DataTable BuscarIngrediente_Nombre(CE_Ingredientes Ingredientes)
        {
            return ObjIngredientes.BuscarIngrediente_Nombre(Ingredientes);
        }

        public DataTable BuscarIngrediente_Categoria(CE_Ingredientes Ingredientes)
        {
            return ObjIngredientes.BuscarIngrediente_Categoria(Ingredientes);
        }
    }
}
