using System;
using UIKit;

namespace BooksApp
{
    public class UIViewUtils
    {
        public UIViewUtils()
        {
        }

		public static void AddShadow(UIView control, UIColor bgColor)
        {
            var layer = control.Layer;
            layer.CornerRadius = 2;
            layer.MasksToBounds = false;

            layer.ShadowOffset = new CoreGraphics.CGSize(1.5, 1.5);
            layer.ShadowColor = UIColor.Black.CGColor;
            layer.ShadowRadius = 2;
            layer.ShadowOpacity = (float)0.45;

            control.BackgroundColor = null;
            layer.BackgroundColor = bgColor.CGColor;
        }

		public static void AddBoxEffect(UIView control, UIColor bgColor)
        {
            var layer = control.Layer;
            layer.CornerRadius = 1;
            layer.MasksToBounds = false;

            layer.ShadowOffset = new CoreGraphics.CGSize(-1.5, -1.5);
            layer.ShadowColor = UIColor.Black.CGColor;
            layer.ShadowRadius = 2;
            layer.ShadowOpacity = (float)0.45;

			layer.BorderColor = ColorsRes.BGUItextViewBorderColor.CGColor;
			layer.BorderWidth = 1.0f;
			layer.MasksToBounds = true;

            control.BackgroundColor = null;
            layer.BackgroundColor = bgColor.CGColor;
        }

		public static void AddUIStackViewBackground(UIColor color, UIStackView control){
			var subView = new UIView(frame: control.Bounds);
			subView.BackgroundColor = color;
			subView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			control.InsertSubview(subView, 0);
		}
    }
}
