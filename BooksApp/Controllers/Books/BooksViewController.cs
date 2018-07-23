using Domain.Models;
using Domain.Services;
using Foundation;
using System;
using UIKit;

namespace BooksApp
{
    public partial class BooksViewController : UIViewController
    {

        #region Properties

        public ResponseBooksDto ResponseBooksDto { get; set; }

        public bool IsLoading { get; set; }

        public BooksTVSource BooksTVSource { get; set; }

        SearchViewController _searcherController;
        public SearchViewController SearcherController
        {
            get
            {
                if (_searcherController == null)
                {
                    _searcherController = StoryBoardsFactory.App.InstantiateViewController("SearchViewController") as SearchViewController;
                    _searcherController.TriggerSearch += _searcherController_TriggerSearch;
                }
                return _searcherController;
            }
        }

        public int Page { get; set; } = 1;
        public int TotalPages {
            get
            {
                var res = 0;
                if (ResponseBooksDto != null)
                {
                    res = (int)ResponseBooksDto.Total / 10;
                }
                return res;
            }
        }

        #endregion

        #region LifeCycle
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ConfigureControls();
            ConfigureEvents();
        }

        public BooksViewController(IntPtr handle) : base(handle)
        {
        }
        #endregion

        #region Methods
        void ConfigureEvents()
        {
            sbSearcher.ShouldBeginEditing = delegate (UISearchBar obj)
            {
                GotoSearchController();
                return false;
            };
        }

        void ConfigureControls()
        {
            sbSearcher.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Clear, UIControlState.Normal);
        }

        void GotoSearchController()
        {
            this.NavigationController?.PushViewController(this.SearcherController, true);
        }
        #endregion

        #region Events
        private void _searcherController_TriggerSearch(object sender, string e)
        {
            sbSearcher.Text = e;
            Page = 1;
            LoadBooksAsync(e);
        }

        async void LoadBooksAsync(string query)
        {
            IsLoading = true;
            using (AppLoadingHUD loading = new AppLoadingHUD(this))
            {
                var data = await BooksService.GetArticlesAsync(query, this.Page);
                PopulateData(data);
                IsLoading = false;
            }
        }

        private void PopulateData(ResponseBooksDto data)
        {
            ResponseBooksDto = data;
            if(BooksTVSource == null)
            {
                this.tvBooks.RegisterNibForCellReuse(UINib.FromName("BooksTVCell", null), "BooksTVCell");
                BooksTVSource = new BooksTVSource(data.Books);
                this.tvBooks.Source = BooksTVSource;
                this.tvBooks.RowHeight = UITableView.AutomaticDimension;
                this.tvBooks.EstimatedRowHeight = UITableView.AutomaticDimension;
                BooksTVSource.LoadMoreData += BooksTVSource_LoadMoreData;
            }
            if(Page >1)
            {
                foreach (var item in data.Books)
                {
                    BooksTVSource.DataList.Add(item);
                }
            }
            else
            {
                BooksTVSource.DataList = data.Books;
            }
            this.tvBooks.ReloadData();
        }

        private void BooksTVSource_LoadMoreData(object sender, EventArgs e)
        {
            if (!IsLoading && Page < TotalPages)
            {
                this.Page += 1;
                LoadBooksAsync(sbSearcher.Text);
            }
        }
        #endregion
    }
}