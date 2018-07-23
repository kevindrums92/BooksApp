using Foundation;
using System;
using UIKit;

namespace BooksApp
{
    public partial class RecentlySearchesTVCell : UITableViewCell
    {
        public event EventHandler<string> ItemClicked;
        public RecentlySearchesTVCell (IntPtr handle) : base (handle)
        {
        }

        public bool FirstTime = true;

        public void UpdateCell(string text)
        {
            lbTitle.Text = text;
            if (FirstTime)
            {
                vMain.BringSubviewToFront(this);
                vMain.UserInteractionEnabled = true;
                vMain.AddGestureRecognizer(new UITapGestureRecognizer(()=> {
                    SelectFilter();
                }));
                FirstTime = false;
            }
        }

        void SelectFilter()
        {
            ItemClicked?.Invoke(null, lbTitle.Text);
        }
    }
}