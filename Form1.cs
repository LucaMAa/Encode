using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Encode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = barcode.Draw(textBox1.Text, 50);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = qrcode.Draw(textBox2.Text, 50);
        }

        private void button3_Click(object sender, EventArgs e)
        { 
          
           
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = qrcode.Draw(pictureBox2.Image.ToString(), 50);
            
           
        }

        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if(data!=null)
            {
                var filenames = data as string[];
                if(filenames.Length>0)
                {
                    pictureBox2.Image = Image.FromFile(filenames[0]);
                }
                
            }
        }

        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox2.AllowDrop = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
