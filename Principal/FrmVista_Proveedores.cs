using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_Dominio;
using Clase_Entidad;

namespace Principal
{
    public partial class FrmVista_Proveedores : FrmBase
    {
        public FrmVista_Proveedores()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Proveedores Proveedores = new CDo_Proveedores();
        CE_Proveedores Proveedor = new CE_Proveedores();


        private void FrmVista_Proveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].Width = 190;

            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Proveedores");
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count == 0)
            {
                return;
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        public override void Buscar()
        {
            try
            {
                if (cboTipoBusqueda.Text == "Nombre")
                {
                    Proveedor.Buscar = txtBuscarProveedor.Text.Trim();
                    dataGridView1.DataSource = Proveedores.BuscarProveedor_Nombre(Proveedor);
                }
                else if (cboTipoBusqueda.Text == "Categoría")
                {
                    Proveedor.Buscar = txtBuscarProveedor.Text.Trim();
                    dataGridView1.DataSource = Proveedores.BuscarProveedor_Categoria(Proveedor);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proveedor no encontrado." + ex.Message, "Buscar Proveedor", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
