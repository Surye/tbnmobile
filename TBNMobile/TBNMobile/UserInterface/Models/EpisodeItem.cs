using System;
using System.Collections.Generic;
using System.Text;
using TBNMobile.Database.Models;

namespace TBNMobile.UserInterface.Models
{
    public class EpisodeItem
    {

        public string MBSize {
            get {
                var val = Episode.Size / 1024.0 / 1024.0;
                var ret = String.Format("{0:0.00}MB", val);
                return ret;
            }
        }

        public Episode Episode { get; private set; }
        public Show Show { get; private set; }

        public EpisodeItem(Show show, Episode ep)
        {
            Episode = ep;
            Show = show;
        }
    }
}
