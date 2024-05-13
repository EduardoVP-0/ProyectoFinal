using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Clase_Entidad;
 
namespace Clase_Datos
{
    public class CD_Ingredientes
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        public void AgregarIngrediente(CE_Ingredientes Ingredientes)
        {
            Cmd = new SqlCommand("AgregarIngrediente", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Codigo", Ingredientes.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Ingredientes.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Ingredientes.Categoria));  
            Cmd.Parameters.Add(new SqlParameter("@Precio", Ingredientes.Precio));
            Cmd.Parameters.Add(new SqlParameter("@Unidad_Medida", Ingredientes.Unidad_Medida));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EditarIngrediente(CE_Ingredientes Ingredientes)
        {
            Cmd = new SqlCommand("EditarIngrediente", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Codigo", Ingredientes.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Ingredientes.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Ingredientes.Categoria));
            Cmd.Parameters.Add(new SqlParameter("@Precio", Ingredientes.Precio));
            Cmd.Parameters.Add(new SqlParameter("@Unidad_Medida", Ingredientes.Unidad_Medida));
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingrediente", Ingredientes.Id_Ingrediente));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EliminarIngrediente(CE_Ingredientes Ingredientes)
        {
            Cmd = new SqlCommand("EliminarIngrediente", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingrediente", Ingredientes.Id_Ingrediente));
            Cmd.ExecuteNonQuery();

            Con.Cerrar();

            int Existencia = 0;

            Cmd = new SqlCommand("Select Cantidad From Inventario Where Id_Inventario =" +
                Ingredientes.Id_Ingrediente + "", Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                Existencia = Convert.ToInt32(Dr["Cantidad"].ToString());
            }
            Dr.Close();

            if(Existencia != 0)
            {
                MessageBox.Show("El ingrediente contiene existencia de registro por lo que no puede ser eliminado.",
                    "Eliminar Ingrediente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Cmd = new SqlCommand("EliminarIngrediente", Con.Abrir());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@Id_Ingrediente", Ingredientes.Id_Ingrediente));
                Cmd.ExecuteNonQuery();

                MessageBox.Show("Ingrediente eliminado exitosamente.", "Eliminar Ingrediente", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Cerrar();
            }
        }

        public DataTable BuscarIngrediente_Codigo(CE_Ingredientes Ingredientes)
        {
            Dt = new DataTable("Codigo_Ingrediente");
            Cmd = new SqlCommand("BuscarIngrediente_Codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Ingredientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarIngrediente_Nombre(CE_Ingredientes Ingredientes)
        {
            Dt = new DataTable("Nombre_Ingrediente");
            Cmd = new SqlCommand("BuscarIngrediente_Nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Ingredientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarIngrediente_Categoria(CE_Ingredientes Ingredientes)
        {
            Dt = new DataTable("Categoria");
            Cmd = new SqlCommand("BuscarIngrediente_Categoria", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Ingredientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }
    }
}
