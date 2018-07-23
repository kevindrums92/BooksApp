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
        /// <summary>
        /// Book que está en detalle
        /// </summary>
        public Book BookItem { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Carga los datos iniciales
        /// </summary>
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