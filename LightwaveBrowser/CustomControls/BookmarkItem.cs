using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightwaveBrowser.CustomControls
{
    public partial class BookmarkItem : UserControl
    {
        private PictureBox picBox = null;
        private Label label = null;

        public BookmarkItem()
        {
            InitializeComponent();

        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            ToolTip toolTip = (ToolTip)sender;
            Graphics g = e.Graphics;
            Rectangle r = e.Bounds;
            g.FillRectangle(Brushes.White, r);
            g.DrawRectangle(Pens.Black, r);
            e.DrawText();
        }

        private string _toolTipText = "";
        public string ToolTipText
        {
            get => _toolTipText;
            set => _toolTipText = value;
        }

        private void BookmarkItem_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Show(_toolTipText, this.ParentForm, PointToClient(Control.MousePosition));
        }

        private void BookmarkItem_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this.ParentForm);
        }
    }
}
