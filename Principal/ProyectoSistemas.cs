using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports; //CONEXION
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clase_Entidad;
using Clase_Dominio;

namespace Principal
{
    public partial class ProyectoSistemas : Form
    {
        public SerialPort puertoSerial { get; }

        public ProyectoSistemas()
        {
            //CONEXION CON ARDUINO
            InitializeComponent();
           
            puertoSerial = new System.IO.Ports.SerialPort();
            puertoSerial.PortName = "COM3";
            puertoSerial.BaudRate = 9600;
            
            

        }
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!puertoSerial.IsOpen)
            {
                puertoSerial.Open();
            }
            //RECUPERAR VALORES DEL TEXTBOX
            string comprobante = txtComprobante.Text;

            //TRANSFORMAR CARACTER POR CARACTER A CODIGO ASCII
            for (int i = 0; i < comprobante.Length; i++)
            {
                
                int x = (int)comprobante.ToString()[i];
                string txt2 = x.ToString();
                puertoSerial.Write(txt2);
            }

            //COMPROBACION
            Console.WriteLine("Se envio correctamente el mensaje" + comprobante);
        }

        private void ProyectoSistemas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (puertoSerial.IsOpen)
                puertoSerial.Close();
        }

        
    }
}
    
