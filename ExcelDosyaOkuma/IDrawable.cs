using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ExcelDosyaOkuma
{
    //Bir Tree Node un temsili için
    interface IDrawable
    {
        // Nesnenin gerekli boyutunu döndürür.
        SizeF GetSize(Graphics gr, Font font);

        // Düğüm bu noktanın üzerindeyse true değerini döndürür.
        bool IsAtPoint(Graphics gr, Font font, PointF center_pt, PointF target_pt);

        // (x, y) merkezli nesneyi çizin.
        void Draw(float x, float y, Graphics gr, Pen pen,
            Brush bg_brush, Brush text_brush, Font font);
    }
}
