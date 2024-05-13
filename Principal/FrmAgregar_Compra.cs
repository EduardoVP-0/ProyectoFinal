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
    public partial class FrmAgregar_Compra : FrmBase
    {
        public FrmAgregar_Compra(FrmCompras Compras)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Compras Compras = new CDo_Compras();
        CE_Compras Compra = new CE_Compras();
        CDo_Detalles Detalles = new CDo_Detalles();
        CE_Detalles Detalle = new CE_Detalles();

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

        private void FrmAgregar_Compra_Load(object sender, EventArgs e)
        {
            MejorarVista();
            txtTotal.Text = "0.00";
            Codigos();
        }

        private void MejorarVista()
        {
            dataGridView1.Columns[0].Visible = false; // id ingrediente

            dataGridView1.Columns[1].Width = 228; // ingrediente
            dataGridView1.Columns[2].Width = 160; // cantidad
            dataGridView1.Columns[3].Width = 170; // precio
            dataGridView1.Columns[4].Width = 150; // coste total

            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[3].DefaultCellStyle.Format = "$#0.00";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "$#0.00";
        }

        private void Codigos()
        {
            txtId_Compra.Text = Procedimientos.GenerarCodigoId("Compras");
            txtNumero.Text = "A" + Procedimientos.GenerarCodigo("Compras");
            txtComprobante.Text = Procedimientos.GenerarComprobante("Compras");
            txtId_Detalle.Text = Procedimientos.GenerarCodigoId("Detalles");
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVista_Proveedores VistaProveedor = new FrmVista_Proveedores();
            VistaProveedor.ShowDialog();

            try
            {
                if (VistaProveedor.DialogResult == DialogResult.OK)
                {
                    txtId_Proveedor.Text = VistaProveedor.dataGridView1.Rows[VistaProveedor.dataGridView1.CurrentRow.
                        Index].Cells[0].Value.ToString();
                    txtNombreProveedor.Text = VistaProveedor.dataGridView1.Rows[VistaProveedor.dataGridView1.CurrentRow.
                        Index].Cells[3].Value.ToString();
                    txtCategoria.Text = VistaProveedor.dataGridView1.Rows[VistaProveedor.dataGridView1.CurrentRow.
                        Index].Cells[4].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un proveedor de la lista.", "Seleccionar Proveedor",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } 

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        public static int ContadorFilas = 0;
        public static decimal Total;

        private void AgregarDetalle()
        {
            decimal SubTotal = 0;

            try
            {
                if (txtId_Ingrediente.Text == string.Empty || txtNombreIngrediente.Text == string.Empty
                || txtCantidad.Text == string.Empty)
                {
                    MessageBox.Show("Debe completar todos los campos.", "Agregar Detalle", MessageBoxButtons.OK, 
                        MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {
                    bool Existe = false;
                    int num_fila = 0;
                    
                    if(ContadorFilas == 0)
                    {
                        SubTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text);

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
                            SubTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text);
                            dataGridView1.Rows[num_fila].Cells[2].Value = Convert.ToDouble(txtCantidad.Text) +
                                Convert.ToDouble(dataGridView1.Rows[num_fila].Cells[2].Value.ToString());
                            dataGridView1.Rows[num_fila].Cells[4].Value = (SubTotal + Convert.ToDecimal(
                                dataGridView1.Rows[num_fila].Cells[4].Value)).ToString("N2");

                            LimpiarDetalle();
                        }
                        else
                        {
                            SubTotal = Convert.ToDecimal(txtCantidad.Text) * Convert.ToDecimal(txtPrecio.Text);

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
            catch (Exception ex)
            {
                MessageBox.Show("El ingrediente no fue agregado por:" + ex.Message, "Agregar Ingrediente",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarDetalle()
        {
            txtId_Ingrediente.Text = string.Empty;
            txtNombreIngrediente.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
        }

        private void LimpiarCampos()
        {
            txtId_Compra.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtId_Proveedor.Text = string.Empty;
            txtNombreProveedor.Text = string.Empty;

            txtComprobante.Text = string.Empty;
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
                    txtCodigo.Text = VistaIngrediente.dataGridView1.Rows[VistaIngrediente.dataGridView1.CurrentRow.
                        Index].Cells[1].Value.ToString();
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
                if(ContadorFilas > 0)
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

        private void FrmAgregar_Compra_Shown(object sender, EventArgs e)
        {
            btnBuscarProveedor.Focus();
        }

        private void btnBuscarProveedor_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtId_Compra.Text == string.Empty || txtNombreProveedor.Text == string.Empty ||
                txtComprobante.Text == string.Empty || txtId_Proveedor.Text == string.Empty ||
                txtNumero.Text == string.Empty)
                {
                    MessageBox.Show("Por favor rellene todos los campos.", "Agregar Compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Compra.No_Compra = txtNumero.Text;
                    Compra.Id_Proveedor = Convert.ToInt32(txtId_Proveedor.Text);
                    Compra.Nombre = txtNombreProveedor.Text;
                    Compra.Fecha_Compra = Convert.ToDateTime(dtpFecha.Text);
                    Compra.Comprobante = txtComprobante.Text;

                    //MANTENER EL COMPROBANTE DE COMPRA
                    ProyectoSistemas ProyectoS = new ProyectoSistemas();
                    AddOwnedForm(ProyectoS);
                    ProyectoS.txtComprobante.Text = this.txtComprobante.Text;
                    ProyectoS.Show();

                    Compra.Total = Convert.ToDecimal(txtTotal.Text);
                    Compra.Estado = "Comprado";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Detalle.Id_Compra = Convert.ToInt32(txtId_Compra.Text);
                        Detalle.Id_Ingrediente = Convert.ToInt32(row.Cells[0].Value.ToString());
                        Detalle.Nombre = Convert.ToString(row.Cells[1].Value.ToString());
                        Detalle.Cantidad = Convert.ToInt32(row.Cells[2].Value.ToString());
                        Detalle.Precio = Convert.ToDecimal(row.Cells[3].Value.ToString());
                        Detalle.Coste_Total = Convert.ToDecimal(row.Cells[4].Value.ToString());

                        Detalles.AgregarDetalle(Detalle);
                    }
                    Compras.AgregarCompra(Compra);

                    MessageBox.Show("Compra Registrada", "Agregar Compra", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Procedimientos.LimpiarControles(this);
                    txtId_Detalle.Text = string.Empty;
                    txtTotal.Text = "0.00";
                    Agregar();
                    LimpiarDetalle();
                    LimpiarCampos();
                    Codigos();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Compra no registrada por: " + ex.Message, "Agregar Compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
