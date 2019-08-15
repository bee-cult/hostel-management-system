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
    public partial class Hostel_UserControl : UserControl
    {
        private static Hostel_UserControl _instance;

        public static Hostel_UserControl Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Hostel_UserControl();
                }
                return _instance;
            }
        }

        public Hostel_UserControl()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");



        private void Hostel_UserControl_Load(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }


        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllHostelsData_SP", con);
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }



        private void Clear_Button_Click(object sender, EventArgs e)
        {
            BookSearch_textBox.Text = "";
            Room_id_textBox.Text = "";
            Capacity_textBox.Text = "";
            No_of_chairs_textBox.Text = "";
            No_of_tables_textbox.Text = "";
            Hostel_id_textBox.Text = "";
        }

        private void BookSearch_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("HostelAdd_SP", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Hostel_id", Room_id_textBox.Text);
            cmd.Parameters.AddWithValue("@Location", Capacity_textBox.Text);
            cmd.Parameters.AddWithValue("@No_of_students", No_of_tables_textbox.Text);
            cmd.Parameters.AddWithValue("@No_of_rooms", No_of_chairs_textBox.Text);
            cmd.Parameters.AddWithValue("@Fee", Hostel_id_textBox.Text);

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
            MessageBox.Show("Hostel added successfully");

            refresh_DataGridView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("HostelDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@Hostel_id", Room_id_textBox.Text);

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

        private void SearchRoomButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SearchHostel_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Hostel_id", BookSearch_textBox.Text);

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

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update hostel set Fee='" + Hostel_id_textBox.Text + "',No_of_students='" + No_of_tables_textbox.Text + "',Location='" + Capacity_textBox.Text + "',No_of_rooms='" + No_of_chairs_textBox.Text + "' where Hostel_id='" + Room_id_textBox.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Hostel Record updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            refresh_DataGridView();
            button1.PerformClick();
        }
    }
}
