using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Clase_Entidad;
namespace Clase_Datos
{
    public class CD_Pedidos
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;

        public void AgregarPedido(CE_Pedidos Pedidos)
        {
            Cmd = new SqlCommand("AgregarPedido", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Id_Venta", Pedidos.Id_Venta));
            Cmd.Parameters.Add(new SqlParameter("@Id_Platillo", Pedidos.Id_Platillo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Pedidos.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Cantidad", Pedidos.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@Coste_Total", Pedidos.Coste_Total));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }
    }
}
