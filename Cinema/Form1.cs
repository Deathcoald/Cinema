using System;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OpenFormButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton != null)
            {
                string movieName = clickedButton.Text;
                Form2 form2 = new Form2(movieName);

                form2.Show();
            }
        }

        private void createButton(string text, int size_x, int size_y, int point_x, int point_y)
        {
            Button button = new Button
            {
                Text = text,
                Size = new System.Drawing.Size(size_x, size_y),
                Location = new System.Drawing.Point(point_x, point_y),
                ForeColor = System.Drawing.Color.White
            };

            button.Click += OpenFormButton_Click;

            this.Controls.Add(button);
        }

        private void createImage(string image_name, int point_x, int point_y)
        {
            PictureBox pictureBox = new PictureBox
            {
                Size = new System.Drawing.Size(400, 600),
                Location = new System.Drawing.Point(point_x, point_y),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = System.Drawing.Image.FromFile(image_name)
            };
            this.Controls.Add(pictureBox);
        }
    }
}
