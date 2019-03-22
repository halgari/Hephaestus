﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Hephaestus.Model.Modpack.ModpackBase
{
    public class Header
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("source_url")]
        public string SourceUrl { get; set; }

        [JsonProperty("install_mod_organizer")]
        public bool InstallModOrganizer { get; set; }

        [JsonProperty("mod_organizer_version")]
        public ModOrganizerVersion ModOrganizerVersion { get; set; }

        [JsonProperty("mod_install_folders")]
        public List<string> ModInstallFolders { get; set; }
    }
}
