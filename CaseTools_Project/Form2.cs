using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CaseTools_Project
{
    public partial class Form2 : Form
    {
        bool statusGrid = true;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'caseToolDataBase1DataSet.Resource' table. You can move, or remove it, as needed.
            this.resourceTableAdapter.Fill(this.caseToolDataBase1DataSet.Resource);
            dataGridView1.Hide();
            pictureBox6.Hide();
        }

        


        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (statusGrid)
            {
                pictureBox4.Hide();
                dataGridView1.Show();
                statusGrid = false;
                pictureBox5.Hide();
                pictureBox6.Show();
               
            }
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (!statusGrid)
            {
                dataGridView1.Hide();
                pictureBox4.Show();
                statusGrid = true;
                pictureBox6.Hide();
                pictureBox5.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::CaseTools_Project.Properties.Settings.Default.CaseToolDataBase1ConnectionString);
            try
            {
                string sqlInsert = "INSERT INTO Resource (Resource_Number, Resource_Name,Resource_Standard_Rate) values (" + bunifuMaterialTextbox1.Text + ", N'" + bunifuMaterialTextbox2.Text.ToUpper() + "'," + bunifuMaterialTextbox3.Text + ")";
                SqlCommand exeSqlInsert = new SqlCommand(sqlInsert, cn);
                cn.Open();
                exeSqlInsert.ExecuteNonQuery();

                MessageBox.Show("Add new record successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.resourceTableAdapter.Fill(this.caseToolDataBase1DataSet.Resource);
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally
            {
                cn.Close();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::CaseTools_Project.Properties.Settings.Default.CaseToolDataBase1ConnectionString);
            try
            {
                string sqlDelete = "DELETE FROM  Resource WHERE Resource_Number = " + bunifuMaterialTextbox1.Text;
                SqlCommand exeSqlDELETE = new SqlCommand(sqlDelete, cn);
                cn.Open();
                exeSqlDELETE.ExecuteNonQuery();

                MessageBox.Show("Record Deleted successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.resourceTableAdapter.Fill(this.caseToolDataBase1DataSet.Resource);
                bunifuMaterialTextbox1.Text = "";
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally
            {
                cn.Close();
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::CaseTools_Project.Properties.Settings.Default.CaseToolDataBase1ConnectionString);
            try
            {
                string sqlUPDATE = "UPDATE Resource SET Resource_Name = N'" + bunifuMaterialTextbox2.Text + "',Resource_Standard_Rate = " + bunifuMaterialTextbox3.Text + " WHERE Resource_Number = " + bunifuMaterialTextbox1.Text;
                SqlCommand exeSqlUPDATE = new SqlCommand(sqlUPDATE, cn);
                cn.Open();
                exeSqlUPDATE.ExecuteNonQuery();

                MessageBox.Show("Record updated successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.resourceTableAdapter.Fill(this.caseToolDataBase1DataSet.Resource);
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally
            {
                cn.Close();
            }
        }

        private void bunifuMaterialTextbox1_MouseClick(object sender, MouseEventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox1_MouseHover(object sender, EventArgs e)
        {
          
        }

        private void bunifuMaterialTextbox2_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.Text = "";
        }

        private void bunifuMaterialTextbox3_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox3.Text = "";
        }

        private void bunifuMaterialTextbox1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            Hide();
            f3.ShowDialog();
            Close();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            Hide();
            f1.ShowDialog();
            Close();
        }

        private void bunifuMaterialTextbox1_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox2_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
    }
}
