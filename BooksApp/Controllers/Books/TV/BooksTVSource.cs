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
    public class BooksTVSource : UITableViewSource
    {
        public event EventHandler LoadMoreData;
        public List<Book> DataList;

        public BooksTVSource(List<Book> dataList)
        {
            this.DataList = dataList;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (BooksTVCell)tableView.DequeueReusableCell("BooksTVCell", indexPath);

            var item = this.DataList[indexPath.Row];

            cell.UpdateCell(item);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            var count = 0;
            if (this.DataList != null) count = this.DataList.Count;
            return count;
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            tableView.BackgroundView = null;
            var number = 0;
            if (DataList != null && DataList.Count > 0) number = 1;
            else
            {
                var newView = NotRecords.Create();
                newView.Frame = new CoreGraphics.CGRect(0, 0, tableView.Bounds.Size.Width, tableView.Bounds.Size.Height);
                tableView.BackgroundView = newView;
            }
            return number;
        }

        public override void Scrolled(UIScrollView scrollView)
        {
            CGPoint offset = scrollView.ContentOffset;
            CGRect bounds = scrollView.Bounds;
            CGSize size = scrollView.ContentSize;
            UIEdgeInsets inset = scrollView.ContentInset;
            float y = (float)offset.Y + (float)bounds.Size.Height - (float)inset.Bottom;
            float h = (float)size.Height;

            float reload_distance = 10;
            if (y > h + reload_distance)
            {
                LoadMoreData?.Invoke(null, null);
            }
        }

    }
}