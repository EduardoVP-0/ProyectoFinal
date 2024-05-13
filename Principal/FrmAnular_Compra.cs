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
    public partial class FrmAnular_Compra : FrmBase
    {
        public FrmAnular_Compra(FrmCompras Compras)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Compras Compras = new CDo_Compras();
        CE_Compras Compra = new CE_Compras();
        CDo_Detalles Detalles = new CDo_Detalles();
        CE_Detalles Detalle = new CE_Detalles();

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string Data { get; set; }
        }

        protected void Actualizar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void FrmAnular_Compra_Load(object sender, EventArgs e)
        {
            MostrarDetalle();
            MejorarVista();
            Procedimientos.FormatoMoneda(txtTotal);
        }

        private void MejorarVista()
        {
            dataGridView1.Columns[0].Visible = false; // id_detalle
            dataGridView1.Columns[1].Visible = false; // id_compra
            dataGridView1.Columns[2].Visible = false; // id_ingrediente

            dataGridView1.Columns[3].Width = 228; // nombre
            dataGridView1.Columns[4].Width = 160; // cantidad
            dataGridView1.Columns[5].Width = 170; // precio
            dataGridView1.Columns[6].Width = 150; // coste_total

            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Format = "$#0.00";
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Format = "$#0.00";
        }

        private void MostrarDetalle()
        {
            dataGridView1.DataSource = Detalles.MostrarDetalle(Convert.ToInt32(txtId_Compra.Text));
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            Editar();
        }

        public override void Editar()
        {
            try
            {
                if (txtId_Compra.Text == string.Empty || txtNombreProveedor.Text == string.Empty ||
                txtComprobante.Text == string.Empty || txtId_Proveedor.Text == string.Empty ||
                txtNumero.Text == string.Empty)
                {
                    MessageBox.Show("Por favor rellene todos los campos.", "Cancelar Compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Compra.Id_Compra = Convert.ToInt32(txtId_Compra.Text);
                    Compra.No_Compra = txtNumero.Text;
                    Compra.Id_Proveedor = Convert.ToInt32(txtId_Proveedor.Text);
                    Compra.Nombre = txtNombreProveedor.Text;
                    Compra.Fecha_Compra = Convert.ToDateTime(dtpFecha.Text);
                    Compra.Comprobante = txtComprobante.Text;
                    Compra.Total = Convert.ToDecimal(txtTotal.Text);
                    Compra.Estado = "Cancelado";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Detalle.Id_Detalle = Convert.ToInt32(row.Cells[0].Value.ToString());
                        Detalle.Id_Compra = Convert.ToInt32(row.Cells[1].Value.ToString());
                        Detalle.Id_Ingrediente = Convert.ToInt32(row.Cells[2].Value.ToString());
                        Detalle.Nombre = Convert.ToString(row.Cells[3].Value.ToString());
                        Detalle.Cantidad = Convert.ToInt32(row.Cells[4].Value.ToString());
                        Detalle.Precio = Convert.ToDecimal(row.Cells[5].Value.ToString());
                        Detalle.Coste_Total = Convert.ToDecimal(row.Cells[6].Value.ToString());

                        Detalles.AnularDetalle(Detalle);
                    }
                    Compras.AnularCompra(Compra);

                    MessageBox.Show("Compra Cancelada", "Cancelar Compra", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Compra no registrada por: " + ex.Message, "Cancelar Compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}