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
    public partial class FrmEditar_Proveedor : FrmBase
    {
        public FrmEditar_Proveedor(FrmProveedores Proveedores)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Proveedores Proveedores = new CDo_Proveedores();
        CE_Proveedores Proveedor = new CE_Proveedores();

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

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNombre.Focus();
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CboCategoria.Focus();
                e.Handled = true;
            }
        }

        private void CboCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtDireccion.Focus();
                e.Handled = true;
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                mtbTelefono.Focus();
                e.Handled = true;
            }
        }

        private void mtbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtEmail.Focus();
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnEditar.Focus();
                e.Handled = true;
            }
        }

        private void FrmEditar_Proveedor_Shown(object sender, EventArgs e)
        {
            txtMatricula.Focus();
        }

        public override void Editar()
        {
            try
            {
                if (txtCodigo.Text == string.Empty || txtMatricula.Text == string.Empty || txtNombre.Text == string.Empty ||
                    CboCategoria.Text == string.Empty || txtDireccion.Text == string.Empty ||
                    mtbTelefono.Text == string.Empty || txtEmail.Text == string.Empty)
                {
                    MessageBox.Show("Favor de rellenar todos los campos.", "Editar Proveedor",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Proveedor.Id_Proveedor = Convert.ToInt32(txtId_Proveedor.Text.Trim());
                    Proveedor.Codigo = txtCodigo.Text.Trim();
                    Proveedor.Matricula = txtMatricula.Text.Trim();
                    Proveedor.Nombre = txtNombre.Text.Trim();
                    Proveedor.Categoria = CboCategoria.Text.Trim();
                    Proveedor.Direccion = txtDireccion.Text.Trim();
                    Proveedor.Telefono = mtbTelefono.Text.Trim();
                    Proveedor.Email = txtEmail.Text.Trim();

                    Proveedores.EditarProveedor(Proveedor);
                    MessageBox.Show("Proveedor actualizado correctamente.", "Editar Proveedor",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Procedimientos.LimpiarControles(this);
                    this.Close();
                    Actualizar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El proveedor no fue editado por: " + ex.Message,
                    "Editar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name == "txtCodigo")
                {
                    continue;
                }

                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is ComboBox)
                {
                    (control as ComboBox).Text = string.Empty;
                }
                else if (control is MaskedTextBox)
                {
                    (control as MaskedTextBox).Text = string.Empty;
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }
    }
}
