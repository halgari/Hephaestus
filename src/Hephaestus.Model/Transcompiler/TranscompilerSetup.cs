﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hephaestus.Model.Transcompiler.Interfaces;

namespace Hephaestus.Model.Transcompiler
{
    public class TranscompilerSetup : ITranscompilerSetup
    {
        private readonly ITranscompilerBase _transcompilerBase;

        public TranscompilerSetup(ITranscompilerBase transcompilerBase)
        {
            _transcompilerBase = transcompilerBase;
        }

        public void SetModOrganizerExePath(string path)
        {
            var pathDirectory = Path.GetDirectoryName(path);

            _transcompilerBase.ModsDirectoryPath = Path.Combine(pathDirectory, "mods");
            _transcompilerBase.ProfilesDirectoryPath = Path.Combine(pathDirectory, "profiles");
        }

        public List<string> GetModOrganizerProfiles()
        {
            return Directory.GetDirectories(_transcompilerBase.ProfilesDirectoryPath).ToList();
        }

        public void SetModOrganizerProfile()
        {

        }

        public void SetModOrganizerCsv(string csv)
        {

        }
    }
}