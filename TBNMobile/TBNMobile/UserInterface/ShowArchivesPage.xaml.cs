using System.Collections.Generic;
using TBNMobile.Database.Models;
using TBNMobile.UserInterface.Models;
using Xamarin.Forms;
using System;
using System.Linq;

namespace TBNMobile.UserInterface
{
	public partial class ShowArchivesPage : ContentPage
    {

        public List<EpisodeItem> FullEpisodeList { get; private set; }
        public Dictionary<int, Show> ShowMap { get; set; }
        public Dictionary<string, int> ShowPickerMap { get; set; }

        public ShowArchivesPage()
        {
            InitializeComponent();
            InitializeShows();


            ShowPicker.Items.Add("All Shows");
            foreach (var showName in ShowPickerMap.Keys)
                ShowPicker.Items.Add(showName);
            ShowPicker.SelectedIndex = 0;
            ShowPicker.SelectedIndexChanged += ShowPicker_SelectedIndexChanged;

            FullEpisodeList = GetEpisodeList();
            EpisodeList.ItemsSource = FullEpisodeList;
        }

        private void ShowPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ShowPicker.SelectedIndex == 0)
            {
                EpisodeList.ItemsSource = FullEpisodeList;
            } else
            {
                var showName = ShowPicker.Items[ShowPicker.SelectedIndex];
                var selectedShow = ShowMap[ShowPickerMap[showName]];
                EpisodeList.ItemsSource = FullEpisodeList.Where(ep => ep.Episode.ShowId == selectedShow.ID);
            }
        }

        private void InitializeShows()
        {
            var showMap = new Dictionary<int, Show>();
            var showPickerMap = new Dictionary<string, int>();
            var shows = App.Database.Conn.Table<Show>();

            foreach(var show in shows)
            {
                showMap.Add(show.ID, show);
                showPickerMap.Add(show.Name, show.ID);
            }

            ShowMap = showMap;
            ShowPickerMap = showPickerMap;
        }

        private List<EpisodeItem> GetEpisodeList()
        {
            var episodes = App.Database.Conn.Table<Episode>().OrderByDescending(ep => ep.AirTime);
            List<EpisodeItem> items = new List<EpisodeItem>();
                
            foreach (var episode in episodes)
            {
                try
                {
                    var show = ShowMap[episode.ShowId];
                    items.Add(new EpisodeItem(show, episode));
                }
                catch (Exception ex)
                {
                    Console.Out.WriteLine(ex.Message);
                }
            }
                
            return items;
        }
    }
}
