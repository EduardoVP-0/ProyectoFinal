using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Clase_Dominio;
using Clase_Entidad;

namespace Principal
{
    public partial class FrmPlatillos : FrmBase
    {
        public FrmPlatillos()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Platillos Platillos = new CDo_Platillos();
        CE_Platillos Platillo = new CE_Platillos();

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Platillos");
            dataGridView1.ClearSelection();
        }

        private void AgPl_UpdateEventHandler(object sender, FrmAgregar_Platillo.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void EdPl_UpdateEventHandler(object sender, FrmEditar_Platillo.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void FrmPlatillos_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;

            dataGridView1.Columns[2].Width = 222;

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregar_Platillo Agregar_Platillo = new FrmAgregar_Platillo(this);
            Agregar_Platillo.UpdateEventHandler += AgPl_UpdateEventHandler;
            Agregar_Platillo.ShowDialog();
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
                        FrmEditar_Platillo Editar_Platillo = new FrmEditar_Platillo(this);
                        Editar_Platillo.UpdateEventHandler += EdPl_UpdateEventHandler;

                        Editar_Platillo.txtId_Platillo.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        Editar_Platillo.txtCodigo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        Editar_Platillo.txtNombre.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        Editar_Platillo.CboCategoria.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                        Editar_Platillo.txtDescripcion.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        Editar_Platillo.CboEstado.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

                        Editar_Platillo.ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione un platillo.", "Editar Platillo", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCategoria.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            object imageCell = dataGridView1.CurrentRow.Cells[6].Value;
            if (imageCell is byte[] imageBytes)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pbImagen.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pbImagen.Image = null; 
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        public override void Eliminar()
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No existen registros para eliminar.", "Eliminar Platillo", MessageBoxButtons.OK,
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
                        DialogResult Resultados = MessageBox.Show("¿Está seguro de eliminar el Platillo?",
                            "Eliminar Platillo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Platillo.Id_Platillo = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Platillos.EliminarPlatillo(Platillo);
                            MessageBox.Show("Platillo eliminado correctamente.", "Eliminar Platillo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione un registro.", "Eliminar Platillo", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtBuscarPlatillo_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        public override void Buscar()
        {
            try
            {
                if (cboTipoBusqueda.Text == "Código")
                {
                    Platillo.Buscar = txtBuscarPlatillo.Text.Trim();
                    dataGridView1.DataSource = Platillos.BuscarPlatillo_Codigo(Platillo);
                }
                else if (cboTipoBusqueda.Text == "Nombre")
                {
                    Platillo.Buscar = txtBuscarPlatillo.Text.Trim();
                    dataGridView1.DataSource = Platillos.BuscarPlatillo_Nombre(Platillo);
                }
                else if (cboTipoBusqueda.Text == "Categoría")
                {
                    Platillo.Buscar = txtBuscarPlatillo.Text.Trim();
                    dataGridView1.DataSource = Platillos.BuscarPlatillo_Categoria(Platillo);
                }
                else if (cboTipoBusqueda.Text == "Estado")
                {
                    Platillo.Buscar = txtBuscarPlatillo.Text.Trim();
                    dataGridView1.DataSource = Platillos.BuscarPlatillo_Estado(Platillo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Platillo no encontrado." + ex.Message, "Buscar Platillo", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }
    }
}
