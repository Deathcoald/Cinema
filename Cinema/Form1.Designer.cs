namespace Cinema
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.BackColor = System.Drawing.Color.Black;
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(1900, 1000);
            this.Name = "Form1";
            this.Text = "Афиша";

            BaseFunc.createText(this, "Добро пожаловать в кино!", 400, 100, 800, 50, 22);
            BaseFunc.createText(this, "Марсианин", 210, 80, 430, 160, 20);
            BaseFunc.createText(this, "Темный рыцарь", 300, 80, 860, 160, 20);
            BaseFunc.createText(this, "Титаник", 300, 80, 1340, 160, 20);

            this.createImage("marsianin.jpg", 300, 250);
            this.createImage("darkknight.jpg", 750, 250);
            this.createImage("titanic.jpg", 1200, 250);

            this.createButton("Марсианин", 150, 70, 430, 900);
            this.createButton("Темный рыцарь", 150, 70, 870, 900);
            this.createButton("Титаник", 150, 70, 1330, 900);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
