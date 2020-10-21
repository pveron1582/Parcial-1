using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verón_Pablo___Parcial
{
    public partial class Form1 : Form         
    {
        //declaracion de matriz zzz
        int[,] matriz;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //bloqueo al cargar form de algunos elementos
            txt_vaca.Enabled = false;
            txt_dia.Enabled = false;
            txt_litros.Enabled = false;
            btn_ingresar_datos.Enabled = false;

            btn_calcular.Enabled = false;
            btn_buscar.Enabled = false;
            btn_promedio.Enabled = false;
            txt_buscar_vaca.Enabled = false;
        }

        private void btn_ingresar_vacas_Click(object sender, EventArgs e)
        {
            //no puede quedar el textbox en blanco
            if(txt_cantidad_vacas.Text == "")
            {
                MessageBox.Show("Ingrese un Valor");
            }
            else
            {
                //la cantidad de vacas debe ser mayor a 0
                if (Convert.ToInt32(txt_cantidad_vacas.Text) < 1)
                {
                    MessageBox.Show("La cantidad de vacas debe ser Mayor a 0");
                }
                else
                {
                    matriz = new int[Convert.ToInt32(txt_cantidad_vacas.Text), 7];
                    //bloqueo de textbox y boton
                    txt_cantidad_vacas.Enabled = false;
                    btn_ingresar_vacas.Enabled = false;

                    //habilito comandos para continuar
                    txt_vaca.Enabled = true;
                    txt_dia.Enabled = true;
                    txt_litros.Enabled = true;
                    btn_ingresar_datos.Enabled = true;

                    btn_calcular.Enabled = true;
                    btn_buscar.Enabled = true;
                    btn_promedio.Enabled = true;
                    txt_buscar_vaca.Enabled = true;
                }
            }
            
        }

        private void btn_ingresar_datos_Click(object sender, EventArgs e)
        {
            //carga elemento en posicion de matriz [vaca,dia] la cantidad de litros correspondiente
            matriz[Convert.ToInt32(txt_vaca.Text)-1,Convert.ToInt32(txt_dia.Text)-1]= Convert.ToInt32(txt_litros.Text);
            //borra formularios para otra carga
            txt_dia.Clear();
            txt_vaca.Clear();
            txt_litros.Clear();
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            //si no hay nada cargado en el textbox muestra mensaje
            if (txt_buscar_vaca.Text == "")
            {
                MessageBox.Show("Debe ingresar un valor para buscar la vaca");
            }
            else
            {
                //la vaca a buscar debe estar entre 1 y el valor maximo de vaca
                if(Convert.ToInt32(txt_buscar_vaca.Text)<=0 || Convert.ToInt32(txt_buscar_vaca.Text) > Convert.ToInt32(txt_cantidad_vacas.Text))
                {
                    MessageBox.Show("Variable fuera de rango");
                }
                else
                {
                    int i = Convert.ToInt32(txt_buscar_vaca.Text) - 1;
                    lbl_d1.Text = matriz[i, 0].ToString();
                    lbl_d2.Text = matriz[i, 1].ToString();
                    lbl_d3.Text = matriz[i, 2].ToString();
                    lbl_d4.Text = matriz[i, 3].ToString();
                    lbl_d5.Text = matriz[i, 4].ToString();
                    lbl_d6.Text = matriz[i, 5].ToString();
                    lbl_d7.Text = matriz[i, 6].ToString();
                }
            }                                
        }

        private void btn_promedio_Click(object sender, EventArgs e)
        {
            int suma = 0;
            //ciclo que recorre todos los dias de la semana
            for (int i = 0; i < 7; i++)
            {
                suma = 0;
                //ciclo que recorre todas las vacas de x dia y suma sus litros
                for(int j = 0; j < Convert.ToInt32(txt_cantidad_vacas.Text); j++)
                {
                    suma += matriz[j, i];
                }
                //para asignar al label del dia correspondiente el promedio utilizo la sentencia switch
                switch (i)
                {
                    case 0:
                        lbl_d1.Text = Convert.ToString(suma / Convert.ToDouble(txt_cantidad_vacas.Text));
                        break;
                    case 1:
                        lbl_d2.Text = Convert.ToString(suma / Convert.ToDouble(txt_cantidad_vacas.Text));
                        break;
                    case 2:
                        lbl_d3.Text = Convert.ToString(suma / Convert.ToDouble(txt_cantidad_vacas.Text));
                        break;
                    case 3:
                        lbl_d4.Text = Convert.ToString(suma / Convert.ToDouble(txt_cantidad_vacas.Text));
                        break;
                    case 4:
                        lbl_d5.Text = Convert.ToString(suma / Convert.ToDouble(txt_cantidad_vacas.Text));
                        break;
                    case 5:
                        lbl_d6.Text = Convert.ToString(suma / Convert.ToDouble(txt_cantidad_vacas.Text));
                        break;
                    case 6:
                        lbl_d7.Text = Convert.ToString(suma / Convert.ToDouble(txt_cantidad_vacas.Text));
                        break;
                }
                    
            }
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            //asigno una variable para el total de cant de leche producida y otro como indicador de la vaca que le corresponde
            int cant_leche = 0;
            int vaca = 0;
            //variable aux de suma de produccion de una vaca
            int suma = 0;
            //ciclo for para recorrer vacas
            for (int i = 0; i < Convert.ToInt32(txt_cantidad_vacas.Text); i++)
            {
                //otro ciclo para reccorrer los dias de produccion de una vaca y calcular la suma
                for (int j = 0; j < 7; j++)
                {
                    suma += matriz[i, j];
                }
                //averiguo si la suma obtenida es la mayor hasta el momento. si lo es la asigno en mi variable de cant de leche y la vaca
                if (suma > cant_leche)
                {
                    cant_leche = suma;
                    vaca = i+1; //+1 para indicar la vaca, no la columna de la matriz
                }
                //reseteo variable suma
                suma = 0;
            }

            //por ultimo asigno variables cant leche y vaca a los labels
            lbl_vmp.Text = vaca.ToString();
            lbl_cl.Text = cant_leche.ToString();
        }
    }
}
