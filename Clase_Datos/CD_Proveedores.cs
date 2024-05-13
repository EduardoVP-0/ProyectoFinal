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
    public class CD_Proveedores
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        public void AgregarProveedor(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("AgregarProveedor", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Codigo", Proveedores.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Matricula", Proveedores.Matricula));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Proveedores.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Proveedores.Categoria));
            Cmd.Parameters.Add(new SqlParameter("@Direccion", Proveedores.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@Telefono", Proveedores.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@Email", Proveedores.Email));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EditarProveedor(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("EditarProveedor", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            Cmd.Parameters.Add(new SqlParameter("@Codigo", Proveedores.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Matricula", Proveedores.Matricula));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Proveedores.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Proveedores.Categoria));
            Cmd.Parameters.Add(new SqlParameter("@Direccion", Proveedores.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@Telefono", Proveedores.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@Email", Proveedores.Email));
            Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Proveedores.Id_Proveedor));

            Cmd.ExecuteNonQuery();
            Con.Cerrar();
        }

        public void EliminarProveedor(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("EliminarProveedor", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Proveedores.Id_Proveedor));
            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public DataTable BuscarProveedor_Codigo(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("Codigo");
            Cmd = new SqlCommand("BuscarProveedor_Codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarProveedor_Nombre(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("Nombre");
            Cmd = new SqlCommand("BuscarProveedor_Nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarProveedor_Matricula(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("Matrícula");
            Cmd = new SqlCommand("BuscarProveedor_Matricula", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }

        public DataTable BuscarProveedor_Categoria(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("Categoría");
            Cmd = new SqlCommand("BuscarProveedor_Categoria", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();

            return Dt;
        }
    }
}
