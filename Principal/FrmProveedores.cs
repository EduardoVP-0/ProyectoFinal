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
    public partial class FrmProveedores : FrmBase
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Proveedores Proveedores = new CDo_Proveedores();
        CE_Proveedores Proveedor = new CE_Proveedores();

        private void CargarDatos()
        {
            dataGridView1.DataSource = Procedimientos.CargarDatos("Proveedores");
            dataGridView1.ClearSelection();
        }

        private void AgPro_UpdateEventHandler(object sender, FrmAgregar_Proveedor.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void EdPro_UpdateEventHandler(object sender, FrmEditar_Proveedor.UpdateEventArgs args)
        {
            CargarDatos();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarDatos();

            dataGridView1.Columns[0].Visible = false;

            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].Width = 190;
            dataGridView1.Columns[5].Width = 205;
            dataGridView1.Columns[6].Width = 130;
            dataGridView1.Columns[7].Width = 190;

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAgregar_Proveedor Agregar_Proveedor = new FrmAgregar_Proveedor(this);
            Agregar_Proveedor.UpdateEventHandler += AgPro_UpdateEventHandler;
            Agregar_Proveedor.ShowDialog();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay registro para editar.", "Editar Proveedor", MessageBoxButtons.OK,
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
                        FrmEditar_Proveedor Editar_Proveedor = new FrmEditar_Proveedor(this);
                        Editar_Proveedor.UpdateEventHandler += EdPro_UpdateEventHandler;

                        Editar_Proveedor.txtId_Proveedor.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                        Editar_Proveedor.txtCodigo.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        Editar_Proveedor.txtMatricula.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        Editar_Proveedor.txtNombre.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                        Editar_Proveedor.CboCategoria.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                        Editar_Proveedor.txtDireccion.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                        Editar_Proveedor.mtbTelefono.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                        Editar_Proveedor.txtEmail.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

                        Editar_Proveedor.ShowDialog();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione un registro.", "Editar Proveedor", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
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
                MessageBox.Show("No existen registros para eliminar.", "Eliminar Proveedor", MessageBoxButtons.OK,
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
                        DialogResult Resultados = MessageBox.Show("¿Está seguro de eliminar el Proveedor?",
                            "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Resultados == DialogResult.Yes)
                        {
                            Proveedor.Id_Proveedor = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                            Proveedores.EliminarProveedor(Proveedor);
                            MessageBox.Show("Proveedor eliminado correctamente.", "Eliminar Proveedor",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDatos();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Por favor seleccione un registro.", "Eliminar Proveedor", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        public override void Buscar()
        {
            try
            {
                if (cboTipoBusqueda.Text == "Código")
                {
                    Proveedor.Buscar = txtBuscarProveedor.Text.Trim();
                    dataGridView1.DataSource = Proveedores.BuscarProveedor_Codigo(Proveedor);
                }
                else if (cboTipoBusqueda.Text == "Matrícula")
                {
                    Proveedor.Buscar = txtBuscarProveedor.Text.Trim();
                    dataGridView1.DataSource = Proveedores.BuscarProveedor_Matricula(Proveedor);
                }
                else if (cboTipoBusqueda.Text == "Nombre")
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
    }
}
