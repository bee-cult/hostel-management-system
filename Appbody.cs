using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System2
{
    public partial class Appbody : Form
    {
        public Appbody()
        {
            InitializeComponent();
        }

        private void Appbody_Load(object sender, EventArgs e)
        {

        }






        private void Sliding_ToggleButton_Click(object sender, EventArgs e)
        {
            if (!ContentPanel.Controls.Contains(Home_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Home_UserControl.Instance);
                Home_UserControl.Instance.Dock = DockStyle.Fill;
                Home_UserControl.Instance.BringToFront();
            }
            else
            {
                Home_UserControl.Instance.BringToFront();

            }

        }



        
        private void button5_Click(object sender, EventArgs e)
        {
            if(!ContentPanel.Controls.Contains(Hostel_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Hostel_UserControl.Instance);
                Hostel_UserControl.Instance.Dock = DockStyle.Fill;
                Hostel_UserControl.Instance.BringToFront();
            }
            else
            {
                Hostel_UserControl.Instance.BringToFront();

            }
        }




        private void button4_Click(object sender, EventArgs e)
        {
          
            if (!ContentPanel.Controls.Contains(Student_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Student_UserControl.Instance);
                Student_UserControl.Instance.Dock = DockStyle.Fill;
                Student_UserControl.Instance.BringToFront();
            }
            else
            {
                Student_UserControl.Instance.BringToFront();

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!ContentPanel.Controls.Contains(Transactions_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Transactions_UserControl.Instance);
                Transactions_UserControl.Instance.Dock = DockStyle.Fill;
                Transactions_UserControl.Instance.BringToFront();
            }
            else
            {
                Transactions_UserControl.Instance.BringToFront();

            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (!ContentPanel.Controls.Contains(Room_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Room_UserControl.Instance);
                Room_UserControl.Instance.Dock = DockStyle.Fill;
                Room_UserControl.Instance.BringToFront();
            }
            else
            {
                Room_UserControl.Instance.BringToFront();

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!ContentPanel.Controls.Contains(MessEmployee_UserControl.Instance))
            {
                ContentPanel.Controls.Add(MessEmployee_UserControl.Instance);
                MessEmployee_UserControl.Instance.Dock = DockStyle.Fill;
                MessEmployee_UserControl.Instance.BringToFront();
            }
            else
            {
                MessEmployee_UserControl.Instance.BringToFront();

            }
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            if (!ContentPanel.Controls.Contains(Fee_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Fee_UserControl.Instance);
                ContentPanel.Controls.Add(Fee_UserControl.Instance);
                Fee_UserControl.Instance.Dock = DockStyle.Fill;
                Fee_UserControl.Instance.BringToFront();
            }
            else
            {
                Fee_UserControl.Instance.BringToFront();

            }
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            if (!ContentPanel.Controls.Contains(Visitor_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Visitor_UserControl.Instance);
                ContentPanel.Controls.Add(Visitor_UserControl.Instance);
                Visitor_UserControl.Instance.Dock = DockStyle.Fill;
                Visitor_UserControl.Instance.BringToFront();
            }
            else
            {
                Visitor_UserControl.Instance.BringToFront();

            }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            if (!ContentPanel.Controls.Contains(About_UserControl.Instance))
            {
                ContentPanel.Controls.Add(About_UserControl.Instance);
                ContentPanel.Controls.Add(About_UserControl.Instance);
                About_UserControl.Instance.Dock = DockStyle.Fill;
                About_UserControl.Instance.BringToFront();
            }
            else
            {
                About_UserControl.Instance.BringToFront();

            }
        }

        private void ContentPanel_Paint(object sender, PaintEventArgs e)
        {

            if (!ContentPanel.Controls.Contains(Home_UserControl.Instance))
            {
                ContentPanel.Controls.Add(Home_UserControl.Instance);
                Home_UserControl.Instance.Dock = DockStyle.Fill;
                Home_UserControl.Instance.BringToFront();
            }
            else
            {
                Home_UserControl.Instance.BringToFront();

            }


        }

        private void Appbody_Load_1(object sender, EventArgs e)
        {

        }

      
    }
}
