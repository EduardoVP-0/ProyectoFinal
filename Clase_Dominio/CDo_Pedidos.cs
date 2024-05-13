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
    public class CDo_Pedidos
    {
        CD_Pedidos ObjPedidos = new CD_Pedidos();

        public void AgregarPedido(CE_Pedidos Pedidos)
        {
            ObjPedidos.AgregarPedido(Pedidos);
        }
    }
}