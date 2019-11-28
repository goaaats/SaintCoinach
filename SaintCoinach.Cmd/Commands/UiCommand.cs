using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tharga.Toolkit.Console;
using Tharga.Toolkit.Console.Commands.Base;

#pragma warning disable CS1998

namespace SaintCoinach.Cmd.Commands {
    public class UiCommand : ActionCommandBase {
        const string UiImagePathFormat = "ui/icon/{0:D3}000{1}/{2:D6}.tex";
        static readonly string[] UiVersions = new string[] {
            "",
            "/en",
            "/ja",
            "/fr",
            "/de",
            "/hq"
        };

        private ARealmReversed _Realm;

        public UiCommand(ARealmReversed realm)
            : base("ui", "Export all, a single, or a range of UI icons.") {
            _Realm = realm;
        }

        public override void Invoke(string[] arguments) {
            var min = 0;
            var max = 999999;

            if (arguments.Length != 0) {
                if (arguments.Length == 1) {
                    if (int.TryParse(arguments[0], out var parsed))
                        min = max = parsed;
                    else {
                        OutputError("Failed to parse parameters.");
                        return;
                    }
                } else if (arguments.Length == 2) {
                    if (!int.TryParse(arguments[0], out min) || !int.TryParse(arguments[1], out max)) {
                        OutputError("Failed to parse parameters.");
                        return;
                    }

                    if (max < min) {
                        OutputError("Invalid parameters.");
                        return;
                    }
                } else {
                    OutputError("Failed to parse parameters.");
                    return;
                }
            }

            var count = 0;
            for (int i = min; i <= max; ++i) {
                try {
                    count += Process(i);
                } catch (Exception e) {
                    OutputError($"{i:D6}: {e.Message}");
                }
            }
            OutputInformation($"{count} images processed");

            return;
        }

        private int Process(int i) {
            var count = 0;
            foreach (var v in UiVersions) {
                if (Process(i, v))
                    ++count;
            }
            return count;
        }
        private bool Process(int i, string version) {
            var filePath = string.Format(UiImagePathFormat, i / 1000, version, i);

            if (_Realm.Packs.TryGetFile(filePath, out var file)) {
                if (file is Imaging.ImageFile imgFile) {
                    var img = imgFile.GetImage();

                    var target = new FileInfo(Path.Combine(_Realm.GameVersion, file.Path));
                    if (!target.Directory.Exists)
                        target.Directory.Create();
                    var pngPath = target.FullName.Substring(0, target.FullName.Length - target.Extension.Length) + ".png";
                    img.Save(pngPath);

                    return true;
                } else {
                    OutputError($"{filePath} is not an image.");
                }
            }
            return false;
        }
    }
}
