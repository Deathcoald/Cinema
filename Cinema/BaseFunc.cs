using System.Drawing;
using System.Windows.Forms;

namespace Cinema
{
    public static class BaseFunc
    {
        public static void create_close_button(Form form, int point_x, int point_y)
        {
            Button closeButton = new Button
            {
                Text = "Назад",
                Size = new Size(100, 50),
                Location = new Point(point_x, point_y),
                Font = new Font("Times New Roman", 14),
                BackColor = Color.LightGray,
                ForeColor = Color.Black
            };

            closeButton.Click += (sender, e) =>
            {
                form.Close();
            };

            form.Controls.Add(closeButton);
        }
    }
}
