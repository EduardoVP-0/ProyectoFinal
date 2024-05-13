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
    public partial class FrmPedidos : FrmBase
    {
        public FrmPedidos(FrmVentas Ventas)
        {
            InitializeComponent();
        }

        CDo_Procedimientos Procedimientos = new CDo_Procedimientos();
        CDo_Ventas Ventas = new CDo_Ventas();
        CE_Ventas Venta = new CE_Ventas();
        CDo_Pedidos Pedidos = new CDo_Pedidos();
        CE_Pedidos Pedido = new CE_Pedidos();

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

        private void FrmPedidos_Load(object sender, EventArgs e)
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
            txtId_Venta.Text = Procedimientos.GenerarCodigoId("Ventas");
            txtNumero.Text = "V" + Procedimientos.GenerarCodigo("Ventas");
            txtComprobante.Text = Procedimientos.GenerarComprobante("Ventas");
            txtId_Pedido.Text = Procedimientos.GenerarCodigoId("Pedidos");
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

                    if (ContadorFilas == 0)
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
            txtId_Venta.Text = string.Empty;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public override bool Guardar()
        {
            try
            {
                if (txtId_Venta.Text == string.Empty || txtNombreProveedor.Text == string.Empty ||
                txtComprobante.Text == string.Empty || txtId_Proveedor.Text == string.Empty ||
                txtNumero.Text == string.Empty)
                {
                    MessageBox.Show("Por favor rellene todos los campos.", "Agregar Compra",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Venta.No_Venta = txtNumero.Text;
                    Venta.Id_Proveedor = Convert.ToInt32(txtId_Proveedor.Text);
                    Venta.Nombre = txtNombreProveedor.Text;
                    Venta.Fecha_Venta = Convert.ToDateTime(dtpFecha.Text);
                    Venta.Comprobante = txtComprobante.Text;
                    Venta.Total = Convert.ToDecimal(txtTotal.Text);
                    Venta.Estado = "Comprado";

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        /*Pedido.Id_Venta = Convert.ToInt32(txtId_Venta.Text);
                        Pedido.Id_Ingrediente = Convert.ToInt32(row.Cells[0].Value.ToString());
                        Pedido.Nombre = Convert.ToString(row.Cells[1].Value.ToString());
                        Pedido.Cantidad = Convert.ToInt32(row.Cells[2].Value.ToString());
                        Pedido.Precio = Convert.ToDecimal(row.Cells[3].Value.ToString());
                        Pedido.Coste_Total = Convert.ToDecimal(row.Cells[4].Value.ToString());*/

                        //Pedidos.AgregarPedido(Pedido);
                    }
                    Ventas.AgregarVenta(Venta);

                    MessageBox.Show("Compra Registrada", "Agregar Compra", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Procedimientos.LimpiarControles(this);
                    txtId_Pedido.Text = string.Empty;
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
    }
}
