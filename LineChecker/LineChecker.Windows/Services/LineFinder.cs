using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Windows.UI.Popups;

namespace LineChecker.Services
{
    public class LineFinder
    {

        public async Task GetPercentages()
        {
            var messageDialog = new MessageDialog("");

            string html;
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.pregame.com/feeds/sb/default2.aspx?sport=nfl");
            try
            {
                WebResponse x = await req.GetResponseAsync();
                HttpWebResponse res = (HttpWebResponse)x;
                if (res != null)
                {
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        Stream stream = res.GetResponseStream();
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            html = reader.ReadToEnd();
                        }
                        HtmlDocument htmlDocument = new HtmlDocument();
                        htmlDocument.LoadHtml(html);


                        var table = htmlDocument.GetElementbyId("tblSpy");

                        var xx = 1;
                        //string appName = htmlDocument.GetElementbyId("application").ChildNodes[3].InnerText;
                        //TextBlockName.Text = "Name: " + WebUtility.HtmlDecode(appName);

                        //string appPublisher = htmlDocument.GetElementbyId("publisher").ChildNodes[3].InnerText;
                        //TextBlockPublisher.Text = "Publisher: " + WebUtility.HtmlDecode(appPublisher);

                        //string appImage = htmlDocument.GetElementbyId("appSummary").ChildNodes[1].ChildNodes[1].GetAttributeValue("src", "");
                        //ImageAppLogo.Source = new BitmapImage(new Uri(appImage, UriKind.Absolute));

                        //string appDescription = htmlDocument.GetElementbyId("appDescription").ChildNodes[1].ChildNodes[1].InnerText;
                        //TextBlockDescription.Text = "Description:\n" + WebUtility.HtmlDecode(appDescription);

                        //string appPrice = htmlDocument.GetElementbyId("offer").ChildNodes[1].InnerText;
                        //TextBlockPrice.Text = "Price: " + WebUtility.HtmlDecode(appPrice);

                        //string appCategory = htmlDocument.GetElementbyId("crumb").ChildNodes[1].ChildNodes[1].InnerText;
                        //appCategory = char.ToUpper(appCategory[0]) + appCategory.Substring(1);
                        //TextBlockCategory.Text = "Category: " + WebUtility.HtmlDecode(appCategory);
                    }
                    res.Dispose();
                }
            }
            catch
            {
                messageDialog.Title = "Error";
                messageDialog.Content = "Error";
            }
            await messageDialog.ShowAsync();
        }

      
    }
}
