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
    public partial class Form3 : Form
    {
        bool statusGrid = true;
        public Form3()
        {
            InitializeComponent();
            dataGridView1.Hide();
            pictureBox6.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'caseToolDataBase1DataSet.Task' table. You can move, or remove it, as needed.
            this.taskTableAdapter.Fill(this.caseToolDataBase1DataSet.Task);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::CaseTools_Project.Properties.Settings.Default.CaseToolDataBase1ConnectionString);
            try
            {
                string sqlInsert = "INSERT INTO Task (Task_Number, Task_Name,Pre_Task,Duration_Task,Task_Resource) values (" + bunifuMaterialTextbox1.Text + ", N'" + bunifuMaterialTextbox2.Text.ToUpper() + "'," + bunifuMaterialTextbox3.Text +","+bunifuMaterialTextbox4.Text+","+bunifuMaterialTextbox5.Text + ")";
                SqlCommand exeSqlInsert = new SqlCommand(sqlInsert, cn);
                cn.Open();
                exeSqlInsert.ExecuteNonQuery();

                MessageBox.Show("Add new record successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.taskTableAdapter.Fill(this.caseToolDataBase1DataSet.Task);
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
                bunifuMaterialTextbox4.Text = "";
                bunifuMaterialTextbox5.Text = "";
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

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(global::CaseTools_Project.Properties.Settings.Default.CaseToolDataBase1ConnectionString);
            try
            {
                string sqlDelete = " DELETE FROM  Task WHERE Task_Number = " + bunifuMaterialTextbox1.Text;
                SqlCommand exeSqlDelete = new SqlCommand(sqlDelete, cn);
                cn.Open();
                exeSqlDelete.ExecuteNonQuery();

                MessageBox.Show("Record Deleted successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.taskTableAdapter.Fill(this.caseToolDataBase1DataSet.Task);
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
                string sqlUPDATE = "UPDATE Task SET Task_Name = N'" + bunifuMaterialTextbox2.Text + "',Pre_Task = " + bunifuMaterialTextbox3.Text + ",Duration_Task = " +bunifuMaterialTextbox4.Text+ ", Task_Resource = "+bunifuMaterialTextbox5.Text +  " WHERE Task_Number = " + bunifuMaterialTextbox1.Text;
                SqlCommand exeSqlUPDATE = new SqlCommand(sqlUPDATE, cn);
                cn.Open();
                exeSqlUPDATE.ExecuteNonQuery();

                MessageBox.Show("Record updated successfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.taskTableAdapter.Fill(this.caseToolDataBase1DataSet.Task);
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
                bunifuMaterialTextbox4.Text = "";
                bunifuMaterialTextbox5.Text = "";
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            Hide();
            f2.ShowDialog();
            Close();
        }

        private void bunifuMaterialTextbox1_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.Text = "";
        }

        private void bunifuMaterialTextbox2_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.Text = "";
        }

        private void bunifuMaterialTextbox3_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox3.Text = "";
        }

        private void bunifuMaterialTextbox4_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox4.Text = "";
        }

        private void bunifuMaterialTextbox5_Click(object sender, EventArgs e)
        {
            bunifuMaterialTextbox5.Text = "";
        }

        private void bunifuMaterialTextbox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bunifuMaterialTextbox3.Text))
            {
                bunifuMaterialTextbox3.Text = "1";
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            Hide();
            f4.ShowDialog();
            Close();
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
