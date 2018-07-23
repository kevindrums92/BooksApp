// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BooksApp
{
    [Register ("BookDetailsViewController")]
    partial class BookDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbSubtitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbTitle { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ivImage != null) {
                ivImage.Dispose ();
                ivImage = null;
            }

            if (lbSubtitle != null) {
                lbSubtitle.Dispose ();
                lbSubtitle = null;
            }

            if (lbTitle != null) {
                lbTitle.Dispose ();
                lbTitle = null;
            }
        }
    }
}