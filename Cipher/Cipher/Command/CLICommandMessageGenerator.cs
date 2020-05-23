using Cipher.Command.Util;
using Cipher.Common.Model;
using Cipher.Common.Number;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Cipher.Command
{
    public static class CLICommandMessageGenerator
    {
        private static MessageContainer _messageContainer = new MessageContainer();
        private static OddNumberGenerator _oddNumberGenerator = new OddNumberGenerator();

        internal static List<string> _excluded = new List<string>
        {
            "exit",
            "decode"
        };

        public static bool IsNotExcluded(string command) => !_excluded.Contains(command);

        private static string InitialMessage()
        {
            var initialMessageContainer = _messageContainer.GetMessagesFor("start");
            var initialMessage = initialMessageContainer[0];

            var builder = new StringBuilder(initialMessage);
            var index = 0;
            foreach (var availableCipher in AvailableCiphers.CipherAvailableType)
            {
                builder.Append(Environment.NewLine);
                builder.Append($"{index++} - {availableCipher}");
            }

            Console.WriteLine(builder.ToString());
            var chosenCipher = int.Parse(Console.ReadLine());

            return AvailableCiphers.CipherAvailableType[chosenCipher];
        }

        public static Storage ConstructMessage(string key = null, Storage storage = null)
        {
            if(key == null && storage == null)
            {
                key = InitialMessage();
            
                storage = new Storage
                {
                    ChosenCipher = key
                };
            }

            var messages = _messageContainer.GetMessagesFor(key);

            switch(key)
            {
                case "affine":
                    GetInputForAffineCipher(messages, storage);
                    GetInputFor(storage);
                    break;
                default:
                    GetInputFor(storage);
                    break;
            }

            return storage;
        }

        private static void GetInputFor(Storage storage)
        {
            var input = Console.ReadLine();
            (string command, string words) = Splitter.GetCommandAndWords(input);

            if(IsNotExcluded(command))
            {
                storage.Values.Original = words;
            }
        }

        private static void GetInputForAffineCipher(List<string> messages, Storage storage)
        {
            Console.WriteLine(messages[0]);
            Console.WriteLine(Environment.NewLine);

            var oddKeysAllowed = _oddNumberGenerator.GetNumbersBetween(0, 25);
            Console.WriteLine(oddKeysAllowed.ToString());

            var initialInput = Console.ReadLine();
            var oddKey = int.Parse(initialInput);

            if (oddKeysAllowed.Contains(oddKey))
            {
                storage.AffineKeys.KeyOne = oddKey;
            }

            Console.WriteLine(messages[1]);
            var randKey = int.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            if (randKey >= 0 && randKey <= 25)
            {
                storage.AffineKeys.KeyTwo = randKey;
            }
        }
    }
}
