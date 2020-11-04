﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopUI_Logic.Models
{
    public class PlatformModel
    {
        
        [JsonProperty("id")]
        public int platformId { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
