using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form4 : Form
    {
        private List<Seans> SeansList;
        private int Row { get; set; }
        private int Col { get; set; }

        public Zal zal;

        private Button seatButton;

        private TextBox inputTextBox;
        private Button processButton;

        private DateTime Time;
        private string selectedMovie;

        public Form4(string selectedMovie, DateTime Time, int row, int col, Zal zal, Button seatButton)
        {
            Row = row;
            Col = col;

            this.selectedMovie = selectedMovie;
            this.Time = Time;
            this.zal = zal;
            this.seatButton = seatButton;

            SeansList = Seans.LoadSeansFromFile();

            InitializeComponent();
            create_text_box();
            BaseFunc.createText(this, "Введите свои данные", 400, 30, 70, 50, 20);
        }

        private void create_text_box()
        {
            inputTextBox = new TextBox
            {
                Location = new Point(100, 100),
                Size = new Size(200, 30),
                Font = new Font("Arial", 12)
            };
            this.Controls.Add(inputTextBox);

            processButton = new Button
            {
                Text = "Подтвердить",
                Location = new Point(100, 150),
                Size = new Size(150, 30),
                Font = new Font("Arial", 12),
                ForeColor = System.Drawing.Color.White
            };
            processButton.Click += ProcessButton_Click;
            this.Controls.Add(processButton);
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            Ticket client = new Ticket(Time, inputTextBox.Text, Row, Col);

            Seans seans = Seans.FindSeans(SeansList, Time, selectedMovie);

            if (seans == null)
            {
                seans = new Seans(selectedMovie, Time);
                SeansList.Add(seans);
            }

            seans.AddTicket(client, SeansList);

            seatButton.BackColor = Color.Red;

            this.Close();
        }

    }
}
