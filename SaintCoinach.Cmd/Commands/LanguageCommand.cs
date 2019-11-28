using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Tharga.Toolkit.Console.Commands.Base;

#pragma warning disable CS1998

namespace SaintCoinach.Cmd.Commands {
    using Ex;

    public class LanguageCommand : ActionCommandBase {
        private ARealmReversed _Realm;

        public LanguageCommand(ARealmReversed realm)
            : base("lang", "Change the language.") {
            _Realm = realm;
        }

        public override void Invoke(string[] arguments) {
            if (arguments.Length == 0) {
                OutputInformation($"Current language: {_Realm.GameData.ActiveLanguage}");
                return;
            }

            if (!Enum.TryParse<Language>(arguments[0], out var newLang)) {
                newLang = LanguageExtensions.GetFromCode(arguments[0]);
                if (newLang == Language.Unsupported) {
                    OutputError("Unknown language.");
                    return;
                }
            }

            _Realm.GameData.ActiveLanguage = newLang;
        }
    }
}
