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
    public partial class FrmIngredientes : FrmBase
    {
        public FrmIngredientes()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Ingredientes Ingredientes = new CDo_Ingredientes();
        CE_Ingredientes Ingrediente = new CE_Ingredientes();

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Ingredientes");
            dataGridView1.ClearSelection();
        }

        private void AgIng_UpdateEventHandler(object sender, FrmAgregar_Ingrediente.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void EdIng_UpdateEventHandler(object sender, FrmEditar_Ingrediente.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void FrmIngredientes_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].Width = 190;
            dataGridView1.Columns[3].Width = 190;
            dataGridView1.Columns[4].Width = 175;
            dataGridView1.Columns[5].Width = 190;

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[4].DefaultCellStyle.Format = "$#,##0.00";
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregar_Ingrediente Agregar_Ingrediente = new FrmAgregar_Ingrediente(this);
            Agregar_Ingrediente.UpdateEventHandler += AgIng_UpdateEventHandler;
            Agregar_Ingrediente.ShowDialog();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        public override void Eliminar()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros para eliminar.", "Eliminar Ingrediente", MessageBoxButtons.OK,
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
                        DialogResult Resultados = MessageBox.Show("¿Está seguro de eliminar el ingrediente?",
                            "Eliminar Ingrediente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Ingrediente.Id_Ingrediente = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Ingredientes.EliminarIngrediente(Ingrediente);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione un registro.", "Eliminar Ingrediente", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtBuscarIngrediente_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        public override void Buscar()
        {
            try
            {
                if (cboTipoBusqueda.Text == "Código")
                {
                    Ingrediente.Buscar = txtBuscarIngrediente.Text.Trim();
                    dataGridView1.DataSource = Ingredientes.BuscarIngrediente_Codigo(Ingrediente);
                }
                else if (cboTipoBusqueda.Text == "Nombre")
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registro para editar.", "Editar Ingrediente", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (dataGridView1.SelectedRows == null)
                    {
                        return;
                    }
                    else
                    {
                        FrmEditar_Ingrediente Editar_Ingrediente = new FrmEditar_Ingrediente(this);
                        Editar_Ingrediente.UpdateEventHandler += EdIng_UpdateEventHandler;

                        Editar_Ingrediente.txtId_Ingrediente.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        Editar_Ingrediente.txtCodigo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        Editar_Ingrediente.txtNombre.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        Editar_Ingrediente.txtPrecio.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        Editar_Ingrediente.CboUnidadMedida.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                        Editar_Ingrediente.CboCategoria.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

                        Editar_Ingrediente.ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione un registro.", "Editar Ingrediente", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}