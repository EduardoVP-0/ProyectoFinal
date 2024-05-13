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
    public partial class FrmEditar_Ingrediente : FrmBase
    {
        public FrmEditar_Ingrediente(FrmIngredientes Ingredientes)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Ingredientes Ingredientes = new CDo_Ingredientes();
        CE_Ingredientes Ingrediente = new CE_Ingredientes();

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

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPrecio.Focus();
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CboUnidadMedida.Focus();
                e.Handled = true;
            }
        }

        private void txtPrecio_MouseLeave(object sender, EventArgs e)
        {
            Procedimientos.FormatoMoneda(txtPrecio);
        }

        private void CboUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
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
                btnEditar.Focus();
                e.Handled = true;
            }
        }

        public override void Editar()
        {
            try
            {
                if (txtCodigo.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty
                    || CboUnidadMedida.Text == string.Empty || CboCategoria.Text == string.Empty)
                {
                    MessageBox.Show("Favor de rellenar todos los campos.", "Editar Ingrediente",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Ingrediente.Id_Ingrediente = Convert.ToInt32(txtId_Ingrediente.Text.Trim());
                    Ingrediente.Codigo = txtCodigo.Text.Trim();
                    Ingrediente.Nombre = txtNombre.Text.Trim();
                    Ingrediente.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                    Ingrediente.Unidad_Medida = CboUnidadMedida.Text.Trim();
                    Ingrediente.Categoria = CboCategoria.Text.Trim();

                    Ingredientes.EditarIngrediente(Ingrediente);
                    MessageBox.Show("Ingrediente actualizado correctamente.", "Editar Ingrediente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Procedimientos.LimpiarControles(this);
                    this.Close();
                    Actualizar();
                }
            }          
            catch (Exception ex)
            {
                MessageBox.Show("El Ingrediente no fue actualizado por: " + ex.Message,
                    "Editar Ingrediente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    if (control.Name == "txtCodigo")
                    {
                        continue;
                    }
                    else
                    {
                        control.Text = string.Empty;
                    }
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Editar();
        }
    }
}
