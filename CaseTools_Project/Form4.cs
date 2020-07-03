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
using System.Collections;

namespace CaseTools_Project
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
          List<TaskClass> tasklist = new List<TaskClass>();
          List<ResourceClass> Reslist = new List<ResourceClass>();


        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(global::CaseTools_Project.Properties.Settings.Default.CaseToolDataBase1ConnectionString);
            //string sqlSelect = "SELECT * FROM TASK";
            string sqlSelect = "SELECT Resource.*,Task.* FROM Task INNER JOIN Resource on Task.Task_Resource = Resource.Resource_Number";
            SqlCommand execomand = new SqlCommand(sqlSelect, conn);
            conn.Open();
            SqlDataReader dataRead = execomand.ExecuteReader();
            while (dataRead.Read())
            {



                tasklist.Add(new TaskClass()
                {
                    Task_Number = dataRead.GetInt32(dataRead.GetOrdinal("Task_Number")),
                    Task_Name = dataRead.GetString(dataRead.GetOrdinal("Task_Name")),
                    Pre_Task = dataRead.GetInt32(dataRead.GetOrdinal("Pre_Task")),
                    Duration_Task = dataRead.GetInt32(dataRead.GetOrdinal("Duration_Task")),
                    Task_Resource = dataRead.GetInt32(dataRead.GetOrdinal("Task_Resource"))
                });

                Reslist.Add(new ResourceClass()
                {
                 Resource_Number = dataRead.GetInt32(dataRead.GetOrdinal("Resource_Number")),
                 Resource_Name = dataRead.GetString(dataRead.GetOrdinal("Resource_Name")),
                 Resource_Standard_Rate = dataRead.GetInt32(dataRead.GetOrdinal("Resource_Standard_Rate"))
                });


            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
         int CostProjct()
        {
            int AllCostProjct = 0;
            for(int i = 0; i < tasklist.Count; i++)
            {
                AllCostProjct = AllCostProjct + (tasklist[i].Duration_Task * Reslist[i].Resource_Standard_Rate);
            }
            return AllCostProjct;
        }
        int TimeProjct()
        {
            int AllTimeProjct = 0;
            for (int i = 0; i < tasklist.Count; i++)
            {
                AllTimeProjct += (tasklist[i].Duration_Task);
            }
            return AllTimeProjct;
        }
        void calcTask()
        {
            int costSingleTask = 0;
            string TaskName = bunifuMaterialTextbox1.Text.ToUpper();
            bool isEmpty = true;
            for (int i = 0; i < tasklist.Count; i++)
            {
                if (tasklist[i].Task_Name == TaskName)
                {
                    costSingleTask = tasklist[i].Duration_Task * Reslist[i].Resource_Standard_Rate;
                    MessageBox.Show("The "+TaskName+" Cost = " + costSingleTask.ToString() + " $");
                    isEmpty = false;
                }

            }
            if (isEmpty)
            {
                MessageBox.Show("The Task Not Found !");
            }
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush sold1 = new SolidBrush(Color.FromArgb(105, 140, 7));
            SolidBrush sold2 = new SolidBrush(Color.White);
            Pen p1 = new Pen(Color.White);
            Font drawFont = new Font("Kalam", 10);
            //g.DrawRectangle(p1, 260, 50, 500, 460);
             int  x = 123;
            int y= 165;
            // foreach(TaskClass t1 in tasklist)
            for(int i = 0;i<tasklist.Count;i++)
            {
               
            int end = Reslist[i].Resource_Standard_Rate * tasklist[i].Duration_Task;
                //drawNameTask
                g.DrawString(tasklist[i].Task_Name.ToString() + " Pre = " + tasklist[i].Pre_Task.ToString(), drawFont, sold2, x, y-17);
                //drawTask
                g.FillRectangle(sold1, x, y, end, 30);
                x += end;
                
            
                y += 55;

                
            }
            Font TotalFont = new Font("Kalam", 12);
            g.DrawString("Project Total Cost = " + CostProjct().ToString() +" $ ", TotalFont, sold2, 30, 450);
            g.DrawString("Project Total Time = " + TimeProjct().ToString() + " Hours ", TotalFont, sold2, 30, 470);


        }
        private void button1_Click(object sender, EventArgs e)
        { }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            calcTask();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
