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
    public partial class FrmPrecios : FrmBase
    {
        public FrmPrecios()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Precios Precios = new CDo_Precios();
        CE_Precios Preci = new CE_Precios();

        private void FrmPrecios_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;

            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 140;
            dataGridView1.Columns[5].Width = 130;

            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[4].DefaultCellStyle.Format = "$#,##0.00";
            dataGridView1.Columns[5].DefaultCellStyle.Format = "$#,##0.00";

        }

        private void CargarDatos()
        {
            dataGridView1.DataSource = Precios.MostrarPrecio();
        }

        private void AgPre_UpdateEventHandler(object sender, FrmAgregar_Precio.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void AnPre_UpdateEventHandler(object sender, FrmEditar_Precio.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregar_Precio AgregarPrecio = new FrmAgregar_Precio(this);
            AgregarPrecio.UpdateEventHandler += AgPre_UpdateEventHandler;
            AgregarPrecio.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmEditar_Precio EditarPrecio = new FrmEditar_Precio(this);
            EditarPrecio.UpdateEventHandler += AnPre_UpdateEventHandler;

            EditarPrecio.txtId_Precio.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            EditarPrecio.txtId_Platillo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            EditarPrecio.txtNombrePlatillo.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            EditarPrecio.txtPorciones.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            EditarPrecio.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        public override void Eliminar()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros para eliminar.", "Eliminar Precio", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (dataGridView1 == null)
                    {
                        return;
                    }
                    else
                    {
                        DialogResult Resultados = MessageBox.Show("¿Está seguro de quitarle el precio al platillo?",
                            "Eliminar Precio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Preci.Id_Precio = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Precios.EliminarPrecio(Preci);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione un registro.", "Eliminar Precio", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
