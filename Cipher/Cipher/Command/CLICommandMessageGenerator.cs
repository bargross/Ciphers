using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Cipher.IO;
using Cipher.Common.Model;
using Cipher.Common.Number;
using Cipher.Splitter;

namespace Cipher.Command
{
    public static class CLICommandMessageGenerator
    {
        private static IOddNumberGenerator _oddNumberGenerator = new OddNumberGenerator();

        internal static IEnumerable<string> _excluded = new[]
        {
            "exit",
            "decode"
        };

        public static bool IsNotExcluded(string command) => !_excluded.Contains(command);

        private static string Start()
        {
            var initialMessageContainer = MessageContainer.GetMessagesFor("start");
            var initialMessage = initialMessageContainer.ElementAt(0);

            var builder = new StringBuilder(initialMessage);
            var index = 0;
            foreach (var availableCipher in AvailableCiphers.CipherAvailableType)
            {
                builder.Append(Environment.NewLine);
                builder.Append($"{index++} - {availableCipher}");
            }

            Printer.Print(builder.ToString());

            var chosenCipher = Reader.Read<int>();

            return AvailableCiphers.CipherAvailableType[chosenCipher];
        }

        public static Storage ConstructMessage(string key = null, Storage storage = null)
        {
            Storage currentStorage = null;
            if(key == null && storage == null)
            {
                key = Start();

                currentStorage = new Storage
                {
                    ChosenCipher = key,
                    Values = new Encrypted(),
                    AffineKeys = new Common.Model.Keys.AffineKeys()
                };
            } 
            else
            {
                currentStorage = storage;
            }

            var messages = MessageContainer.GetMessagesFor(key);

            switch(key)
            {
                case "affine":
                    GetInputForAffineCipher(messages, currentStorage);
                    GetInputFor(currentStorage);
                    break;
                default:
                    GetInputFor(currentStorage);
                    break;
            }

            return currentStorage;
        }

        private static void GetInputFor(Storage storage)
        {
            var commandsAndWords = Reader.Read<string>();
            (string command, string words) = LineSplitter.GetCommandAndWords(commandsAndWords);

            if(IsNotExcluded(command))
            {
                storage.Values.Original = words;
            }
        }

        private static void GetInputForAffineCipher(IEnumerable<string> messages, Storage storage)
        {
            Printer.Print(messages.ElementAt(0));

            var oddNumberSequence = _oddNumberGenerator.GetNumbersBetween(0, 25);
            var builder = new StringBuilder();
            foreach(var number in oddNumberSequence)
            {
                builder.Append($"{number} ");
            }

            Printer.Print(builder.ToString());

            var oddKey = Reader.Read<int>();
            if(NumberValidator.IsOdd(oddKey))
            {
                if (oddNumberSequence.Contains(oddKey))
                {
                    storage.AffineKeys.KeyOne = oddKey;
                }

                Printer.Print(messages.ElementAt(1));

                var randKey = Reader.Read<int>();
                if (randKey >= 0 && randKey <= 25)
                {
                    storage.AffineKeys.KeyTwo = randKey;
                }
            }
        }
    }
}
