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
    public partial class Form1 : Form
    {
        Estudiantes_Presentacion EP = new Estudiantes_Presentacion();
        Materias MP = new Materias(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EP.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MP.ShowDialog();
        }
    }
}
