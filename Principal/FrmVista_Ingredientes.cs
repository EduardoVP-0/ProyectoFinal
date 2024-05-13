using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_Dominio;
using Clase_Entidad;

namespace Principal
{
    public partial class FrmVista_Ingredientes : FrmBase
    {
        public FrmVista_Ingredientes()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Ingredientes Ingredientes = new CDo_Ingredientes();
        CE_Ingredientes Ingrediente = new CE_Ingredientes();

        private void FrmVista_Ingredientes_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;

            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 180;
            dataGridView1.Columns[4].Width = 120;

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[4].DefaultCellStyle.Format = "$#,##0.00";
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Ingredientes");
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
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
                    Ingrediente.Buscar = txtBuscarIngrediente.Text.Trim();
                    dataGridView1.DataSource = Ingredientes.BuscarIngrediente_Nombre(Ingrediente);
                }
                else if (cboTipoBusqueda.Text == "Categoría")
                {
                    Ingrediente.Buscar = txtBuscarIngrediente.Text.Trim();
                    dataGridView1.DataSource = Ingredientes.BuscarIngrediente_Categoria(Ingrediente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrediente no encontrado." + ex.Message, "Buscar Ingrediente", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void txtBuscarIngrediente_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }
    }
}
