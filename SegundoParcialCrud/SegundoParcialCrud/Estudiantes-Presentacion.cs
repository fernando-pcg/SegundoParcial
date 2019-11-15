using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SegundoParcialCrud
{
    public partial class Estudiantes_Presentacion : Form
    {
        Datos dataB = new Datos();
        Estudiantes EL = new Estudiantes();
        public Estudiantes_Presentacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Estudiantes_Presentacion_Load(object sender, EventArgs e)
        {
            dataB.LlenarCbbMaterias(cbbMateria);
            LlenarGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtLast.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                EL.Nombre = txtName.Text;
                EL.Apellido = txtLast.Text;
                EL.Materias = int.Parse(cbbMateria.SelectedIndex.ToString());

                switch (int.Parse(cbbEstado.SelectedIndex.ToString()))
                {
                    case 0:
                        EL.Estado = 1;
                        break;
                    case 1:
                        EL.Estado = 2;
                        break;
                }
                dataB.AgregarE(EL.Nombre,EL.Apellido,EL.Materias,EL.Estado,EL.Materias);
                LlenarGrid();
            }
        }

        private void dgvEstudiantes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LlenarGrid()
        {
            dgvEstudiantes.DataSource = dataB.LlenarGridE();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                EL.Nombre = txtName.Text;
                dataB.BorrarE(EL.Nombre);
                LlenarGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtLast.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                EL.Nombre = txtName.Text;


                switch (int.Parse(cbbEstado.SelectedIndex.ToString()))
                {
                    case 0:
                        EL.Estado = 1;
                        break;
                    case 1:
                        EL.Estado = 2;
                        break;
                }
                dataB.EditarE(EL.Nombre, EL.Apellido, EL.Materias, EL.Estado, EL.Materias);
                LlenarGrid();
            }
        }
    }
   }
