using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ExcelDosyaOkuma
{
   class PictureNode : IDrawable
    {
        
        public Image Picture = null;
        public string Description;
        public bool Selected = false;
        public PictureNode(string description, Image picture)
        {
            Description = description;
            Picture = picture;
        }

        // Çizilen dikdörtgenlerin boyutu.
        public SizeF NodeSize = new SizeF(100, 100);


        // Bu düğümün ihtiyaç duyduğu boyutu döndürür.
        public SizeF GetSize(Graphics gr, Font font)
        {
            return NodeSize;
        }

        //Düğümün konumunu veren bir RectangleF döndürür.
        private RectangleF Location(PointF center)
        {
            return new RectangleF(
                center.X - NodeSize.Width / 2,
                center.Y - NodeSize.Height / 2,
                NodeSize.Width, NodeSize.Height);
        }

        // Hedef bu düğümün altındaysa True döndürür.
        public bool IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt)
        {
            RectangleF rect = Location(center_pt);
            return rect.Contains(target_pt);
        }

        //Kişiyi çizin.
        public void Draw(float x, float y, Graphics gr, Pen pen, Brush bg_brush, Brush text_brush, Font font)
        {
            // Bir sınır çizer.
            RectangleF rectf = Location(new PointF(x, y));
            Rectangle rect = Rectangle.Round(rectf);
            if (Selected)
            {
                gr.FillRectangle(Brushes.White, rect);
                ControlPaint.DrawBorder3D(gr, rect,
                    Border3DStyle.Sunken);
            }
            else
            {
                gr.FillRectangle(Brushes.LightGray, rect);
                ControlPaint.DrawBorder3D(gr, rect,
                    Border3DStyle.Raised);
            }

            //Resmi çiz.
            rectf.Inflate(-5, -5);
            rectf = PositionImage(Picture, rectf);
            gr.DrawImage(Picture, rectf);
        }

        // Dikdörtgende ortalanmış görüntüyü uzatmadan olabildiğince büyük çizmek için bir dikdörtgen bulun.
        private RectangleF PositionImage(Image picture, RectangleF rect)
        {
            //X ve Y ölçeklerini alın.
            float pic_wid = picture.Width;
            float pic_hgt = picture.Height;
            float pic_aspect = pic_wid / pic_hgt;
            float rect_aspect = rect.Width / rect.Height;
            float scale = 1;
            if (pic_aspect > rect_aspect)
            {
                scale = rect.Width / pic_wid;
            }
            else
            {
                scale = rect.Height / pic_hgt;
            }

            //  nereye çizmemiz gerektiğine bakın
            pic_wid *= scale;
            pic_hgt *= scale;
            RectangleF drawing_rect = new RectangleF(
                rect.X + (rect.Width - pic_wid) / 2,
                rect.Y + (rect.Height - pic_hgt) / 2,
                pic_wid, pic_hgt);
            return drawing_rect;
        }
    }
}


