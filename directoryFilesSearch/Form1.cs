using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace directoryFilesSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        public class ImageGallery
        {
            public List<Image> images = new List<Image>();
            public ImageGallery() { }
            public ImageGallery(ImageList images) { }
            public void AddImage(Image image) { images.Add(image); }
            public void RemoveImage(Image image) { images.Remove(image); }
            public Image GetImage(int index) { return images[index]; }
            public int counter = 0;
            public int current = 0;
        }

        public ImageGallery ig = new ImageGallery();


        private void Form1_Load(object sender, EventArgs e)
        {
            this.folderBrowserDialog1.ShowDialog();
            this.Text = this.folderBrowserDialog1.SelectedPath.ToString();
            DirectoryInfo dinf = new DirectoryInfo(this.folderBrowserDialog1.SelectedPath);
            IEnumerable<FileInfo> infos;
            List<string> allimagesingallery = new List<string>();


            Bitmap bmp = new Bitmap(1024, 768);

            Image tmpimg = bmp;



            infos = dinf.EnumerateFiles("*.png");
            this.textBox1.Text += "\r\n";
           
                foreach (FileInfo info in infos)
                {
                
                this.textBox1.Text += info.Name;
                    this.textBox1.Text += "\r\n";
                    allimagesingallery.Add(info.Name);

                    tmpimg = Image.FromFile(this.Text + "\\" + info.Name);
                    imageList1.Images.Add(tmpimg);

                    ig.counter++;
                }
            
            infos = dinf.EnumerateFiles("*.jpg");
            this.textBox1.Text += "\r\n";
                foreach (FileInfo info in infos)
                {
                    this.textBox1.Text += info.Name;
                    this.textBox1.Text += "\r\n";
                    allimagesingallery.Add(info.Name);

                    tmpimg = Image.FromFile(this.Text + "\\" + info.Name);
                    imageList1.Images.Add(tmpimg);

                    ig.counter++;
                }

            infos = dinf.EnumerateFiles("*.jpeg");
            this.textBox1.Text += "\r\n";
                foreach (FileInfo info in infos)
                {
                    this.textBox1.Text += info.Name;
                    this.textBox1.Text += "\r\n";
                    allimagesingallery.Add(info.Name);

                    tmpimg = Image.FromFile(this.Text + "\\" + info.Name);
                    imageList1.Images.Add(tmpimg);


                    ig.counter++;
                }

            infos = dinf.EnumerateFiles("*.bmp");
            this.textBox1.Text += "\r\n";
                foreach (FileInfo info in infos)
                {
                    this.textBox1.Text += info.Name;
                    this.textBox1.Text += "\r\n";
                    allimagesingallery.Add(info.Name);

                    tmpimg = Image.FromFile(this.Text + "\\" + info.Name);
                    imageList1.Images.Add(tmpimg);


                    ig.counter++;
                }

            infos = dinf.EnumerateFiles("*.gif");
            this.textBox1.Text += "\r\n";
                foreach (FileInfo info in infos)
                {
                    this.textBox1.Text += info.Name;
                    this.textBox1.Text += "\r\n";
                    allimagesingallery.Add(info.Name);

                    tmpimg = Image.FromFile(this.Text + "\\" + info.Name);
                    imageList1.Images.Add(tmpimg);


                    ig.counter++;
                }



            this.Text = Application.ExecutablePath;


            for (int i = 0; i < ig.counter; i++)
            {
                ig.images.Add(imageList1.Images[i]);
            }

            this.pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            this.pictureBox1.BackgroundImage = ig.images[0];
            ig.current = 0;

            this.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ig.current == 0)
            {
                ig.current = ig.counter;
            }
            else
            {
                ig.current--;
            }
            
            try
            {
                this.pictureBox1.BackgroundImage = ig.images[ig.current];
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ig.current == ig.counter)
            {
                ig.current = 0;
            }
            else
            {
                ig.current++;
            }
            try
            {
                this.pictureBox1.BackgroundImage = ig.images[ig.current];
            }catch{ }
        }
    }
}
