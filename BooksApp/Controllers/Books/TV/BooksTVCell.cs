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

        /// <summary>
        /// Book en celda
        /// </summary>
        public Book Item { get; set; }

        /// <summary>
        /// Variable que establece si es la primera vez que ingresa a crear la celda, para inicializar eventos
        /// </summary>
        bool FirstTime = true;

        /// <summary>
        /// Método para asignar los datos que van en la vista de la celda
        /// </summary>
        /// <param name="item"></param>
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

        /// <summary>
        /// Se establecen algunas características gráficas
        /// </summary>
        void ConfigureGraphicDetails()
        {
            UIViewUtils.AddShadow(vMain, UIColor.White);
        }

        /// <summary>
        /// Se navega al detalle del item
        /// </summary>
        void GotoDetail()
        {
            var controller = StoryBoardsFactory.App.InstantiateViewController("BookDetailsViewController") as BookDetailsViewController;
            controller.BookItem = Item;
            UIViewControllersUtils.GetCurrentNavigation()?.PushViewController(controller, true);
        }

        #endregion
    }
}