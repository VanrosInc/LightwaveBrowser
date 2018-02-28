using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightwaveBrowser
{
    internal class ToolstripColortable : ProfessionalColorTable
    {
        public override Color ToolStripBorder => Color.LightGray;
        public override Color ButtonSelectedHighlight => Color.Silver;
        public override Color ButtonPressedHighlight => Color.Teal;
    }
}
