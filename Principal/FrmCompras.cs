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
    public partial class FrmCompras : FrmBase
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Compras Compras = new CDo_Compras();
        CE_Compras Compra = new CE_Compras();

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false; // id_Compra
            dataGridView1.Columns[1].Visible = false; // id Proveedor

            dataGridView1.Columns[2].Width = 140; // no_compra
            dataGridView1.Columns[3].Width = 180; // nombre proveedor
            dataGridView1.Columns[4].Width = 180; // fecha
            dataGridView1.Columns[5].Width = 140; // comprobante
            dataGridView1.Columns[6].Width = 140; // total
            dataGridView1.Columns[7].Width = 135; // estado

            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[6].DefaultCellStyle.Format = "$#,##0.00";
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Compras.MostrarCompra();
        }

        private void AgIng_UpdateEventHandler(object sender, FrmAgregar_Compra.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void AnIng_UpdateEventHandler(object sender, FrmAnular_Compra.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            FrmAgregar_Compra AgregarCompra = new FrmAgregar_Compra(this);
            AgregarCompra.UpdateEventHandler += AgIng_UpdateEventHandler;
            AgregarCompra.ShowDialog();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            FrmAnular_Compra AnularCompra = new FrmAnular_Compra(this);
            AnularCompra.UpdateEventHandler += AnIng_UpdateEventHandler;

            AnularCompra.txtId_Compra.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            AnularCompra.txtId_Proveedor.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            AnularCompra.txtNumero.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            AnularCompra.txtNombreProveedor.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            AnularCompra.dtpFecha.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            AnularCompra.txtComprobante.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            AnularCompra.txtTotal.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

            AnularCompra.ShowDialog();
        }
    }
}