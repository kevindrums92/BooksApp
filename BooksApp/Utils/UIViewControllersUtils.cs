using System;
using UIKit;

namespace BooksApp
{
    public class UIViewControllersUtils
    {
        public UIViewControllersUtils()
        {
        }

		public static UIViewController GetPresentedViewController(){
			var window = UIApplication.SharedApplication.KeyWindow;
			var vc = window.RootViewController;

			while(vc.PresentedViewController != null){
				vc = vc.PresentedViewController;
			}

			return vc;
		}

		public static void GoBack()
        {
			GetCurrentNavigation().PopViewController(true);
        }

		public static UINavigationController GetCurrentNavigation()
        {
            var viewController = UIViewControllersUtils.GetPresentedViewController() as UINavigationController;
            if (viewController != null)
            {
				return viewController;
            }
            else
            {
				viewController = UIViewControllersUtils.GetPresentedViewController().PresentingViewController as UINavigationController;
				if(viewController != null){
					return viewController;
				}else{
					return UIViewControllersUtils.GetPresentedViewController().NavigationController;
				}

            }
        }
    }
}
