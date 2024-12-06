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
        private Zal zal;

        public Form3(Form2 form2)
        {
            InitializeComponent();
            parentForm = form2;

            zal = new Zal(13, 13);
        }

        public Form3()
        {
            start_x = 10;
            start_y = 10;

            for (int i = 0; i <= zal.rows; i++)
                for(int y = 0; y <= zal.cols; y++)
                {
                    parentForm.create_seans_button("",);
                }


            InitializeComponent();
        }
    }
}
