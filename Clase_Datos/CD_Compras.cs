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
    public class CD_Compras
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;
        
        public void AgregarCompra(CE_Compras Compras)
        {
            Cmd = new SqlCommand("AgregarCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@No_Compra", Compras.No_Compra));
            Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Compras.Id_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Compras.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Compra", Compras.Fecha_Compra));
            Cmd.Parameters.Add(new SqlParameter("@Comprobante", Compras.Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Total", Compras.Total));
            Cmd.Parameters.Add(new SqlParameter("@Estado", Compras.Estado));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void AnularCompra(CE_Compras Compras)
        {
            Cmd = new SqlCommand("AnularCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@No_Compra", Compras.No_Compra));
            Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Compras.Id_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Compras.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Compra", Compras.Fecha_Compra));
            Cmd.Parameters.Add(new SqlParameter("@Comprobante", Compras.Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Total", Compras.Total));
            Cmd.Parameters.Add(new SqlParameter("@Estado", Compras.Estado));
            Cmd.Parameters.Add(new SqlParameter("@Id_Compra", Compras.Id_Compra));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public DataTable MostrarCompra()
        {
            DataTable Dt = new DataTable("Compras");
            Cmd = new SqlCommand("MostrarCompra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Con.Cerrar();
            return Dt;
        }
    }
}
