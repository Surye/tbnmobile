using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using TBNMobile.Database;
using TBNMobile.Database.Models;

namespace TBNMobile.Podcast
{
    public class Feed
    {
        public Uri URL { get; set; }
        public Show Show { get; set; }

        public Feed(Show show)
        {
            Show = show;
        }

        async public Task DownloadAndProcessAsync()
        {
            try
            {
                var client = new WebClient();
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                var xml = await client.DownloadStringTaskAsync(new Uri(Show.RssFeed, UriKind.Absolute));

                var episodes = ProcessEpisodes(xml);
                App.Database.Conn.InsertAll(episodes);
            } catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }

        private List<Episode> ProcessEpisodes(string xml)
        {
            var episodes = new List<Episode>();
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            foreach(XmlElement item in xmlDocument.SelectNodes("rss/channel/item"))
            {
                var guid = item["guid"].InnerText;
                if (App.Database.Conn.Table<Episode>().Where(ep => ep.ID == guid).Count() == 0)
                {
                    try
                    {
                        var episode = new Episode();

                        episode.Show = Show;
                        episode.ID = guid;
                        episode.Title = item["title"].InnerText;
                        episode.Subtitle = item["itunes:subtitle"].InnerText;
                        episode.Description = item["itunes:summary"].InnerText;
                        episode.Url = item["enclosure"].Attributes["url"].Value;
                        episode.Size = int.Parse(item["enclosure"].Attributes["length"].Value);

                        try
                        {
                            var duration = item["itunes:duration"].InnerText;
                            if (duration.Length == 5)
                                duration = "00:" + duration;
                            episode.Duration = Convert.ToInt32(TimeSpan.Parse(duration).TotalSeconds);
                        }
                        catch (Exception)
                        {
                            episode.Duration = -1;
                        }

                        episode.AirTime = DateTime.Parse(item["pubDate"].InnerText.Substring(5));

                        episodes.Add(episode);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error parsing episode: " + ex.Message);
                    }
                }
            }

            return episodes;
        }
    }
}
