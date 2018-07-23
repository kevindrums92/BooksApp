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
    [Register ("RecentlySearchesTVCell")]
    partial class RecentlySearchesTVCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView vMain { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lbTitle != null) {
                lbTitle.Dispose ();
                lbTitle = null;
            }

            if (vMain != null) {
                vMain.Dispose ();
                vMain = null;
            }
        }
    }
}