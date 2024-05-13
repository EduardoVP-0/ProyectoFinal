using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Clase_Datos;

namespace Clase_Dominio
{
    public class CDo_Procedimientos
    {
        CD_Procedimientos ObjProcedimientos = new CD_Procedimientos();
        public DataTable CargarDatos(string Tabla)
        {
            return ObjProcedimientos.CargarDatos(Tabla);
        }

        public void AlternarColorFilaDataGridView(DataGridView Dgv)
        {
            ObjProcedimientos.AlternarColorFilaDataGridView(Dgv);
        }

        public string GenerarCodigo(string Tabla)
        {
            return ObjProcedimientos.GenerarCodigo(Tabla);
        }

        public string GenerarCodigoId(string Tabla)
        {
            return ObjProcedimientos.GenerarCodigoId(Tabla);
        }

        public string GenerarComprobante(string Tabla)
        {
            return ObjProcedimientos.GenerarComprobante(Tabla);
        }

        public void FormatoMoneda(TextBox xTBox)
        {
            ObjProcedimientos.FormatoMoneda(xTBox);
        }

        public void LimpiarControles(Form xForm)
        {
            ObjProcedimientos.LimpiarControles(xForm);
        }

        public void LLenarComboBox(string Tabla, string Nombre, ComboBox xCBox)
        {
            ObjProcedimientos.LLenarComboBox(Tabla, Nombre, xCBox);
        }
    }
}
