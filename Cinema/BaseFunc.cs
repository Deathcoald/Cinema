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
        public static void createText(Form form, string name, int size_x, int size_y, int point_x, int point_y, int text_size)
        {
            Label cinema_name1 = new Label
            {
                Text = name,
                Size = new System.Drawing.Size(size_x, size_y),
                Location = new System.Drawing.Point(point_x, point_y),
                Font = new System.Drawing.Font("Times New Roman", text_size),
                ForeColor = System.Drawing.Color.White
            };
            form.Controls.Add(cinema_name1);
        }
    }
}
