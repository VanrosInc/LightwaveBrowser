using EasyTabs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightwaveBrowser
{
    public class LightwaveTabRenderer : BaseTabRenderer
    {
        public LightwaveTabRenderer(TitleBarTabs parentWindow)
            : base(parentWindow)
        {
            // Initialize the various images to use during rendering
            _activeLeftSideImage = Properties.Resources.Lightwave_Tab_Left;
            _activeRightSideImage = Properties.Resources.Lightwave_Tab_Right;
            _activeCenterImage = Properties.Resources.Lightwave_TabCenter;
            _inactiveLeftSideImage = Properties.Resources.Lightwave_TabCenter_Inactive_Left;
            _inactiveRightSideImage = Properties.Resources.Lightwave_TabCenter_Inactive_Right;
            _inactiveCenterImage = Properties.Resources.Lightwave_TabCenter_Inactive;
            _closeButtonImage = Properties.Resources.ChromeClose;
            _closeButtonHoverImage = Properties.Resources.ChromeCloseHover;
            _background = Properties.Resources.Lightwave_Tab_Background;
            _addButtonImage = new Bitmap(Properties.Resources.ChromeAdd, new Size(34, 18));
            _addButtonHoverImage = new Bitmap(Properties.Resources.ChromeAddHover, new Size(34, 25));

            // Set the various positioning properties
            CloseButtonMarginTop = 6;
            CloseButtonMarginLeft = 0;
            AddButtonMarginTop = 5;
            AddButtonMarginLeft = -10;
            CaptionMarginTop = 6;
            CaptionMarginLeft = 2;
            IconMarginTop = 7;
            IconMarginRight = 5;
            AddButtonMarginRight = 2;
        }
    }
}
