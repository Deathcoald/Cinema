﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cinema
{
    public partial class Form4 : Form
    {
        private int Row { get; set; }
        private int Col { get; set; }

        public Zal zal;

        private Button seatButton;

        private TextBox inputTextBox;
        private Button processButton;

        private string Time;
        private string selectedMovie;

        public Form4(string selectedMovie, string Time, int row, int col, Zal zal, Button seatButton)
        {
            Row = row;
            Col = col;

            this.selectedMovie = selectedMovie;
            this.Time = Time;
            this.zal = zal;
            this.seatButton = seatButton;  

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
            Client client = new Client(Time, inputTextBox.Text, Row, Col);

            client.SaveToFile($"{selectedMovie}.txt");

            
            seatButton.BackColor = Color.Red;  

            this.Close();
        }

    }
}
