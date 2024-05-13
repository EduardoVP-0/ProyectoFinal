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
    public partial class FrmEditar_Precio : FrmBase
    {
        public FrmEditar_Precio(FrmPrecios Precios)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Precios Precios = new CDo_Precios();
        CE_Precios Preci = new CE_Precios();
        CDo_FichaTecnica Fichas = new CDo_FichaTecnica();
        CE_FichaTecnica Ficha = new CE_FichaTecnica();

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

        private void FrmEditar_Precio_Load(object sender, EventArgs e)
        {

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
            dataGridView1.DataSource = Fichas.MostrarFicha(Convert.ToInt32(txtId_Precio.Text));
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        public override void Editar()
        {
            try
            {
                if (txtId_Precio.Text == string.Empty || txtNombrePlatillo.Text == string.Empty ||
                txtPorciones.Text == string.Empty || txtId_Platillo.Text == string.Empty)
                {
                    MessageBox.Show("Por favor rellene todos los campos.", "Editar Ficha Técnica",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Preci.Id_Precio = Convert.ToInt32(txtId_Precio.Text);
                    Preci.Id_Platillo = Convert.ToInt32(txtId_Platillo.Text);
                    Preci.Nombre = txtNombrePlatillo.Text;
                    Preci.Porciones = Convert.ToInt32(txtPorciones.Text);
                    Preci.Precio_Invertido = Convert.ToDecimal(txtTotal.Text) / Convert.ToInt32(txtPorciones.Text);
                    Preci.Precio_Venta = Convert.ToDecimal(Preci.Precio_Invertido * 3);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Ficha.Id_Ficha = Convert.ToInt32(row.Cells[0].Value.ToString());
                        Ficha.Id_Precio = Convert.ToInt32(row.Cells[1].Value.ToString());
                        Ficha.Id_Ingrediente = Convert.ToInt32(row.Cells[2].Value.ToString());
                        Ficha.Nombre = Convert.ToString(row.Cells[3].Value.ToString());
                        Ficha.Cantidad = Convert.ToInt32(row.Cells[4].Value.ToString());
                        Ficha.Precio = Convert.ToDecimal(row.Cells[5].Value.ToString());
                        Ficha.Costo_Total = Convert.ToDecimal(row.Cells[6].Value.ToString());

                        Fichas.EditarFicha(Ficha);
                    }
                    Precios.EditarPrecio(Preci);

                    MessageBox.Show("Ficha Técnica Actualizada", "Editar Ficha Técnica", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    this.Close();
                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ficha Técnica no actualizada por: " + ex.Message, "Editar Ficha Técnica",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}