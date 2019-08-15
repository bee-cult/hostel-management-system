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
    public partial class Fee_UserControl : UserControl
    {
        private static Fee_UserControl _instance;

        public static Fee_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Fee_UserControl();
                }
                return _instance;
            }
        }

        public string FinalFee;

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");
       

        public Fee_UserControl()
        {
            InitializeComponent();
        }

        private void Fee_UserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchFee_textBox.Text = "";
            button4.Hide();
            panel1.Hide();
            dataGridView1.Hide();
            dataGridView4.Hide();
            button2.Hide();
            Done.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
       
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Refresh_DataGridView1()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("ShowFee_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_id", SearchFee_textBox.Text);

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

     
            
        public void updateFeeToBePaid()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");

               

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update fee set Fee_paid='"+ textBox1.Text + "',Fee_remaining='" + textBox2.Text + "' where Student_id='" + SearchFee_textBox.Text+"' ";
                
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
               


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

            private void button3_Click(object sender, EventArgs e)
            {
            updateFeeToBePaid();
            button7.Show();
            try
            {
              
                SqlCommand cmd = new SqlCommand("SearchFee2_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_id", SearchFee_textBox.Text);

               

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
               

                dataGridView4.Show();

                MessageBox.Show("The student fee detail is displayed. ");

             }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
            dataGridView1.Show();
            Done.Show();
            label6.Show();
           
            
            
        }
        
      


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void EnterButton2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SearchFee_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_id", SearchFee_textBox.Text);

            
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


                dataGridView4.DataSource = DS.Tables[0];
                this.dataGridView4.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView4.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView4.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView4.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
          

                dataGridView4.Show();

                MessageBox.Show("The student fee detail is displayed. Now you can proceed to make payment.");

                button2.Show();
                button4.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Show();
            button4.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Show();

        }

        private void Done_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
            Done.Hide();
            panel2.Hide();
            button5.Hide();
            panel3.Hide();
            button6.Hide();
            label6.Hide();
            button7.Hide();
            dataGridView5.Hide();
            
        }


        public void Updated()
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"|DataDirectory|\\Database.mdf\";Integrated Security=True");



                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update fee set Fee_remaining=0 where Student_id='" + SearchFee_textBox.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();



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
                MessageBox.Show("           <<<INVALID SQL OPERATION>>>: \n" + ex);

            }
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update fee set Fee_paid='"+Paidlabel.Text+"' where Student_id='" + SearchFee_textBox.Text + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure?");
            button2.Hide();
            button4.Hide();
            panel2.Show();
            Done.Show();
            button5.Show();
            Updated();
            button7.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            panel3.Show();
            button6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Done.PerformClick();
            Updated();
            button7.Hide();
            dataGridView5.Hide();
        }



        public void refresh_DataGridView()
        {
            dataGridView2.Show();
            button9.Show();
            try
            {
                SqlCommand cmd = new SqlCommand("ShowAllFeeData_SP", con);
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

            
                dataGridView2.DataSource = DS.Tables[0];
                this.dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView2.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            refresh_DataGridView();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView2.Hide();
            button9.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SearchFee_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Student_id", SearchFee_textBox.Text);


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

                dataGridView5.Show();
                dataGridView5.DataSource = DS.Tables[0];
                this.dataGridView5.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                this.dataGridView5.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView5.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView5.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                dataGridView5.Show();

             

                button2.Show();
                button4.Show();


            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);

            }
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
