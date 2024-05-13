using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Clase_Dominio;
using Clase_Entidad;

namespace Principal
{
    public partial class FrmAgregar_Platillo : FrmBase
    {
        public FrmAgregar_Platillo(FrmPlatillos Platillos)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Platillos Platillos = new CDo_Platillos();
        CE_Platillos Platillo = new CE_Platillos();

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
            txtCodigo.Text = "P" + Procedimientos.GenerarCodigo("Platillos");
        }

        private void FrmAgregar_Platillo_Shown(object sender, EventArgs e)
        {
            txtNombre.Focus();
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
                txtDescripcion.Focus();
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CboEstado.Focus();
                e.Handled = true;
            }
        }

        private void CboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnAgregar.Focus();
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public override bool Guardar()
        {
            try
            {
                if (txtCodigo.Text == string.Empty || txtNombre.Text == string.Empty ||
                    CboCategoria.Text == string.Empty || txtDescripcion.Text == string.Empty ||
                    CboEstado.Text == string.Empty || pbImagen.Image == null)
                {
                    MessageBox.Show("Favor de rellenar todos los campos.", "Agregar Platillo",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        if (pbImagen.Image != null)
                        {
                            pbImagen.Image.Save(ms, ImageFormat.Jpeg);
                            byte[] aByte = ms.ToArray();

                            Platillo.Codigo = txtCodigo.Text.Trim();
                            Platillo.Nombre = txtNombre.Text.Trim();
                            Platillo.Categoria = CboCategoria.Text.Trim();
                            Platillo.Descripcion = txtDescripcion.Text.Trim();
                            Platillo.Estado = CboEstado.Text.Trim();
                            Platillo.Foto = aByte;

                            Platillos.AgregarPlatillo(Platillo);
                            MessageBox.Show("Platillo registrado correctamente.", "Agregar Platillo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Procedimientos.LimpiarControles(this);

                            GenerarCodigo();
                            txtNombre.Focus();
                            Agregar();
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No hay imagen para guardar.", "Agregar Platillo",
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El Platillo no fue agregado por un error: " + ex.Message,
                    "Agregar Platillo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void FrmAgregar_Platillo_Load(object sender, EventArgs e)
        {
            GenerarCodigo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "FrmPlatillos|*.jgp; *.png; *.jpeg;";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar Imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                pbImagen.Image = Image.FromFile(ofdSeleccionar.FileName);
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
    }
}
