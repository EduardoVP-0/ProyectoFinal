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
    public class CD_Precios
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;

        public void AgregarPrecio(CE_Precios Precios)
        {
            Cmd = new SqlCommand("AgregarPrecio", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Id_Platillo", Precios.Id_Platillo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Precios.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Porciones", Precios.Porciones));
            Cmd.Parameters.Add(new SqlParameter("@Precio_Invertido", Precios.Precio_Invertido));
            Cmd.Parameters.Add(new SqlParameter("@Precio_Venta", Precios.Precio_Venta));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EditarPrecio(CE_Precios Precios)
        {
            Cmd = new SqlCommand("EditarPrecio", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Id_Platillo", Precios.Id_Platillo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Precios.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Porciones", Precios.Porciones));
            Cmd.Parameters.Add(new SqlParameter("@Precio_Invertido", Precios.Precio_Invertido));
            Cmd.Parameters.Add(new SqlParameter("@Precio_Venta", Precios.Precio_Venta));
            Cmd.Parameters.Add(new SqlParameter("@Id_Precio", Precios.Id_Precio));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EliminarPrecio(CE_Precios Precios)
        {
            Cmd = new SqlCommand("EliminarPrecio", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Precio", Precios.Id_Precio));
            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public DataTable MostrarPrecio()
        {
            DataTable Dt = new DataTable("Precios");
            Cmd = new SqlCommand("MostrarPrecio", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Con.Cerrar();
            return Dt;
        }
    }
}
