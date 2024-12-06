using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form3 : Form
    {
        private Form2 parentForm;

        public Form3(Form2 form2)
        {
            InitializeComponent();
            parentForm = form2; 
        }

        public Form3()
        {
            InitializeComponent();
        }
    }
}
