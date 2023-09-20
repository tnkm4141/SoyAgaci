using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace ExcelDosyaOkuma
{
    public partial class Form2 : Form
    {
            /*public Form2(List<Kisi> _list)
            {
                InitializeComponent();
            }*/
         List<Kisi> _list;
        public Form2(List<Kisi> list)
        {
            _list = list;
            InitializeComponent();
        }
        

        // The root node.
      private TreeNode<PictureNode> root =
                new TreeNode<PictureNode>(
                    new PictureNode("root",
                         Resource1.avatar2));

            // Make a tree.
            private void Form2_Load(object sender, EventArgs e)
            {
            TreeNode<PictureNode> root1 =
                    new TreeNode<PictureNode>(
                        new PictureNode(_list[0].GetAd + _list[1].GetAd,
                         Resource1.avatar2));
            root.AddChild(root1);

            for ( int i=2;i<_list.Count();i++)
                {
                if (_list[i].GetAnneAdi == _list[1].GetAd || _list[i].GetBabaAdi == _list[0].GetAd)
                {
                    TreeNode<PictureNode> asd =
                    new TreeNode<PictureNode>(
                        new PictureNode(_list[i].GetAd + _list[i].GetEs,
                         Resource1.avatar2));
                    root1.AddChild(asd);
                    for (int j = 2; j < _list.Count; j++)
                    {
                        if (_list[j].GetAnneAdi == _list[i].GetAd || _list[j].GetBabaAdi == _list[i].GetAd)
                        {
                            TreeNode<PictureNode> asdf =
                        new TreeNode<PictureNode>(
                            new PictureNode(_list[j].GetAd,
                             Resource1.avatar2));

                            asd.AddChild(asdf);
                            for (int k = 0; k < _list.Count; k++)
                            {
                                if (_list[k].GetAnneAdi == _list[j].GetAd || _list[k].GetBabaAdi == _list[j].GetAd)
                                {
                                    //eşinin varlığını sorgula
                                    TreeNode<PictureNode> asdfg =
                                new TreeNode<PictureNode>(
                                    new PictureNode(_list[k].GetAd,
                                     Resource1.avatar2));

                                    asdf.AddChild(asdfg);
                                } 

                            }
                        }
                    }
                }
                
            }
            

                // Arrange the tree.
                ArrangeTree();
            }

            // Draw the tree.
            private void picTree_Paint(object sender, PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                root.DrawTree(e.Graphics);
            }

            // Center the tree on the form.
            private void picTree_Resize(object sender, EventArgs e)
            {
                ArrangeTree();
            }
            private void ArrangeTree()
            {
                using (Graphics gr = picTree.CreateGraphics())
                {
                    // Arrange the tree once to see how big it is.
                    float xmin = 0, ymin = 0;
                    root.Arrange(gr, ref xmin, ref ymin);

                    // Arrange the tree again to center it horizontally.
                    xmin = (this.ClientSize.Width - xmin) / 2;
                    ymin = 10;
                    root.Arrange(gr, ref xmin, ref ymin);
                }

                picTree.Refresh();
            }

            // The currently selected node.
            private TreeNode<PictureNode> SelectedNode;

            private void picTree_MouseClick(object sender, MouseEventArgs e)
            {
                FindNodeUnderMouse(e.Location);
            }

            // Set SelectedNode to the node under the mouse.
            private void FindNodeUnderMouse(PointF pt)
            {
                // Deselect the previously selected node.
                if (SelectedNode != null)
                {
                    SelectedNode.Data.Selected = false;
                    lblNodeText.Text = "";
                }

                // Find the node at this position (if any).
                using (Graphics gr = picTree.CreateGraphics())
                {
                    SelectedNode = root.NodeAtPoint(gr, pt);
                }

                // Select the node.
                if (SelectedNode != null)
                {
                    SelectedNode.Data.Selected = true;
                    lblNodeText.Text = SelectedNode.Data.Description;
                }

                // Redraw.
                picTree.Refresh();
            }
        }
}
