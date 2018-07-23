using BooksApp.Utils;
using Domain.Models;
using Foundation;
using System;
using UIKit;

namespace BooksApp
{
    public partial class BookDetailsViewController : UIViewController
    {
        #region Properties
        public Book BookItem { get; set; }
        #endregion

        #region Methods
        void LoadData()
        {
            lbTitle.Text = BookItem.Title;
            lbSubtitle.Text = BookItem.Description;
            ImageUtils.SetImageToControlFromUrl(BookItem.Image, ivImage);
            this.NavigationController.NavigationBar.TintColor = UIColor.White;
        }
        #endregion

        #region Lifecycle
        public BookDetailsViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoadData();
        }
        #endregion
    }
}