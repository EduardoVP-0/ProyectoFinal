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
    public class CD_Ventas
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;

        public void AgregarVenta(CE_Ventas Ventas)
        {
            Cmd = new SqlCommand("AgregarVenta", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@No_Venta", Ventas.No_Venta));
            Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Ventas.Id_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Ventas.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Venta", Ventas.Fecha_Venta));
            Cmd.Parameters.Add(new SqlParameter("@Comprobante", Ventas.Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Total", Ventas.Total));
            Cmd.Parameters.Add(new SqlParameter("@Estado", Ventas.Estado));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public DataTable MostrarVenta()
        {
            DataTable Dt = new DataTable("Ventas");
            Cmd = new SqlCommand("MostrarVenta", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Con.Cerrar();
            return Dt;
        }
    }
}
