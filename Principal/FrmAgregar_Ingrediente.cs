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
    public partial class FrmAgregar_Ingrediente : FrmBase
    {
        public FrmAgregar_Ingrediente(FrmIngredientes Ingredientes)
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

        protected void Agregar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void GenerarCodigo()
        {
            txtCodigo.Text = "I" + Procedimientos.GenerarCodigo("Ingredientes");
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

        private void txtPrecio_Leave(object sender, EventArgs e)
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
                btnGuardar.Focus();
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void FrmAgregar_Ingrediente_Shown(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void FrmAgregar_Ingrediente_Load(object sender, EventArgs e)
        {
            GenerarCodigo();
        }

        public override bool Guardar()
        {
            try
            {
                if (txtCodigo.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecio.Text == string.Empty
                    || CboUnidadMedida.Text == string.Empty || CboCategoria.Text == string.Empty)
                {
                    MessageBox.Show("Favor de rellenar todos los campos.", "Agregar Ingrediente",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Ingrediente.Codigo = txtCodigo.Text.Trim();
                    Ingrediente.Nombre = txtNombre.Text.Trim();
                    Ingrediente.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());
                    Ingrediente.Unidad_Medida = CboUnidadMedida.Text.Trim();
                    Ingrediente.Categoria = CboCategoria.Text.Trim();

                    Ingredientes.AgregarIngrediente(Ingrediente);
                    MessageBox.Show("Ingrediente ingresado correctamente.", "Agregar Ingrediente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Procedimientos.LimpiarControles(this);

                    GenerarCodigo();
                    txtNombre.Focus();
                    Agregar();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Ingrediente no fue agregado por: " + ex.Message,
                    "Agregar Ingrediente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
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
                else if(control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1;
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
