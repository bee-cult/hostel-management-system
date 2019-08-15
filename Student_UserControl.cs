using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hostel_Management_System2
{
    public partial class Student_UserControl : UserControl
    {
        private static Student_UserControl _instance;

        public static Student_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Student_UserControl();
                }
                return _instance;
            }
        }

        public Student_UserControl()
        {
            InitializeComponent();
            refresh_DataGridView();
        }




        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");




        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Student_UserControl_Load(object sender, EventArgs e)
        {
            StudentDetailsButton.PerformClick();
            refresh_DataGridView();

        }

        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllStudentsData_SP", con);



                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("           <<<INVALID SQL OPERATION>>> \n" + ex);
                }
                con.Close();


                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);





            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("StudentAdd_SP", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Student_id", Student_id_TB.Text);
            cmd.Parameters.AddWithValue("@First_name", First_name_TB.Text);
            cmd.Parameters.AddWithValue("@Last_name", Last_name_TB.Text);
            cmd.Parameters.AddWithValue("@Department", Department_TB.Text);
            cmd.Parameters.AddWithValue("@Phone_no", Phone_no_TB.Text);
            cmd.Parameters.AddWithValue("@Address", Address_TB.Text);
            cmd.Parameters.AddWithValue("@Guardians_name", Guardian_name_TB.Text);
            cmd.Parameters.AddWithValue("@Guardians_no", Guardian_ph_no_TB.Text);
            cmd.Parameters.AddWithValue("@DOB", DOB_TB.Text);


            con.Open();
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show(" Some error occured. Check your data types.                   <<<INVALID SQL OPERATION>>>: \n" + e);

            }
            con.Close();


            refresh_DataGridView();




            con.Open();
            try
            {
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = CommandType.Text;
                cnd.CommandText = "insert into fee(Student_id) values('" + Student_id_TB.Text + "') ";
                cnd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student added successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            con.Close();





        }






        private void Phone_no_TB_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void SearchStudentButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("SearchStudent_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_id", StudentSearch_textBox.Text);

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);



                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("           <<<INVALID SQL OPERATION>>> \n" + ex);
                }
                con.Close();


                dataGridView1.DataSource = DS.Tables[0];
                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }



        }

        private void StudentDetailsButton_Click(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            StudentSearch_textBox.Text = "";
            Student_id_TB.Text = "";
            First_name_TB.Text = "";
            Last_name_TB.Text = "";
            Department_TB.Text = "";
            Phone_no_TB.Text = "";
            Address_TB.Text = "";
            Guardian_name_TB.Text = "";
            Guardian_ph_no_TB.Text = "";
           
            DOB_TB.Text = "";
           



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void StudentSearch_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Student_id_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Update_Button_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student set First_name='" + First_name_TB.Text + "',Last_name='" + Last_name_TB.Text + "',Department='" + Department_TB.Text + "',Phone_no='" + Phone_no_TB.Text + "',Address='" + Address_TB.Text + "', [Guardian's_name]='" + Guardian_name_TB.Text + "',[Guardian's_no] = '" + Guardian_ph_no_TB.Text + "',DOB = '" + DOB_TB.Text + "' where Student_id='" + Student_id_TB.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Student Record updated successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            refresh_DataGridView();
            StudentDetailsButton.PerformClick();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clear_Button.PerformClick();
            FormPanel.Show();
            AddButton.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Clear_Button.PerformClick();
            FormPanel.Show();
            Update_Button.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StudentDetailsButton.PerformClick();
            FormPanel.Hide();
            AddButton.Hide();
            Update_Button.Hide();
            
        }
    }
}
