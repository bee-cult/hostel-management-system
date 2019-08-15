using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Management_System2
{
    public partial class Home_UserControl : UserControl
    {

        private static Home_UserControl _instance;

        public static Home_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Home_UserControl();
                }
                return _instance;
            }
        }
        public Home_UserControl()
        {
            InitializeComponent();
        }

        private void Home_UserControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            PanelOkay.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button3.Show();
            PanelOkay.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Hide();
        }
    }
}
