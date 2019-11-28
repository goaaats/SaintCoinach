﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SaintCoinach.Ex;
using Tharga.Toolkit.Console.Commands.Base;

#pragma warning disable CS1998

namespace SaintCoinach.Cmd.Commands
{
    public class AllExdRawCommand : ActionCommandBase
    {
        private ARealmReversed _Realm;

        /// <summary>
        /// Setup the command
        /// </summary>
        /// <param name="realm"></param>
        public AllExdRawCommand(ARealmReversed realm)
            : base("allrawexd", "Export all data (default), or only specific data files, seperated by spaces; including all languages. No post-processing is applied to values.")
        {
            _Realm = realm;
        }

        /// <summary>
        /// Obtain game sheets from the game data
        /// </summary>
        /// <param name="paramList"></param>
        /// <returns></returns>
        public override void Invoke(string[] arguments)
        {
            var versionPath = _Realm.GameVersion;
            if (arguments?.Contains("/UseDefinitionVersion") ?? false)
                versionPath = _Realm.DefinitionVersion;

            AssignVariables(this, string.Join(" ", arguments));

            const string CsvFileFormat = "raw-exd-all/{0}{1}.csv";

            IEnumerable<string> filesToExport;

            // Gather files to export, may be split by params.
            if (arguments.Length == 0)
                filesToExport = _Realm.GameData.AvailableSheets;
            else
                filesToExport = arguments.Select(_ => _Realm.GameData.FixName(_));

            // Action counts
            var successCount = 0;
            var failCount = 0;
            var currentCount = 0;
            var total = filesToExport.Count();

            // Process game files.
            foreach (var name in filesToExport)
            {
                currentCount++;
                var sheet = _Realm.GameData.GetSheet(name);

                // Loop through all available languages
                foreach (var lang in sheet.Header.AvailableLanguages)
                {
                    var code = lang.GetCode();
                    if (code.Length > 0)
                        code = "." + code;

                    var target = new FileInfo(Path.Combine(versionPath, string.Format(CsvFileFormat, name, code)));

                    try
                    {
                        if (!target.Directory.Exists)
                            target.Directory.Create();

                        // Save
                        OutputInformation("[{currentCount}/{total}] Processing: {name} - Language: {lang.GetSuffix(}");
                        ExdHelper.SaveAsCsv(sheet, lang, target.FullName, true);
                        ++successCount;
                    }
                    catch (Exception e)
                    {
                        OutputError($"Export of {name} failed: {e.Message}");
                        try { if (target.Exists) { target.Delete(); } } catch { }
                        ++failCount;
                    }
                }
            }

            OutputInformation("{successCount} files exported, {1failCount} failed");
        }
    }
}