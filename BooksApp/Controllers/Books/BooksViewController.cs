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
        /// <summary>
        /// Entidad que contiene el resultado de las peticiones
        /// </summary>
        public ResponseBooksDto ResponseBooksDto { get; set; }

        /// <summary>
        /// Variable para controlar cuando se este cargando asíncronamente los datos
        /// </summary>
        public bool IsLoading { get; set; }

        /// <summary>
        /// Objeto que contiene el Source del Table View
        /// </summary>
        public BooksTVSource BooksTVSource { get; set; }

        SearchViewController _searcherController;
        /// <summary>
        /// View Controller que ejecuta las acciones de buscado
        /// </summary>
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

        /// <summary>
        /// Página que se envía a consultar
        /// </summary>
        public int Page { get; set; } = 1;
        /// <summary>
        /// Devuelve el total de las páginas en la consulta, en base a el obj ResponseBooksDto
        /// </summary>
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
        /// <summary>
        /// Se inicializan Eventos
        /// </summary>
        void ConfigureEvents()
        {
            sbSearcher.ShouldBeginEditing = delegate (UISearchBar obj)
            {
                GotoSearchController();
                return false;
            };
        }

        /// <summary>
        /// Se realizan configuraciones de controles
        /// </summary>
        void ConfigureControls()
        {
            sbSearcher.SetImageforSearchBarIcon(new UIImage(), UISearchBarIcon.Clear, UIControlState.Normal);
        }

        /// <summary>
        /// Se ejecuta este metodo cuando se da tap en el control de búsqueda para navegar al controlador Searcher
        /// </summary>
        void GotoSearchController()
        {
            this.NavigationController?.PushViewController(this.SearcherController, true);
        }
        #endregion

        #region Events
        /// <summary>
        /// Este método se dispara cuando desde el Searcher se envía a consultar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _searcherController_TriggerSearch(object sender, string e)
        {
            sbSearcher.Text = e;
            //ReInicializamos en 1 la página
            Page = 1;
            LoadBooksAsync(e);
        }

        /// <summary>
        /// Método para hacer la carga asíncrona de los datos
        /// </summary>
        /// <param name="query"></param>
        async void LoadBooksAsync(string query)
        {
            IsLoading = true;
            using (AppLoadingHUD loading = new AppLoadingHUD(this))
            {
                var data = await BooksService.GetBooksAsync(query, this.Page);
                PopulateData(data);
                IsLoading = false;
            }
        }

        /// <summary>
        /// Método para poblar el table View
        /// </summary>
        /// <param name="data"></param>
        private void PopulateData(ResponseBooksDto data)
        {
            ResponseBooksDto = data;
            if(BooksTVSource == null)
            {
                //se registra el recurso Nib en el table view
                this.tvBooks.RegisterNibForCellReuse(UINib.FromName("BooksTVCell", null), "BooksTVCell");
                BooksTVSource = new BooksTVSource(data.Books);
                this.tvBooks.Source = BooksTVSource;
                this.tvBooks.RowHeight = UITableView.AutomaticDimension;
                this.tvBooks.EstimatedRowHeight = UITableView.AutomaticDimension;
                BooksTVSource.LoadMoreData += BooksTVSource_LoadMoreData;
            }
            if(Page >1)
            {
                //Si es una carga hecha desde el scroll, se concatena los resultados
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
            //Solo se envía a consultar la nueva página si no esta cargando ya y si hay páginas por cargar
            if (!IsLoading && Page < TotalPages)
            {
                this.Page += 1;
                LoadBooksAsync(sbSearcher.Text);
            }
        }
        #endregion
    }
}