using P_1_Interfaz_grafica_con_archivo_de_texto_plano.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static P_1_Interfaz_grafica_con_archivo_de_texto_plano.Clases.Entidad;

namespace P_1_Interfaz_grafica_con_archivo_de_texto_plano
{
    public partial class Form1 : Form
    {

        List<Entidad> lista = new List<Entidad>();

        string ruta = "datos.txt";

        int idAuto = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarArchivo();
            MostrarDatos();
        }

        void MostrarDatos()
        {
            dgvLista.DataSource = null;
            dgvLista.DataSource = lista;
        }

        void CargarArchivo()
        {
            if (File.Exists(ruta))
            {
                string[] lineas = File.ReadAllLines(ruta);

                foreach (string linea in lineas)
                {
                    string[] datos = linea.Split(',');

                    Entidad e = new Entidad();

                    e.Id = Convert.ToInt32(datos[0]);
                    e.Nombre = datos[1];
                    e.Carrera = datos[2];

                    lista.Add(e);

                    if (e.Id >= idAuto)
                    {
                        idAuto = e.Id + 1;
                    }
                }
            }
        }

        void GuardarArchivo()
        {
            StreamWriter sw = new StreamWriter(ruta, false);

            foreach (Entidad e in lista)
            {
                sw.WriteLine(e.Id + "," + e.Nombre + "," + e.Carrera);
            }

            sw.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string[] nombres = { "Diego", "Ana", "Luis", "Carlos", "Fernanda" };
            string[] carreras = { "Sistemas", "Diseño", "Contabilidad", "Arquitectura", "Marketing" };

            Random r = new Random();

            int posicion = r.Next(nombres.Length);

            Entidad nueva = new Entidad();

            nueva.Id = idAuto;
            nueva.Nombre = nombres[posicion];
            nueva.Carrera = carreras[posicion];

            lista.Add(nueva);

            idAuto++;

            MostrarDatos();
            idAuto++;

            MostrarDatos();

           
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count > 0)
            {
                int indice = dgvLista.SelectedRows[0].Index;

                lista.RemoveAt(indice);

                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Selecciona una fila");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            GuardarArchivo();

            Application.Exit();
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvLista.SelectedRows.Count > 0)
            {
                int indice = dgvLista.SelectedRows[0].Index;

                lista[indice].Nombre = "Modificado";
                lista[indice].Carrera = "Actualizada";

                dgvLista.DataSource = null;
                dgvLista.DataSource = lista;
            }
            else
            {
                MessageBox.Show("Selecciona una fila");
            }
        }
    }
}

