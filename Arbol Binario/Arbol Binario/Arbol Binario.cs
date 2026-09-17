using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace Arbol_Binario
{
    internal class Arbol_Binario
    {
        public Nodo_Arbol Raiz;
        public Nodo_Arbol aux;

        //Constructor por defecto
        public Arbol_Binario()
        {
            aux = new Nodo_Arbol();
        }

        //Paguina 11
        //Constructor con parametros
        public Arbol_Binario (Nodo_Arbol nueva_raiz)
        {
            Raiz = nueva_raiz;
        }

        //Fundacion para agregar nuevo valor a arbol Binario
        public void Insertar(int x)
        {
            if (Raiz == null)
            {
                Raiz = new Nodo_Arbol(x, null, null, null);
                Raiz.nivel = 0;
            }
            else
                Raiz = Raiz.Insertar (x, Raiz, Raiz.nivel);
        }

        //Funcion para eliminar un nodo (valor) del Arbol Binario
        public void Eliminar(int x)
        {
            if (Raiz == null)
                Raiz = new Nodo_Arbol(x, null, null, null);
            else
                Raiz.Eliminar(x, ref Raiz);
        }

        //Funciones para el dibujo del Arbol Binario en el Formulario
        //Funciones que dibuja el Arbol Binario
        public void DibujarArbol(Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Brush encuentro)
        {
            int x = 400;
            int y = 75;

            if (Raiz == null) return;
            Raiz.PosicionNodo (ref x, y);
            Raiz.DibujarRamas (grafo, Lapiz);
            Raiz.DibujarNodo (grafo, fuente, Relleno, RellenoFuente, Lapiz, encuentro);
        }

        //Paguina 12
        public int x1 = 400;
        public int y2 = 75;
        //Funcion para colorear los nodos

        public void colorear (Graphics grafo, Font fuente, Brush Relleno, Brush RellenoFuente, Pen Lapiz, Nodo_Arbol Raiz, bool post, bool inor, bool preor)
        {
            Brush entorno = Brushes.Red;

            if (inor == true)
            {
                if (Raiz != null)
                {
                    colorear (grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear (grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);
                }
            }

            else if (preor == true)
            {
                if (Raiz != null)
                {
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);
                }
            }
            else if (post == true)
            {
                if (Raiz != null)
                {
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Izquierdo, post, inor, preor);
                    colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz, Raiz.Derecho, post, inor, preor);
                    Raiz.colorear(grafo, fuente, entorno, RellenoFuente, Lapiz);
                    Thread.Sleep(1000);
                    Raiz.colorear(grafo, fuente, Relleno, RellenoFuente, Lapiz);
                }
            }
        }

    }
}

