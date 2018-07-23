using Foundation;
using ObjCRuntime;
using System;
using UIKit;

namespace BooksApp
{
    public partial class NotRecords : UIView
    {
        public NotRecords (IntPtr handle) : base (handle)
        {
        }

        public static NotRecords Create()
        {
            var arr = NSBundle.MainBundle.LoadNib("NotRecords", null, null);
            var x = Runtime.GetNSObject<NotRecords>(arr.ValueAt(0));
            x.ConfigureResources();
            return x;
        }

        void ConfigureResources()
        {
            lbTitle.Text = "!Lo sentimos!\nNo se encontró resultados\nen la búsqueda.";
        }
    }
}