using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastScreenshot
{
    public partial class Main : Form
    {
        private readonly int x, y, w, h;
        private readonly Size s;
        private readonly string href;
        private int counter;

        public Main()
        {
            InitializeComponent();

            x = int.Parse(tb_x.Text);
            y = int.Parse(tb_y.Text);
            w = int.Parse(tb_w.Text);
            h = int.Parse(tb_h.Text);
            x = int.Parse(tb_x.Text);
            s = new Size(int.Parse(tb_sw.Text), int.Parse(tb_sh.Text));
            href = @"C:\Users\yonka\Documents\history bagrut ready\";
            counter = 0;
            label6.Text = "...Waiting...";
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.Q) // pressed
            {
                label6.Text = "Success.";
                Save(x, y, w, h, s);
                System.Threading.Thread th = new System.Threading.Thread(Wait);
                th.Start();
            }
        }
        private void Wait()
        {
            System.Threading.Thread.Sleep(1000);
            Invoke(new MethodInvoker(delegate { label6.Text = "Waiting.."; }));
        }
        public void Save(int x, int y, int w, int h, Size S)
        {
            Bitmap bmp;
            Rectangle rect = new Rectangle(x, y, w, h);

            bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);

            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, S, CopyPixelOperation.SourceCopy);
            bmp.Save(href + "File (" + ++counter + ").png", ImageFormat.Png);
        }
    }
}