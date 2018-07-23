using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Domain.Models;
using Foundation;
using UIKit;

namespace BooksApp
{
    public class RecentlySearchesTVSource : UITableViewSource
    {
        public event EventHandler<string> ItemClicked;

        public List<string> DataList;

        public RecentlySearchesTVSource(List<string> dataList)
        {
            this.DataList = dataList;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (RecentlySearchesTVCell)tableView.DequeueReusableCell("RecentlySearchesTVCell", indexPath);

            var item = this.DataList[indexPath.Row];
            if (cell.FirstTime)
            {
                cell.ItemClicked += ItemClicked;
            }
            cell.UpdateCell(item);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            var count = 0;
            if (this.DataList != null) count = this.DataList.Count;
            return count;
        }

    }
}