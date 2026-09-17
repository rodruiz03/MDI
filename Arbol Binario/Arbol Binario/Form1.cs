using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Arbol_Binario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Pagina 13
        //Delaracion de variables a utilizar
        int Dato = 0;
        int cont = 0;

        Arbol_Binario mi_Arbol = new Arbol_Binario(null);
        Graphics g;

        //Pagina 14

        private void Form1_Paint (object sender, PaintEventArgs en)
        {
            en.Graphics.Clear(this.BackColor);
            en.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            en.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g = en.Graphics;

            mi_Arbol.DibujarArbol(g, this.Font, Brushes.Blue, Brushes.White, Pens.Black, Brushes.White);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtDato.Text == "")
            {
                MessageBox.Show("Debe Ingresar un Valor");
            }
            else
            {
                Dato = int.Parse(txtDato.Text);
                if (Dato <= 0 || Dato >= 100)
                    MessageBox.Show("Solo Recibe Valores desde 1 hasta 99", "Error de Ingreso");
                else
                {
                    mi_Arbol.Insertar(Dato);

                    txtDato.Clear();
                    txtDato.Focus();

                    cont++;

                    Refresh();
                    Refresh();
                    

                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }

}

