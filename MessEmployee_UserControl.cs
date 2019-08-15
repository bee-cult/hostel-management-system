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
    public partial class MessEmployee_UserControl : UserControl
    {
        private static MessEmployee_UserControl _instance;

        public static MessEmployee_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MessEmployee_UserControl();
                }
                return _instance;
            }
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");


        public MessEmployee_UserControl()
        {
            InitializeComponent();
        }

        private void Last_name_label_Click(object sender, EventArgs e)
        {

        }

        private void DOB_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void DOB_label_Click(object sender, EventArgs e)
        {

        }

        private void Phone_no_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MessEmployee_UserControl_Load(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        private void EmployeeDetailsButton_Click(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllEmployeeData_SP", con);
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
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }

        private void Address_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchEmployeeButton_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SearchEmployee_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_id", StudentSearch_textBox.Text);

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
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }

        }

        private void AddButton_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("EmployeeAdd_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_id", Student_id_TB.Text);
            cmd.Parameters.AddWithValue("@Emp_name", First_name_TB.Text);
            cmd.Parameters.AddWithValue("@Address", Address_TB.Text);
            cmd.Parameters.AddWithValue("@State", Department_TB.Text);
            cmd.Parameters.AddWithValue("@Cell_no", Phone_no_TB.Text);
            cmd.Parameters.AddWithValue("@Salary", DOB_TB.Text);
            cmd.Parameters.AddWithValue("@Hostel_id", Guardian_name_TB.Text);
           

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee added successfully");
            }
            catch
            {
                MessageBox.Show("           <<<INVALID SQL OPERATION>>>: \n" + e);

            }
            con.Close();

           
            refresh_DataGridView();


        }

        private void Student_id_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("EmployeeDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emp_id", textBox1.Text);


                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record deleted successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("           <<<INVALID SQL OPERATION>>>: \n" + ex);

                }
                con.Close();


                refresh_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            StudentSearch_textBox.Text = "";
            Student_id_TB.Text = "";
            First_name_TB.Text = "";
        
            Department_TB.Text = "";
            Phone_no_TB.Text = "";
            Address_TB.Text = "";
            Guardian_name_TB.Text = "";
           
            DOB_TB.Text = "";
            


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Button_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update mess_employee set Emp_name='" + First_name_TB.Text + "',Address='" + Address_TB.Text + "',State='" + Department_TB.Text + "',Cell_no='" + Phone_no_TB.Text + "',Salary='" + DOB_TB.Text + "', Hostel_id='"+Guardian_name_TB.Text+"' where Emp_id='" + Student_id_TB.Text + "' ";

            cmd.Connection = con;
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Record updated successfully");

            refresh_DataGridView();
            EmployeeDetailsButton.PerformClick();
        }
    }
}
