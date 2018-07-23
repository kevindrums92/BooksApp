﻿using Constants.Base;
using Foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UIKit;

namespace BooksApp
{
    public partial class SearchViewController : UIViewController
    {
        #region Properties
        public RecentlySearchesTVSource RecentlySearchesTVSource { get; set; }

        public List<string> RecentlySearches
        {
            get
            {
                var recently = UserPreferencesClient.GetStoredStringValue(GlobalConfig.RECENTLY_SEARCHES_KEY);
                if (string.IsNullOrEmpty(recently))
                {
                    return new List<string>();
                }
                else
                {
                    return JsonConvert.DeserializeObject<List<string>>(recently);
                }
            }
        }
        #endregion

        #region Lifecycle
        public SearchViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ConfigureView();
            ConfigureEvents();
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            LoadRecentlySearches();
        }
        #endregion

        #region Methods
        void ConfigureEvents()
        {
            ivLeftArrow.BringSubviewToFront(this.View);
            ivLeftArrow.UserInteractionEnabled = true;
            ivLeftArrow.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                GoBack();
            }));
            sbSearcher.BecomeFirstResponder();
        }

        void ConfigureView()
        {
            this.NavigationItem.SetHidesBackButton(true, false);
        }

        void GoBack()
        {
            this.NavigationController.PopViewController(true);
        }

        void LoadRecentlySearches()
        {
            this.tvRecentlySearches.RegisterNibForCellReuse(UINib.FromName("RecentlySearchesTVCell", null), "RecentlySearchesTVCell");
            if (RecentlySearchesTVSource == null)
            {
                RecentlySearchesTVSource = new RecentlySearchesTVSource(RecentlySearches);
                this.tvRecentlySearches.Source = RecentlySearchesTVSource;
                this.tvRecentlySearches.RowHeight = UITableView.AutomaticDimension;
                this.tvRecentlySearches.EstimatedRowHeight = UITableView.AutomaticDimension;
                RecentlySearchesTVSource.ItemClicked += RecentlySearchesTVSource_ItemClicked;
            }
            RecentlySearchesTVSource.DataList = RecentlySearches;
            this.tvRecentlySearches.ReloadData();
            if(RecentlySearches.Count > 0)
            {
                vTitle.Hidden = false;
            }
        }

        void TriggerFilter(string filter)
        {
            //Valido que el texto clickeado o escrito, no esté agregado en el listado temporal
            if (string.IsNullOrEmpty(RecentlySearches.Find(x => x.Equals(filter))))
            {
                var list = RecentlySearches;
                list.Insert(0,filter);
                UserPreferencesClient.StoreStringValue(GlobalConfig.RECENTLY_SEARCHES_KEY, JsonConvert.SerializeObject(list.Take(5)));
            }
            TriggerSearch?.Invoke(sbSearcher, filter);
            GoBack();
        }

        #endregion

        #region Events
        public event EventHandler<string> TriggerSearch;

        partial void BtnSearch_TouchUpInside(UIButton sender)
        {
            if (!string.IsNullOrEmpty(sbSearcher.Text))
            {
                TriggerFilter(sbSearcher.Text);
            }
        }

        private void RecentlySearchesTVSource_ItemClicked(object sender, string e)
        {
            TriggerFilter(e);
        }

        #endregion

    }
}