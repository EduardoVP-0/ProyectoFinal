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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Ventas Ventas = new CDo_Ventas();
        CE_Ventas Venta = new CE_Ventas();

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false; // id_Venta
            dataGridView1.Columns[1].Visible = false; // id Proveedor

            dataGridView1.Columns[2].Width = 140; // no_venta
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
            dataGridView1.DataSource = Ventas.MostrarVenta();
        }

        private void AgIng_UpdateEventHandler(object sender, FrmPedidos.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            FrmPedidos Pedidos = new FrmPedidos(this);
            Pedidos.UpdateEventHandler += AgIng_UpdateEventHandler;
            Pedidos.ShowDialog();
        }
    }
}
