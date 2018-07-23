using Domain.Models;
using Foundation;
using System;
using UIKit;

namespace BooksApp
{
    public partial class BooksTVCell : UITableViewCell
    {
        #region Methods
        public BooksTVCell(IntPtr handle) : base(handle)
        {
        }

        public Book Item { get; set; }

        bool FirstTime = true;

        public void UpdateCell(Book item)
        {
            Item = item;
            ConfigureGraphicDetails();
            lbTitle.Text = item.Title;
            lbSubtitle.Text = item.SubTitle;

            if (FirstTime)
            {
                this.vMain.AddGestureRecognizer(new UITapGestureRecognizer(() => {
                    this.GotoDetail();
                }));
                FirstTime = false;
            }
        }

        void ConfigureGraphicDetails()
        {
            UIViewUtils.AddShadow(vMain, UIColor.White);
        }

        void GotoDetail()
        {
            var controller = StoryBoardsFactory.App.InstantiateViewController("BookDetailsViewController") as BookDetailsViewController;
            controller.BookItem = Item;
            UIViewControllersUtils.GetCurrentNavigation()?.PushViewController(controller, true);
        }

        #endregion
    }
}