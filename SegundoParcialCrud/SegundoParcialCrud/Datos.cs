using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SegundoParcialCrud
{
    class Datos
    {
        SqlConnection dataB = new SqlConnection("Data Source=FERNANDORFR;Initial Catalog=CrudSP;Integrated Security=True");
        SqlCommand comando;

        public void AgregarM(int Code, string Name, int Credits)
        {
            dataB.Open();
            string lineaquery = $"insert into Materias (Codigo,Nombre,Creditos) values ({Code},'{Name}',{Credits});";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();
            dataB.Close();
        }
        public void BorrarM(int Code)
        {
            dataB.Open();
            string lineaquery = $"delete from Materias where Codigo = {Code};";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();
            dataB.Close();
        }
        public void EditarM(int Code, string Name, int Credits)
        {
            dataB.Open();
            string lineaquery = $"update Materias set Nombre = '{Name}', Creditos = {Credits} where Codigo = {Code};";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();
            dataB.Close();
        }

        public DataTable LlenarGridM()
        {
            dataB.Open();
            string lineaquery = "Select Codigo,Nombre,Creditos from Materias where Codigo != 0;";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            data.Fill(table);
            dataB.Close();
            return table;
        }

        public void AgregarE(string Name, string Last, int Materia, int Estado, int idmateria)
        {
            dataB.Open();
            string lineaquery = $"insert into Estudiantes(Nombre, Apellido,Materia,Estado,IdMateria) values ('{Name}','{Last}',{Materia},{Estado},{idmateria});";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();
            dataB.Close();
        }
        public void BorrarE(string Name)
        {
            dataB.Open();
            string lineaquery = $"delete from Estudiantes  where Nombre = '{Name}';";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();
            dataB.Close();
        }
        public void EditarE(string Name, string Last, int mats, int Estado, int idmateria)
        {
            dataB.Open();
            string lineaquery = $"update Estudiantes set Materia = {mats}, Apellido = '{Last}', IdMateria = {idmateria}	, estado = {Estado} where Nombre = '{Name}';;";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();
            dataB.Close();
        }

        public DataTable LlenarGridE()
        {
            dataB.Open();
            string lineaquery = "select Nombre,Apellido,Materia,Estado from Estudiantes ;";
            comando = new SqlCommand(lineaquery, dataB);
            comando.ExecuteNonQuery();

            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable table = new DataTable();
            data.Fill(table);
            dataB.Close();
            return table;
        }

         public void LlenarCbbMaterias(ComboBox cb)
         {
            SqlDataReader dr;
            dataB.Open();
            string lineaquery = "select Nombre From Materias;";
            comando = new SqlCommand(lineaquery, dataB);
            dr = comando.ExecuteReader();
            while(dr.Read())
            {
                cb.Items.Add(dr["Nombre"].ToString());
            }
            cb.SelectedIndex = 0;
            dr.Close();
            dataB.Close();
         }


    }
}
