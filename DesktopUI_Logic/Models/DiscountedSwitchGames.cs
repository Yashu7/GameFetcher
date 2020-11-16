using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopUI_Logic.Models
{
    public class DiscountedSwitchGames : IDiscountedGamesModel
    {
        public string Title { get; set; }
        public string OriginalPrice { get; set; }
        public string DiscountPrice { get; set; }
        public int PlatformId { get; set; } = 130;
    }
}
