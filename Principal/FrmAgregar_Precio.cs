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
    public partial class FrmAgregar_Precio : FrmBase
    {
        public FrmAgregar_Precio(FrmPrecios Precios)
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

        protected void Agregar()
        {
            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }

        private void FrmAgregar_Precio_Load(object sender, EventArgs e)
        {
            MejorarVista();
            txtTotal.Text = "0.00";
            Codigos();
        }

        private void MejorarVista()
        {
            dataGridView1.Columns[0].Visible = false; // id ingrediente

            dataGridView1.Columns[1].Width = 200; // ingrediente
            dataGridView1.Columns[2].Width = 140; // cantidad
            dataGridView1.Columns[3].Width = 130; // precio
            dataGridView1.Columns[4].Width = 130; // costo total

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[3].DefaultCellStyle.Format = "$#0.00";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "$#0.00";
        }

        private void Codigos()
        {
            txtId_Precio.Text = Procedimientos.GenerarCodigoId("Precios");
            txtId_Ficha.Text = Procedimientos.GenerarCodigoId("FichaTecnica");
        }

        private void btnBuscarPlatillo_Click(object sender, EventArgs e)
        {
            FrmVista_Platillos VistaPlatillo = new FrmVista_Platillos();
            VistaPlatillo.ShowDialog();

            try
            {
                if (VistaPlatillo.DialogResult == DialogResult.OK)
                {
                    txtId_Platillo.Text = VistaPlatillo.dataGridView1.Rows[VistaPlatillo.dataGridView1.CurrentRow.
                        Index].Cells[0].Value.ToString();
                    txtNombrePlatillo.Text = VistaPlatillo.dataGridView1.Rows[VistaPlatillo.dataGridView1.CurrentRow.
                        Index].Cells[2].Value.ToString();
                    txtCategoria.Text = VistaPlatillo.dataGridView1.Rows[VistaPlatillo.dataGridView1.CurrentRow.
                        Index].Cells[3].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un platillo de la lista.", "Seleccionar Platillo",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarIngrediente();
        }

        public static int ContadorFilas = 0;
        public static decimal Total;

        private void AgregarIngrediente()
        {
            decimal SubTotal = 0;

            try
            {
                if (txtId_Ingrediente.Text == string.Empty || txtNombreIngrediente.Text == string.Empty
                || txtCantidad.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos.", "Agregar Ingrediente", MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    bool Existe = false;
                    int num_fila = 0;

                    if (ContadorFilas == 0)
                    {
                        SubTotal = (Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text)) / 1000;

                        dataGridView1.Rows.Add(txtId_Ingrediente.Text, txtNombreIngrediente.Text,
                            txtCantidad.Text, txtPrecio.Text, SubTotal.ToString("N2"));

                        dataGridView1.ClearSelection();
                        LimpiarDetalle();
                        btnAgregar.Focus();
                        ContadorFilas++;
                    }
                    else
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells[0].Value.ToString() == txtId_Ingrediente.Text)
                            {
                                Existe = true;
                                num_fila = row.Index;
                            }
                        }
                        if (Existe == true) 
                        {
                            SubTotal = (Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text)) / 1000;
                            dataGridView1.Rows[num_fila].Cells[2].Value = Convert.ToDouble(txtCantidad.Text) +
                                Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value.ToString());
                            dataGridView1.Rows[num_fila].Cells[4].Value = (SubTotal + Convert.ToDecimal(
                                dataGridView1.Rows[num_fila].Cells[4].Value)).ToString("N2");

                            LimpiarDetalle();
                        }
                        else
                        {
                            SubTotal = (Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text)) / 1000;

                            dataGridView1.Rows.Add(txtId_Ingrediente.Text, txtNombreIngrediente.Text,
                                txtCantidad.Text, txtPrecio.Text, SubTotal.ToString("N2"));

                            dataGridView1.ClearSelection();
                            LimpiarDetalle();
                            btnAgregar.Focus();
                            ContadorFilas++;
                        }
                    }
                    Total = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Total += Convert.ToDecimal(row.Cells[4].Value);
                    }
                    txtTotal.Text = Total.ToString("N2");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("El ingrediente no fue agregado por:" + ex.Message, "Agregar Ingrediente",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDetalle()
        {
            txtId_Ingrediente.Text = string.Empty;
            txtNombreIngrediente.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
        }

        private void LimpiarCampos()
        {
            txtId_Precio.Text = string.Empty;
            txtId_Platillo.Text = string.Empty;
            txtNombrePlatillo.Text = string.Empty;
            txtPorciones.Text = string.Empty;
            txtCategoria.Text = string.Empty;

            dataGridView1.Rows.Clear();
        }

        private void btnBuscarIngrediente_Click(object sender, EventArgs e)
        {
            FrmVista_Ingredientes VistaIngrediente = new FrmVista_Ingredientes();
            VistaIngrediente.ShowDialog();

            try
            {
                if (VistaIngrediente.DialogResult == DialogResult.OK)
                {
                    txtId_Ingrediente.Text = VistaIngrediente.dataGridView1.Rows[VistaIngrediente.dataGridView1.CurrentRow.
                        Index].Cells[0].Value.ToString();
                    txtNombreIngrediente.Text = VistaIngrediente.dataGridView1.Rows[VistaIngrediente.dataGridView1.CurrentRow.
                        Index].Cells[2].Value.ToString();
                    txtPrecio.Text = VistaIngrediente.dataGridView1.Rows[VistaIngrediente.dataGridView1.CurrentRow.
                        Index].Cells[4].Value.ToString();
                    txtCantidad.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un ingrediente de la lista.", "Seleccionar Ingrediente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ContadorFilas > 0)
                {
                    Total = Total - Convert.ToDecimal(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value);
                    txtTotal.Text = Total.ToString("N2");

                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    ContadorFilas--;
                }
            }
            catch
            {
                MessageBox.Show("No existen registros para eliminar.", "Eliminar Ingrediente",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void FrmAgregar_Precio_Shown(object sender, EventArgs e)
        {
            btnBuscarPlatillo.Focus();
        }

        private void btnBuscarPlatillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPorciones.Focus();
                e.Handled = true;
            }
        }

        private void txtPorciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnBuscarIngrediente.Focus();
                e.Handled = true;
            }
        }

        private void btnBuscarIngrediente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCantidad.Focus();
                e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                btnInsertar.Focus();
                e.Handled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public override bool Guardar()
        {
            try
            {
                if (txtId_Precio.Text == string.Empty || txtNombrePlatillo.Text == string.Empty ||
                txtPorciones.Text == string.Empty || txtId_Platillo.Text == string.Empty)
                {
                    MessageBox.Show("Por favor rellene todos los campos.", "Agregar Ficha Técnica",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Preci.Id_Platillo = Convert.ToInt32(txtId_Platillo.Text);
                    Preci.Nombre = txtNombrePlatillo.Text;
                    Preci.Porciones = Convert.ToInt32(txtPorciones.Text);
                    Preci.Precio_Invertido = Convert.ToDecimal(txtTotal.Text) / Convert.ToInt32(txtPorciones.Text);
                    Preci.Precio_Venta = Convert.ToDecimal(Preci.Precio_Invertido * 3);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Ficha.Id_Precio = Convert.ToInt32(txtId_Precio.Text);
                        Ficha.Id_Ingrediente = Convert.ToInt32(row.Cells[0].Value.ToString());
                        Ficha.Nombre = Convert.ToString(row.Cells[1].Value.ToString());
                        Ficha.Cantidad = Convert.ToInt32(row.Cells[2].Value.ToString());
                        Ficha.Precio = Convert.ToDecimal(row.Cells[3].Value.ToString());
                        Ficha.Costo_Total = Convert.ToDecimal(row.Cells[4].Value.ToString());

                        Fichas.AgregarFicha(Ficha);
                    }
                    Precios.AgregarPrecio(Preci);

                    MessageBox.Show("Ficha Técnica Registrada", "Agregar Ficha Técnica", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Procedimientos.LimpiarControles(this);
                    txtId_Ficha.Text = string.Empty;
                    txtTotal.Text = "0.00";
                    Agregar();
                    LimpiarDetalle();
                    LimpiarCampos();
                    Codigos();
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ficha Técnica no registrada por: " + ex.Message, "Agregar Ficha Técnica",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
