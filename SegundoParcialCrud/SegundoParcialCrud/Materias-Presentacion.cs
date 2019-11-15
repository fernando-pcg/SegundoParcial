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
    public partial class Materias : Form
    {
        Materias_Logica ML = new Materias_Logica();
        Datos data = new Datos();

        public Materias()
        {
            InitializeComponent();
            LlenarGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtCode.Text == "" || txtCredits.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                try
                {
                    ML.Codigo = int.Parse(txtCode.Text);
                    ML.nombreMateria = txtName.Text;
                    ML.Creditos = int.Parse(txtCredits.Text);

                    data.AgregarM(ML.Codigo, ML.nombreMateria, ML.Creditos);
                    MessageBox.Show("Materia Agregada");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                Limpiar();
                LlenarGrid();
            }
        }
        public void Limpiar()
        {
            foreach (Control tool in Controls)
            {
                if (tool is TextBox)
                {
                    tool.Text = "";
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (txtCode.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                try
                {
                    ML.Codigo = int.Parse(txtCode.Text);

                    data.BorrarM(ML.Codigo);
                    MessageBox.Show("Materia Borrada");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                Limpiar();
                LlenarGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (txtCode.Text == "" || txtCredits.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                try
                {
                    ML.Codigo = int.Parse(txtCode.Text);
                    ML.nombreMateria = txtName.Text;
                    ML.Creditos = int.Parse(txtCredits.Text);

                    data.EditarM(ML.Codigo, ML.nombreMateria, ML.Creditos);
                    MessageBox.Show("Materia Editada");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                Limpiar();
                LlenarGrid();
            }
        }

        public void LlenarGrid()
        {
            dgvMaterias.DataSource = data.LlenarGridM();
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
