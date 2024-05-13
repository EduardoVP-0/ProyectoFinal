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
    public class CD_Platillos
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        public void AgregarPlatillo(CE_Platillos Platillos)
        {
            Cmd = new SqlCommand("AgregarPlatillo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Codigo", Platillos.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Platillos.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Platillos.Categoria));
            Cmd.Parameters.Add(new SqlParameter("@Descripcion", Platillos.Descripcion));
            Cmd.Parameters.Add(new SqlParameter("@Estado", Platillos.Estado));
            Cmd.Parameters.Add(new SqlParameter("@Foto", Platillos.Foto));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EditarPlatillo(CE_Platillos Platillos)
        {
            Cmd = new SqlCommand("EditarPlatillo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Codigo", Platillos.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Platillos.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Platillos.Categoria));
            Cmd.Parameters.Add(new SqlParameter("@Descripcion", Platillos.Descripcion));
            Cmd.Parameters.Add(new SqlParameter("@Estado", Platillos.Estado));
            Cmd.Parameters.Add(new SqlParameter("@Foto", Platillos.Foto));
            Cmd.Parameters.Add(new SqlParameter("@Id_Platillo", Platillos.Id_Platillo));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EliminarPlatillo(CE_Platillos Platillos)
        {
            Cmd = new SqlCommand("EliminarPlatillo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Platillo", Platillos.Id_Platillo));
            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public DataTable BuscarPlatillo_Codigo(CE_Platillos Platillos)
        {
            Dt = new DataTable("Codigo");
            Cmd = new SqlCommand("BuscarPlatillo_Codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Platillos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarPlatillo_Nombre(CE_Platillos Platillos)
        {
            Dt = new DataTable("Nombre");
            Cmd = new SqlCommand("BuscarPlatillo_Nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Platillos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarPlatillo_Categoria(CE_Platillos Platillos)
        {
            Dt = new DataTable("Categoria");
            Cmd = new SqlCommand("BuscarPlatillo_Categoria", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Platillos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarPlatillo_Estado(CE_Platillos Platillos)
        {
            Dt = new DataTable("Estado");
            Cmd = new SqlCommand("BuscarPlatillo_Estado", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Platillos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }
    }
}
