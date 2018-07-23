using System;
using UIKit;

namespace BooksApp
{
    /// <summary>
    /// Clase de utilidades para los view controllers
    /// </summary>
    public class UIViewControllersUtils
    {
        public UIViewControllersUtils()
        {
        }

        /// <summary>
        /// Método que devuelve el view controller actual
        /// </summary>
        /// <returns></returns>
		public static UIViewController GetPresentedViewController(){
			var window = UIApplication.SharedApplication.KeyWindow;
			var vc = window.RootViewController;

			while(vc.PresentedViewController != null){
				vc = vc.PresentedViewController;
			}

			return vc;
		}

        /// <summary>
        /// Metodo para navegar atras, solo funcionará si se está en un control de navegación
        /// </summary>
		public static void GoBack()
        {
			GetCurrentNavigation().PopViewController(true);
        }

        /// <summary>
        /// Devuelve el Navigation Controller Actual
        /// </summary>
        /// <returns></returns>
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
