using Constants.Base;
using Domain.Models;
using Domain.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BooksService:BaseServicesModel
    {
        public static async Task<ResponseBooksDto> GetArticlesAsync(string query, int page)
        {

            var responseEntity = new ResponseBooksDto();
            try
            {
                var url = string.Format("{0}/search/{1}/page/{2}", GlobalConfig.BASE_URL, query, page);
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
                wr.Method = "GET";
                wr.ContentType = "application/json";
                
                using (WebResponse response = await wr.GetResponseAsync())
                {
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
                    {
                        string responseString = sr.ReadToEnd();
                        //var res = "{\"Error\":\"0\",\"Time\":0.0214,\"Total\":\"228\",\"Page\":3,\"Books\":[{\"ID\":533749522,\"Title\":\"Implementing SugarCRM\",\"SubTitle\":\"Introduce the leading Open Source CRM application into your small/mid-size business with this systematic, practical guide\",\"Description\":\"SugarCRM is a popular customer relationship management system. It is available in both free open source and commercial versions, making it an ideal way for small-medium business to try out a CRM system without committing large sums of money. Although ...\",\"Image\":\"http://s.it-ebooks-api.info/14/implementing_sugarcrm.jpg\",\"isbn\":\"9781904811688\"},{\"ID\":3426521078,\"Title\":\"PHP: The Good Parts\",\"SubTitle\":\"Delivering the Best of PHP\",\"Description\":\"Get past all the hype about PHP and dig into the real power of this language. This book explores the most useful features of PHP and how they can speed up the web development process, and explains why the most commonly used PHP elements are often mis ...\",\"Image\":\"http://s.it-ebooks-api.info/3/php_the_good_parts.jpg\",\"isbn\":\"9780596804374\"},{\"ID\":3398759608,\"Title\":\"MySQL Stored Procedure Programming\",\"SubTitle\":\"Building High-Performance Web Applications in MySQL\",\"Description\":\"MySQL Stored Procedure Programming covers a lot of ground. The book starts with a thorough introduction to stored procedures programming and functions, covering the fundamentals of data types, operators, and using SQL in stored procedures. You'll lea ...\",\"Image\":\"http://s.it-ebooks-api.info/3/mysql_stored_procedure_programming.jpg\",\"isbn\":\"9780596100896\"},{\"ID\":3636763595,\"Title\":\"PHP and MySQL 24-Hour Trainer\",\"Description\":\"Assuming no previous experience with PHP or MySQL, this book is ideal reading for anyone who wants to go beyond HTML / CSS in order to provide clients with the most dynamic web sites possible. The approachable tone breaks down the basics of programmi ...\",\"Image\":\"http://s.it-ebooks-api.info/2/php_and_mysql_24-hour_trainer.jpg\",\"isbn\":\"9781118066881\"},{\"ID\":4126030247,\"Title\":\"Expert PHP and MySQL\",\"Description\":\"As the world's most popular, general purpose, open source scripting language, PHP is frequently used with MySQL to create high-traffic, mission-critical applications. This indispensable book shares proven, author-tested best practices and expert tech ...\",\"Image\":\"http://s.it-ebooks-api.info/2/expert_php_and_mysql.jpg\",\"isbn\":\"9780470563120\"},{\"ID\":2725483026,\"Title\":\"Beginning PHP 6, Apache, MySQL 6 Web Development\",\"Description\":\"Apache, MySQL and PHP are each complex in and of themselves, and it's impossible for this book to cover every advanced detail of all three. The purpose of this book is to give you the best possible foundation for understanding how each of the core co ...\",\"Image\":\"http://s.it-ebooks-api.info/2/beginning_php_6_apache_mysql_6_web_development.jpg\",\"isbn\":\"9780470391143\"},{\"ID\":869476162,\"Title\":\"PHP and MySQL For Dummies, 3rd Edition\",\"Description\":\"Been thinking of creating a high-quality interactive Web site? This book is just what you need to get started! Here's the fun and easy way(r) to develop a Web application in PHP 4, 5, or 6 and MySQL 5, test your software, enable your Web pages to dis ...\",\"Image\":\"http://s.it-ebooks-api.info/9/php_and_mysql_for_dummies_3rd_edition.jpg\",\"isbn\":\"9780470096000\"},{\"ID\":1096327173,\"Title\":\"PHP 6 and MySQL 6 Bible\",\"Description\":\"MySQL is the leading open source database on the market and PHP continues to dominate the server side of the scripting market - together, they are the most popular and common team for creating dynamic, database-driven web sites. This comprehensive bo ...\",\"Image\":\"http://s.it-ebooks-api.info/9/php_6_and_mysql_6_bible.jpg\",\"isbn\":\"9780470384503\"},{\"ID\":1257472294,\"Title\":\"PHP and MySQL Web Development, 4th Edition\",\"Description\":\"PHP and MySQL are popular open-source technologies that are ideal for quickly developing database-driven Web applications. PHP is a powerful scripting language designed to enable developers to create highly featured Web applications quickly, and MySQ ...\",\"Image\":\"http://s.it-ebooks-api.info/10/php_and_mysql_web_development_4th_edition.jpg\",\"isbn\":\"9780672329166\"},{\"ID\":991677443,\"Title\":\"Expert PHP and MySQL\",\"SubTitle\":\"Application Design and Development\",\"Description\":\"Expert PHP and MySQL takes you beyond learning syntax to showing you how to apply proven software development methods to building commerce-grade PHP and MySQL projects that will stand the test of time and reliably deliver on customer needs.nnDevelo ...\",\"Image\":\"http://s.it-ebooks-api.info/6/expert_php_and_mysql.jpg\",\"isbn\":\"9781430260073\"}]}";
                        responseEntity = JsonConvert.DeserializeObject<ResponseBooksDto>(responseString);
                        return responseEntity;
                    }
                }
            }
            catch (System.Net.WebException webEx)
            {
                var message = string.Format(ResourcesAgent.GetResource("strWebException"), JsonConvert.SerializeObject(webEx));
                responseEntity.Error = "Ha ocurrido un error";
                return responseEntity;
            }
            catch (Exception ex)
            {
                var message = string.Format(ResourcesAgent.GetResource("strGenericException"), JsonConvert.SerializeObject(ex));
                responseEntity.Error = "Ha ocurrido un error";
                return responseEntity;
            }
        }
    }
}
