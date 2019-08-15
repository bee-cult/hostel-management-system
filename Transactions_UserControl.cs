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
    public partial class Transactions_UserControl : UserControl
    {

        private static Transactions_UserControl _instance;

        public static Transactions_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Transactions_UserControl();
                }
                return _instance;
            }
        }

   

        public Transactions_UserControl()
        {
            InitializeComponent();
        }


        public string Student1,Student2, RoomNumber, HostelId;

        private void Transactions_UserControl_Load(object sender, EventArgs e)
        {
           
        }

        private void ClearAllButton_Click(object sender, EventArgs e)
        {
            RoomNumberText_Field.Text = "";
            HostelID_TextField.Text = "";
            StudentID_TextField.Text = "";
            Bed1_label.Text = "";
            Bed2_label.Text = "";
           
            RoomNo_label.Text = "";
            HostelId_label.Text = "";

            textBox1.Text = "";
            Student_id_TB.Text = "";
            
            Room_no_TB.Text = "";

            Hostel_id_TB.Text = "";

        }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
        SqlCommand cmd;

        private void HostelID_TextField_TextChanged(object sender, EventArgs e)
        {

        }

        public void updateInRoom()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
            con.Open();
            try
            {

          
            if (Bed1_label.Text == "")
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Rooms set Student1= '" + Student_id_TB.Text + "' where Room_no='" + Room_no_TB.Text + "' and Hostel_id='"+Hostel_id_TB.Text+"'  ";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added to the room successfully. Student added in the first bed");
            }

            else if (Bed2_label.Text == "")
            {
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Rooms set Student2= '" + Student_id_TB.Text + "' where Room_no='" + Room_no_TB.Text + "' and Hostel_id='" + Hostel_id_TB.Text + "'  ";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added to the room successfully. Student added in the second bed");
            }
            else
            {
                MessageBox.Show("The room is not empty");
            }
          
              
           
                con.Close();
                SearchVacancyButton.PerformClick();


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

           
        }

        public void updateInFee()
        {
              try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
                con.Open();
                SqlCommand cnd = con.CreateCommand();
                cnd.CommandType = CommandType.Text;
                cnd.CommandText = "update fee set Hostel_id= '" + Hostel_id_TB.Text + "' where Student_id='" + Student_id_TB.Text + "' ";
                cnd.ExecuteNonQuery();
                con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
          
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update student set Room_no= '" + Room_no_TB.Text + "',Hostel_id = '" + Hostel_id_TB.Text + "' where Student_id='" + Student_id_TB.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }

            updateInRoom();
            updateInFee();

        }



        SqlDataReader dr;

        private void Bed2_label_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("StudentDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Student_id", textBox1.Text);


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


                
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void StudentID_TextField_TextChanged(object sender, EventArgs e)
        {

        }

        private void HostelId_label_Click(object sender, EventArgs e)
        {

        }

        private void RoomNo_label_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void SearchVacancyButton_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String syntax = "SELECT Student1 FROM Rooms where Room_no='" + RoomNumberText_Field.Text + "' and Hostel_id='" + HostelID_TextField.Text + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                Bed1_label.Text =Student1= dr[0].ToString();
                con.Close();

                con.Open();
                syntax = "SELECT Student2 FROM Rooms where Room_no='" + RoomNumberText_Field.Text + "' and Hostel_id='" + HostelID_TextField.Text + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                Bed2_label.Text =Student2= dr[0].ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input \n" + ex);
                con.Close();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void SearchVacancyButton_Click_1(object sender, EventArgs e)
        {
           


        }


        private void SearchStudentButton_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                String syntax = "SELECT Room_no FROM student where Student_id='" + StudentID_TextField.Text + "'";
                cmd = new SqlCommand(syntax, con);
                dr = cmd.ExecuteReader();
                dr.Read();
                RoomNo_label.Text = RoomNumber = dr[0].ToString();
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
                HostelId_label.Text = HostelId = dr[0].ToString();
                con.Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input" + ex);
                con.Close();
            }


        }


        public void updateRoom1()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Rooms set Student1='" + Null1.Text + "' where Student1='" + textBox1.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public void updateRoom2()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Rooms set Student2='" + Null1.Text + "' where Student2='" + textBox1.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void DeleteStudentButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("StudentDelete_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Student_id", textBox1.Text);


                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student deleted successfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("           <<<INVALID SQL OPERATION>>>: \n" + ex);

                }
                con.Close();


               
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }



            updateRoom1();
            updateRoom2();
          

        }


    }
}
