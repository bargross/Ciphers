using System;
using System.Collections.Generic;

namespace Cipher.Command
{
    public static class MessageContainer
    {
        private static Dictionary<string, IEnumerable<string>> Messages = new Dictionary<string, IEnumerable<string>>()
        {
            {"start", new[]
                {
                    "Choose one of the following ciphers: "
                }
            },
            {"affine", new[]
                {
                    "Choose one of the following odd keys: ",
                    "Choose a random key between 0-25"
                }
            }
        };
       
        public static IEnumerable<string> GetMessagesFor(string key)
        {
            if(!Messages.ContainsKey(key))
            {
                return new string[0];
            }

            return Messages[key];
        }
    }
}
