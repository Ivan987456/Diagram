using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        // построение диаграммы из данных, записанных в таблице
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(panel1.Handle);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            try
            {
                int countRows = dataGridView1.Rows.Count;
                int z = 15, hight1, hight2;
                for (int j = 0; j < countRows; j++)
                {
                    hight1 = Convert.ToInt32(dataGridView1[0, j].Value);
                    hight2 = Convert.ToInt32(dataGridView1[1, j].Value);
                    g.FillRectangle(redBrush, z, 319 - hight1, 20, 319 - hight2);
                    g.FillRectangle(grayBrush, z, 319 - hight2, 20, 319);
                    z += 35;
                }
            }
            catch
            {
                MessageBox.Show("Некорректные данные!");
            }
        }

        // вызов отрисовки
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Lines();
        }

        // отрисовка шкалы в диаграмме 
        public void Lines()
        {
            Graphics g = Graphics.FromHwnd(panel1.Handle);
            Pen pen = new Pen(Color.Black);
            SolidBrush redBrush = new SolidBrush(Color.Red);
            Point point1 = new Point(10, 20);
            Point point2 = new Point(10, 320);
            Point point3 = new Point(390, 320);
            g.DrawLine(pen, point1, point2);
            g.DrawLine(pen, point2, point3);
            for (int i = point1.Y; i < point2.Y; i += 15)
                g.FillRectangle(redBrush, 5, i, 6, 1);
        }
    }
}
