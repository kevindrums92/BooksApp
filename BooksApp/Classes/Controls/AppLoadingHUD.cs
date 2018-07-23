using CoreGraphics;
using Foundation;
using MBProgressHUD;
using SDWebImage;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace BooksApp
{
    public class AppLoadingHUD : IDisposable
    {
        private MTMBProgressHUD _hud;

        public AppLoadingHUD(UIViewController controller)
        {

            UIView view = UIViewControllersUtils.GetPresentedViewController().View;
            view.BackgroundColor = UIColor.Black;

            _hud = new MTMBProgressHUD(view)
            {
                RemoveFromSuperViewOnHide = true,
                BackgroundColor = UIColor.Black.ColorWithAlpha((float)0.7)
            };

            _hud.Mode = MBProgressHUDMode.CustomView;
            _hud.DimBackground = false;

            _hud.Square = true;
            _hud.LabelText = @"";
            _hud.Color = UIColor.Clear;
            _hud.LabelColor = UIColor.Clear;


            view.AddSubview(_hud);

            UIImageView imageView = new UIImageView(CGRect.FromLTRB(0, 0, 45, 45));
            var url = NSBundle.MainBundle.GetUrlForResource("loading", "gif", "Loading");
            imageView.ContentMode = UIViewContentMode.ScaleAspectFit;
            imageView.SetImage(url);
            _hud.CustomView = imageView;



            _hud.Show(animated: true);

        }

        public void Dispose()
        {
            _hud.Hide(true);
        }
    }
}
