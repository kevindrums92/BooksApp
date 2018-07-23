using System;
using UIKit;

namespace BooksApp
{
    /// <summary>
    /// Clase de utilidades para los UIViews
    /// </summary>
    public class UIViewUtils
    {
        public UIViewUtils()
        {
        }

        /// <summary>
        /// Metodo para agregar sombra a los uiview, para dar efecto de card
        /// </summary>
        /// <param name="control"></param>
        /// <param name="bgColor"></param>
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

        /// <summary>
        /// Metodo para agregar efecto de input a un UIVIew
        /// </summary>
        /// <param name="control"></param>
        /// <param name="bgColor"></param>
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

        /// <summary>
        /// Metodo para agregar background color a los UIStackView
        /// </summary>
        /// <param name="color"></param>
        /// <param name="control"></param>
		public static void AddUIStackViewBackground(UIColor color, UIStackView control){
			var subView = new UIView(frame: control.Bounds);
			subView.BackgroundColor = color;
			subView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;
			control.InsertSubview(subView, 0);
		}
    }
}
