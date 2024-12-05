using System;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form1 : Form
    {
        

        private void OpenFormButton_Click(object sender, EventArgs e)
        {
            
            Form2 form2 = new Form2();
            form2.Show();
        }

        public void createText(string name, int size_x, int size_y, int point_x, int point_y, int text_size)
        {
            Label cinema_name1 = new Label();

            cinema_name1.Text = name;
            cinema_name1.Size = new System.Drawing.Size(size_x, size_y);
            cinema_name1.Location = new System.Drawing.Point(point_x, point_y);
            cinema_name1.Font = new System.Drawing.Font("Times New Roman", text_size);
            cinema_name1.ForeColor = System.Drawing.Color.White;

            this.Controls.Add(cinema_name1);
        }

        private void createButton(string text, int size_x, int size_y, int point_x, int point_y)
        {
            Button button = new Button();

            button.Text = text;
            button.Size = new System.Drawing.Size(size_x, size_y);
            button.Location = new System.Drawing.Point(point_x, point_y);
            button.ForeColor = System.Drawing.Color.White;

            button.Click += OpenFormButton_Click; 
            this.Controls.Add(button);
        }

        private void createImage(string image_name, int point_x, int point_y)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Size = new System.Drawing.Size(400, 600);
            pictureBox.Location = new System.Drawing.Point(point_x, point_y);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = System.Drawing.Image.FromFile(image_name);

            this.Controls.Add(pictureBox);
        }

        private void InitializeComponent()
        {
            this.BackColor = System.Drawing.Color.Black;

            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(1900, 1000);
            this.Name = "Form1";
            this.Text = "Афиша";

            this.createText("Добро пожаловать в кино!", 400, 100, 800, 50, 22);
            this.createText("Марсианин", 210, 80, 430, 160, 20);
            this.createText("Темный рыцарь", 300, 80, 860, 160, 20);
            this.createText("Титаник", 300, 80, 1340, 160, 20);

            this.createImage("marsianin.jpg", 300, 250);
            this.createImage("darkknight.jpg", 750, 250);
            this.createImage("titanic.jpg", 1200, 250);

            this.createButton("Просмотреть сеансы", 150, 70, 870, 900);
            this.createButton("Просмотреть сеансы", 150, 70, 430, 900);
            this.createButton("Просмотреть сеансы", 150, 70, 1330, 900);

            this.ResumeLayout(false);
        }
    }
}
