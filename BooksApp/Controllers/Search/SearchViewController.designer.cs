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
    [Register ("SearchViewController")]
    partial class SearchViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btnSearch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ivLeftArrow { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISearchBar sbSearcher { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView tvRecentlySearches { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView vTitle { get; set; }

        [Action ("BtnSearch_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BtnSearch_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (btnSearch != null) {
                btnSearch.Dispose ();
                btnSearch = null;
            }

            if (ivLeftArrow != null) {
                ivLeftArrow.Dispose ();
                ivLeftArrow = null;
            }

            if (sbSearcher != null) {
                sbSearcher.Dispose ();
                sbSearcher = null;
            }

            if (tvRecentlySearches != null) {
                tvRecentlySearches.Dispose ();
                tvRecentlySearches = null;
            }

            if (vTitle != null) {
                vTitle.Dispose ();
                vTitle = null;
            }
        }
    }
}