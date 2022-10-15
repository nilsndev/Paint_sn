using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Paint;
using Paint.Class;



namespace Paint.Forms{
    public partial class MainForm : Form{
        int font = 10;
        Color color = Color.Black;
        Pen pen;
        Pen eraser;
        Graphics g;
        bool drawing;
        bool createRectangle;
        bool createElipse;
        
        bool fill_with_bucket;
        string path = @"C:\Users\Nils\Pictures\pen.cur";
        int x = -1, y = -1;
        
        public MainForm(){
            InitializeComponent();
            
            
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e){
           
            

        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e){
            if (fill_with_bucket){
                this.paint_panel1.BackColor = color;
                fill_with_bucket = false;
                return;
            }
            if (createRectangle||createElipse){
                x = e.X;
                y = e.Y;

                return;
            }
            pen = new Pen(color, font);
            x = e.X;
            y = e.Y;
            drawing = true;

        }
       

        private void MainForm_MouseUp(object sender, MouseEventArgs e){
            if (createElipse){
                drawGeometricObject(new Round_Label(), e.X, e.Y);
            }
            if (createRectangle){
                drawGeometricObject(new Label(), e.X, e.Y);
            }
            createElipse = false;
            createRectangle = false;
            drawing = false;
            Cursor.Current = Cursors.Default;
        }
        void drawGeometricObject(Label p,int eX,int eY){
            p.AutoSize = false;
            p.Text = null;
            p.SendToBack();
            p.BorderStyle = BorderStyle.FixedSingle;
            if(eX >= x){
                p.Left = x;
                p.Width = eX - x;
            }
            else{
                p.Left = eX;
                p.Width = x - eX;
            }
            if (eY >= y){
                p.Top = y;
                p.Height = eY - y;
            }
            else{
                p.Top = eY;
                p.Height = y - eY;
            }

            p.BackColor = color;
            this.paint_panel1.Controls.Add(p);
        }
        

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e){
           
            this.size_maskedTextBox1.Text = font.ToString();

        }

        private void size_maskedTextBox1_TextChanged(object sender, EventArgs e){
            if(size_maskedTextBox1.Text != "")
            font = Convert.ToInt32(this.size_maskedTextBox1.Text);


        }

        private void color_button1_Click(object sender, EventArgs e){
            this.color_panel1.Enabled = true;
            path = @"C:\Users\Nils\Pictures\pen.cur";
        }

        private void eraser_button1_Click(object sender, EventArgs e){
            this.color_panel1.Enabled = false;
            path = @"C:\Users\Nils\Pictures\eraser.cur";
            color = this.paint_panel1.BackColor;

        }

        private void red_button3_Click(object sender, EventArgs e){
            color = (sender as Button).BackColor;

        }

        private void custom_color_button7_Click(object sender, EventArgs e){
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;

        }

        private void paint_bucket_button7_Click(object sender, EventArgs e){
            fill_with_bucket = true;
        }

        private void rectangle_button7_Click(object sender, EventArgs e){
            createRectangle = true;
           
        }

        private void paint_panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void elipse_button_Click(object sender, EventArgs e){
            createElipse = true;
        }

        private void triangle_button7_Click(object sender, EventArgs e){
         
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e){
        
            if (drawing){
                Cursor.Current = new Cursor(path);
                g = this.paint_panel1.CreateGraphics();
                g.DrawLine(pen, x, y, e.X, e.Y);
                x = e.X;
                y=e.Y;
            }

        }
    }
}
