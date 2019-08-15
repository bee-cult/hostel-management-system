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
    public partial class Room_UserControl : UserControl
    {

        private static Room_UserControl _instance;

        public static Room_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Room_UserControl();
                }
                return _instance;
            }
        }

        public Room_UserControl()
        {
            InitializeComponent();
        }



        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");



        private void Room_UserControl_Load(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }


        public void refresh_DataGridView()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllRoomsData_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch(Exception ex)
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
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }



        private void AddButton_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("RoomAdd_SP", con);
            cmd.CommandType =CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SNO", Room_id_textBox.Text);
            cmd.Parameters.AddWithValue("@Room_no", Capacity_textBox.Text);
            cmd.Parameters.AddWithValue("@Hostel_id", No_of_tables_textbox.Text);


            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("New room inserted successfully");
            }
            catch
            {
                MessageBox.Show("           <<<INVALID SQL OPERATION>>>: \n"+ e);

            }
            con.Close();


           
            refresh_DataGridView();
           
        }

        private void refresh_DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("RoomDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Room_no", a.Text);
                cmd.Parameters.AddWithValue("@Hostel_id",b.Text);

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
                SqlCommand cmd = new SqlCommand("SearchRoom_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Room_no", BookSearch_textBox.Text);
                cmd.Parameters.AddWithValue("@Hostel_id", Hostel_id_textBox.Text);

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

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            BookSearch_textBox.Text = "";
            Room_id_textBox.Text = "";
            Capacity_textBox.Text = "";

            No_of_tables_textbox.Text = "";
            Hostel_id_textBox.Text = "";
            a.Text = "";
            b.Text = "";

        }

        private void BookSearch_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "update Rooms set Student1='" + Capacity_textBox.Text + "' where SNO='"+Capacity_textBox.Text+"' ";
            cmd.CommandText = "update Rooms set Student2='" + No_of_tables_textbox.Text + "' where SNO='" + No_of_tables_textbox.Text + "' ";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();

           
            con.Close();
            MessageBox.Show("Record updated successfully");
        }

        private void DeleteButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("RoomDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@Room_no", a.Text);
                cmd.Parameters.AddWithValue("@Hostel_id", b.Text);


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
                MessageBox.Show("Room deleted successfully");

                refresh_DataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Rooms set Student1='" + textBox2.Text + "',Student2='" + textBox1.Text + "' where SNO='" + textBox3.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Room record updated successfully");

                refresh_DataGridView();
                button1.PerformClick();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }


        }

    }
}
