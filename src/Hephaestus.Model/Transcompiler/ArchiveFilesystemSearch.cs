﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using Autofac;
using Hephaestus.Model.Transcompiler.Interfaces;
using IniParser;
using Syroot.Windows.IO;

namespace Hephaestus.Model.Transcompiler
{
    public class ArchiveFilesystemSearch : IArchiveFilesystemSearch
    {
        private readonly ITranscompilerBase _transcompilerBase;

        public ArchiveFilesystemSearch(IComponentContext components)
        {
            _transcompilerBase = components.Resolve<ITranscompilerBase>();
        }

        public string FindArchive(string archive)
        {
            if (archive.StartsWith("\"") || archive.EndsWith("\""))
            {
                archive = archive.Replace("\"", "");
            }

            if (Path.IsPathRooted(archive))
            {
                archive = Path.GetFileName(archive);
            }

            var test = Path.Combine(_transcompilerBase.ModsDirectoryPath, archive);

            if (File.Exists(Path.Combine(_transcompilerBase.DownloadsDirectoryPath, archive)))
            {
                return Path.Combine(_transcompilerBase.ModsDirectoryPath, archive);
            }

            var iniParser = new FileIniDataParser();
            var iniData = iniParser.ReadFile(Path.Combine(_transcompilerBase.MODirectory, _transcompilerBase.MOMetaFileName));

            var recentDirectory = iniData["recentDirectories"]["1\\directory"];

            if (Directory.Exists(recentDirectory) && File.Exists(Path.Combine(recentDirectory, archive)))
            {
                return Path.Combine(recentDirectory, archive);
            }

            // Check common directory locations
            var matchingFiles = new List<string>()
            {
                new KnownFolder(KnownFolderType.Downloads).Path,
                new KnownFolder(KnownFolderType.Documents).Path
            }.SelectMany(x => Directory.GetFiles(x, archive, SearchOption.TopDirectoryOnly));

            return matchingFiles.Any() ? matchingFiles.First() : string.Empty;
        }
    }
}
