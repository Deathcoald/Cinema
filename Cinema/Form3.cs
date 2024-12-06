using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form3 : Form
    {
        private Form2 parentForm;
        private Zal zal;

        public void create_seat_button(int row, int col, int point_x, int point_y, bool isOccupied)
        {
            Button seatButton = new Button
            {
                Size = new Size(25, 25),
                Location = new Point(point_x, point_y),
                Font = new Font("Times New Roman", 12),
                ForeColor = isOccupied ? Color.White : Color.Black,
                BackColor = isOccupied ? Color.Red : Color.LightGreen,
                TextAlign = ContentAlignment.MiddleCenter,
                Tag = (row, col)
            };

            seatButton.Click += (sender, e) =>
            {
                Button clickedButton = sender as Button;
                var (seatRow, seatCol) = ((int, int))clickedButton.Tag;

                if (isOccupied)
                {
                    MessageBox.Show($"Место занято!");
                }
                else
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                }
            };

            this.Controls.Add(seatButton);
        }

        private void OnSeansButtonClick(object sender, EventArgs e, string time)
        {
            Form4 form4 = new Form4();

            form4.Show();
        }
        void create_scene()
        {
            int start_x = 20;
            int start_y = 20;
            int padding = 30;

            for (int row = 0; row < zal.rows; row++)
            {
                for (int col = 0; col < zal.cols; col++)
                {
                    create_seat_button(row, col, start_x, start_y, zal.medium_hall[row, col]);
                    start_x += padding;
                }

                start_y += padding;
                start_x = 20;
            }
        }
        private void AddScreenLabel()
        {
            Label screenLabel = new Label
            {
                Text = "Экран",
                Size = new Size(200, 30), 
                Location = new Point(100, 570), 
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            this.Controls.Add(screenLabel);
        }

        public Form3()
        {
            InitializeComponent();
            zal = new Zal(13, 13);
            create_scene();
            AddScreenLabel();
            BaseFunc.create_close_button(this, 350, 550);
        }
    }
}
