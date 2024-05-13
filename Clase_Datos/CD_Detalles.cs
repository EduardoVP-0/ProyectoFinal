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
    public class CD_Detalles
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;

        public void AgregarDetalle(CE_Detalles Detalles)
        {
            Cmd = new SqlCommand("AgregarDetalle", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Id_Compra", Detalles.Id_Compra));
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingrediente", Detalles.Id_Ingrediente));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Detalles.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Cantidad", Detalles.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@Precio", Detalles.Precio));
            Cmd.Parameters.Add(new SqlParameter("@Coste_Total", Detalles.Coste_Total));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void AnularDetalle(CE_Detalles Detalles)
        {
            Cmd = new SqlCommand("AnularDetalle", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Id_Compra", Detalles.Id_Compra));
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingrediente", Detalles.Id_Ingrediente));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Detalles.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Cantidad", Detalles.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@Precio", Detalles.Precio));
            Cmd.Parameters.Add(new SqlParameter("@Coste_Total", Detalles.Coste_Total));
            Cmd.Parameters.Add(new SqlParameter("@Id_Detalle", Detalles.Id_Detalle));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public DataTable MostrarDetalle(int Id_Compra)
        {
            DataTable Dt = new DataTable("Detalles");
            Cmd = new SqlCommand("MostrarDetalle", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Compra", Id_Compra));
            Cmd.ExecuteNonQuery();

            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
