using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tharga.Toolkit.Console.Commands.Base;

#pragma warning disable CS1998

namespace SaintCoinach.Cmd.Commands {
    public class RawCommand : ActionCommandBase {
        private ARealmReversed _Realm;

        public RawCommand(ARealmReversed realm)
            : base("raw", "Save raw contents of a file.") {
            _Realm = realm;
        }

        public override void Invoke(string[] arguments) {
            if (arguments.Length == 0)
                return;
            try {
                if (_Realm.Packs.TryGetFile(arguments[0], out var file)) {
                    var target = new FileInfo(Path.Combine(_Realm.GameVersion, file.Path));
                    if (!target.Directory.Exists)
                        target.Directory.Create();

                    var data = file.GetData();
                    File.WriteAllBytes(target.FullName, data);
                } else
                    OutputError("File not found.");
            } catch (Exception e) {
                OutputError(e.Message);
            }
        }
    }
}
