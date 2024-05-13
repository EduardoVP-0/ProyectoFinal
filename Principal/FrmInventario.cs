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
    public partial class FrmInventario : FrmBase
    {
        public FrmInventario()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();

        public static double Total;

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            CargarDatos();
            SumarInventario();

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 120; 
            dataGridView1.Columns[2].Width = 170; 
            dataGridView1.Columns[3].Width = 170; 
            dataGridView1.Columns[4].Width = 135; 
            dataGridView1.Columns[5].Width = 100; 
            dataGridView1.Columns[6].Width = 110; 
            dataGridView1.Columns[7].Width = 110; 

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[5].DefaultCellStyle.Format = "$#,##0.00";
            dataGridView1.Columns[7].DefaultCellStyle.Format = "$#,##0.00";
        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Inventario");
            dataGridView1.ClearSelection();
        }

        private void SumarInventario()
        {
            Total = 0;
            foreach(DataGridViewRow Row in dataGridView1.Rows) {
                Total += Convert.ToDouble(Row.Cells[7].Value);
            }
            txtImporte.Text = Total.ToString("N2");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
