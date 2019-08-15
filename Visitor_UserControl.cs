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
    public partial class Visitor_UserControl : UserControl
    {
        private static Visitor_UserControl _instance;

        public static Visitor_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Visitor_UserControl();
                }
                return _instance;
            }
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");


        public Visitor_UserControl()
        {
            InitializeComponent();
        }

        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllVisitorData_SP", con);
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
        private void Visitor_UserControl_Load(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        private void EmployeeDetailsButton_Click(object sender, EventArgs e)
        {
            
            refresh_DataGridView();
        }

        private void Address_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            textBox3.Text = "";
            textBox2.Text = "";

            StudentID_TextField.Text = "";
            StudentSearch_textBox.Text = "";
            A_TB.Text = "";
            B_TB.Text = "";
            C_TB.Text = "";
            D_TB.Text = "";
            E_TB.Text = "";
            F_TB.Text = "";
            G_TB.Text = "";

        }

        private void SearchEmployeeButton_Click(object sender, EventArgs e)
        {


            try
            {
                SqlCommand cmd = new SqlCommand("SearchVisitor_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Date", StudentSearch_textBox.Text);

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


            SqlCommand cmd = new SqlCommand("VisitorAdd_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SNO", A_TB.Text);
            cmd.Parameters.AddWithValue("@Visitor_name", B_TB.Text);
            cmd.Parameters.AddWithValue("@Student_id", C_TB.Text);
            cmd.Parameters.AddWithValue("@Time_in", D_TB.Text);
            cmd.Parameters.AddWithValue("@Time_out", E_TB.Text);
            cmd.Parameters.AddWithValue("@Date", F_TB.Text);
            cmd.Parameters.AddWithValue("@Hostel_id", G_TB.Text);


            con.Open();
            try
            {
                cmd.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("           <<<INVALID SQL OPERATION>>>: \n" + e);

            }
            con.Close();


            refresh_DataGridView();


        }

        private void D_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("VisitorDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SNO", textBox2.Text);
                cmd.Parameters.AddWithValue("@Date", textBox3.Text);


                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

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

        private void E_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                SqlCommand cmd = new SqlCommand("SearchVisitorByID_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_id", textBox1.Text);

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

       
        SqlCommand cmd;
        SqlDataReader dr;

        private void SearchStudentButton_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                String syntax = "SELECT Room_no FROM student where Student_id='" + StudentID_TextField.Text + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                RoomNo_label.Text  = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input" + ex);
                con.Close();
            }


            try
            {
                con.Open();
                String syntax = "SELECT Hostel_id FROM student where Student_id='" + StudentID_TextField.Text + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                HostelId_label.Text = dr[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input" + ex);
                con.Close();
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("VisitorDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SNO", textBox2.Text);
                cmd.Parameters.AddWithValue("@Date", textBox3.Text);


                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

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

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
