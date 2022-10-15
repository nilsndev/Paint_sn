using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;



namespace Paint.Class{
    public class Round_Label : Label{

        protected override void OnPaint(PaintEventArgs e){
            GraphicsPath path = new GraphicsPath();                    
            path.AddEllipse(0, 0, Width, Height);
            this.Region = new System.Drawing.Region(path);
            base.OnPaint(e);
        }

    }
}
