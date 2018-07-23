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
    [Register ("BooksViewController")]
    partial class BooksViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar sbSearcher { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tvBooks { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (sbSearcher != null) {
                sbSearcher.Dispose ();
                sbSearcher = null;
            }

            if (tvBooks != null) {
                tvBooks.Dispose ();
                tvBooks = null;
            }
        }
    }
}