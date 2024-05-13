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
    public class CD_FichaTecnica
    {
        CD_Conexion Con = new CD_Conexion();
        private SqlCommand Cmd;

        public void AgregarFicha(CE_FichaTecnica Fichas)
        {
            Cmd = new SqlCommand("AgregarFicha", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Id_Precio", Fichas.Id_Precio));
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingrediente", Fichas.Id_Ingrediente));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Fichas.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Precio", Fichas.Precio));
            Cmd.Parameters.Add(new SqlParameter("@Cantidad", Fichas.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@Costo_Total", Fichas.Costo_Total));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EditarFicha(CE_FichaTecnica Fichas)
        {
            Cmd = new SqlCommand("EditarFicha", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Id_Precio", Fichas.Id_Precio));
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingrediente", Fichas.Id_Ingrediente));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Fichas.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Precio", Fichas.Precio));
            Cmd.Parameters.Add(new SqlParameter("@Cantidad", Fichas.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@Costo_Total", Fichas.Costo_Total));
            Cmd.Parameters.Add(new SqlParameter("@Id_Ficha", Fichas.Id_Ficha));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public DataTable MostrarFicha(int Id_Precio)
        {
            DataTable Dt = new DataTable("Precios de los Platillos");
            Cmd = new SqlCommand("MostrarFicha", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Precio", Id_Precio));
            Cmd.ExecuteNonQuery();

            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
