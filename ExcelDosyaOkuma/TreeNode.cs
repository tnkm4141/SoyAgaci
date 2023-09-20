using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ExcelDosyaOkuma
{
    class TreeNode<T>where T:IDrawable
    {
        // Veri.
        public T Data;

        //Ağaçtaki alt düğümler.
        public List<TreeNode<T>> Children = new List<TreeNode<T>>();

        // Kardeşler arasında yatay olarak ve nesiller arasında dikey olarak atlamak için boşluk.
        private const float Hoffset = 5;
        private const float Voffset = 30;

        // Düzenlemeden sonra düğümün merkezi.
        private PointF Center;

        // Çizim özellikleri.
        public Font MyFont = null;
        public Pen MyPen = Pens.Black;
        public Brush FontBrush = Brushes.Black;
        public Brush BgBrush = Brushes.White;

        // Constructor.
        public TreeNode(T new_data)
            : this(new_data, new Font("Times New Roman", 12))
        {
            Data = new_data;
        }
        public TreeNode(T new_data, Font fg_font)
        {
            Data = new_data;
            MyFont = fg_font;
        }

        // Çocuklar listesine bir TreeNode ekleyin.
        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }

        // Düğümü ve alt öğelerini izin verilen alana yerleştirin.
        // Alt ağacımızın sağ kenarını belirtmek için xmin'i ayarlayın.
        // Alt ağacımızın alt kenarını belirtmek için ymin'i ayarlayın.
        public void Arrange(Graphics gr, ref float xmin, ref float ymin)
        {
            // Bu düğümün ne kadar büyük olduğunu görün.
            SizeF my_size = Data.GetSize(gr, MyFont);

            // Çocuklarımızı yinelemeli olarak düzenleyin, bu düğüme yer bırakın.
            float x = xmin;
            float biggest_ymin = ymin + my_size.Height;
            float subtree_ymin = ymin + my_size.Height + Voffset;
            foreach (TreeNode<T> child in Children)
            {
                //Bu çocuğun alt ağacını düzenleyin.
                float child_ymin = subtree_ymin;
                child.Arrange(gr, ref x, ref child_ymin);

                // Bunun en büyük ymin değerini artırıp artırmadığına bakın.
                if (biggest_ymin < child_ymin) biggest_ymin = child_ymin;

                //Bir sonraki kardeşten önce yer açın.
                x += Hoffset;
            }

            // Son çocuktan sonraki boşluğu kaldırın.
            if (Children.Count > 0) x -= Hoffset;

            // Bu düğümün altındaki alt ağaçtan daha geniş olup olmadığına bakın.
            float subtree_width = x - xmin;
            if (my_size.Width > subtree_width)
            {
                // Alt ağacı bu düğümün altında ortalayın.
                // Çocukların alt ağaçlarını ortalayacak şekilde kendilerini yeniden düzenlemelerini sağlayın.
                x = xmin + (my_size.Width - subtree_width) / 2;
                foreach (TreeNode<T> child in Children)
                {
                    // Bu çocuğun alt ağacını düzenleyin.
                    child.Arrange(gr, ref x, ref subtree_ymin);

                    //Bir sonraki kardeşten önce yer açın.
                    x += Hoffset;
                }

                //Alt ağacın genişliği, bu düğümün genişliğidir.
                subtree_width = my_size.Width;
            }

            // Bu düğümün merkez konumunu ayarlayın.
            Center = new PointF(
                xmin + subtree_width / 2,
                ymin + my_size.Height / 2);

            // Geri dönmeden önce alt ağaç için yer açmak için xmin değerini artırın.
            xmin += subtree_width;

            // ymin için dönüş değerini ayarlayın.
            ymin = biggest_ymin;
        }

        //Verilen sol üst köşe ile bu düğümde köklenen alt ağacı çizin.
        public void DrawTree(Graphics gr, ref float x, float y)
        {
            // Ağacı düzenleyin.
            Arrange(gr, ref x, ref y);

            // Ağacı çizin.
            DrawTree(gr);
        }

        // Kökü bu düğümde olan alt ağacı çizin.
        public void DrawTree(Graphics gr)
        {
            // Bağlantıları çizin.
            DrawSubtreeLinks(gr);

            // Düğümleri çizin.
            DrawSubtreeNodes(gr);
        }

        // Kökü bu düğümde olan alt ağaç için bağlantıları çizin.
        private void DrawSubtreeLinks(Graphics gr)
        {
            // Bak bakalım 1 çocuğumuz var mı?
            if (Children.Count == 1)
            {
                //Sadece merkezleri bağlayın.
                gr.DrawLine(MyPen, Center, Children[0].Center);
            }
            else if (Children.Count > 1)
            {
                // Çocukların üzerine yatay bir çizgi çizin.
                float xmin = Children[0].Center.X;
                float xmax = Children[Children.Count - 1].Center.X;
                SizeF my_size = Data.GetSize(gr, MyFont);
                float y = Center.Y + my_size.Height / 2 + Voffset / 2f;
                gr.DrawLine(MyPen, xmin, y, xmax, y);

                // Dikey çizgiyi ebeveynden yatay çizgiye çizin.
                gr.DrawLine(MyPen, Center.X, Center.Y, Center.X, y);

                //Çocuklara yatay çizgiden çizgiler çizin.
                foreach (TreeNode<T> child in Children)
                {
                    gr.DrawLine(MyPen,
                        child.Center.X, y,
                        child.Center.X, child.Center.Y);
                }
            }

            // Çocukların alt ağaçlarını yinelemeli olarak çizmelerini sağlayın.
            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeLinks(gr);
            }
        }

        // Bu düğümde köklenen alt ağaç için düğümleri çizin.
        private void DrawSubtreeNodes(Graphics gr)
        {
            // Bu düğümü çizin.
            Data.Draw(Center.X, Center.Y, gr, MyPen, BgBrush, FontBrush, MyFont);

            //Çocuğun alt ağaç düğümlerini yinelemeli olarak çizmesini sağlayın.
            foreach (TreeNode<T> child in Children)
            {
                child.DrawSubtreeNodes(gr);
            }
        }

        // Bu noktada TreeNode'u döndürün (veya orada yoksa null).
        public TreeNode<T> NodeAtPoint(Graphics gr, PointF target_pt)
        {
            // Noktanın bu düğümün altında olup olmadığına bakın.
            if (Data.IsAtPoint(gr, MyFont, Center, target_pt)) return this;

            // Noktanın alt ağaçtaki bir düğümün altında olup olmadığına bakın.
            foreach (TreeNode<T> child in Children)
            {
                TreeNode<T> hit_node = child.NodeAtPoint(gr, target_pt);
                if (hit_node != null) return hit_node;
            }

            return null;
        }

        // Bu düğümün alt ağacından bir hedef düğümü silin.
        // Düğümü silersek true değerini döndürür.
        public bool DeleteNode(TreeNode<T> target)
        {
            // Hedefin alt ağacımızda olup olmadığına bakın.
            foreach (TreeNode<T> child in Children)
            {
                // Çocuk olup olmadığına bakın.
                if (child == target)
                {
                    // Bu çocuğu sil.
                    Children.Remove(child);
                    return true;
                }

                // Çocuğun alt ağacında olup olmadığına bakın.
                if (child.DeleteNode(target)) return true;
            }

            // Alt ağacımızda yok.
            return false;
        }
    }
}
