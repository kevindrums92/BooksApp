using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Foundation;
using UIKit;

namespace BooksApp.Utils
{
    public class ImageUtils
    {
        public static void SetImageToControlFromUrl(string url, UIImageView control)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadDataCompleted += (object sender, DownloadDataCompletedEventArgs e) =>
                {
                    if (e.Error == null)
                    {
                        byte[] bytes = e.Result;
                        if (bytes != null && bytes.Length > 0)
                        {
                            var image = UIImage.LoadFromData(NSData.FromArray(bytes));
                            control.Image = image;
                        }
                    }
                };
                webClient.DownloadDataAsync(new Uri(url));
            }
        }
    }
}