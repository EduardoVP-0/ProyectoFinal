using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Principal
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void tmTiempo_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void platillosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPlatillos Platillos = new FrmPlatillos();
            Platillos.ShowDialog();
        }

        private void ingredientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngredientes Ingredientes = new FrmIngredientes();
            Ingredientes.ShowDialog();
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInventario Inventario = new FrmInventario();
            Inventario.ShowDialog();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompras Compras = new FrmCompras();
            Compras.ShowDialog();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedores Proveedores = new FrmProveedores();
            Proveedores.ShowDialog();
        }

        private void preciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrecios Precios = new FrmPrecios();
            Precios.ShowDialog();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas Ventas = new FrmVentas();
            Ventas.ShowDialog();
        }

        private void btnArduino_Click(object sender, EventArgs e)
        {
            ProyectoSistemas Arduino = new ProyectoSistemas();
            Arduino.ShowDialog();
        }
    }
}
