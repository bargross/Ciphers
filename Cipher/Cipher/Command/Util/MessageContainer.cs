using System;
using System.Collections.Generic;

namespace Cipher.Command.Util
{
    public class MessageContainer
    {
        private Dictionary<string, List<string>> Messages = new Dictionary<string, List<string>>()
        {
            {"start", new List<string>
                {
                    "Choose one of the following ciphers: "
                }
            },
            {"affine", new List<string>
                {
                    "Choose one of the following odd keys: ",
                    "Choose a random key between 0-25"
                }
            }
        };
       
        public List<string> GetMessagesFor(string key)
        {
            if(Messages.ContainsKey(key))
            {
                throw new ArgumentException();
            }

            return Messages[key];
        }
    }
}
