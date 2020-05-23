using System;
using System.Collections.Generic;
using Cipher.Interface;
using Cipher.Ciphers.Ceasar;
using Cipher.Ciphers.Atbash;
using Cipher.Ciphers.Affine;
using Either;
using Cipher.Ciphers.ROT13;
using Cipher.Common.Model.Keys;

namespace Cipher.Command
{
    public static class AvailableCiphers
    {
        private static Dictionary<string, ISimpleCipher> SimpleCyphersAvailable = new Dictionary<string, ISimpleCipher>
        {
            { "ceasar", new CeasarCipher() },
            { "atbash", new AtbashCipher() },
            { "rot13", new ROT13Cipher()   }
        };

        private static Dictionary<string, IComplexCipher> ComplexCyphersAvailable = new Dictionary<string, IComplexCipher>
        {
            { "affine", new AffineCipher() }
        };

        public static List<string> CipherAvailableType = new List<string>
        {
            "Ceasar",
            "Atbash",
            "Affine"
        };

        public static Either<ISimpleCipher, IComplexCipher> GetCipher(string cipherKeyName, AffineKeys keys = null)
        {
            if(SimpleCyphersAvailable.ContainsKey(cipherKeyName))
            {
                return Either<ISimpleCipher, IComplexCipher>.Of(SimpleCyphersAvailable[cipherKeyName]);
            }

            if(ComplexCyphersAvailable.ContainsKey(cipherKeyName))
            {
                var cipher = ComplexCyphersAvailable[cipherKeyName];
                cipher.Set(keys);

                return Either<ISimpleCipher, IComplexCipher>.Of(cipher);
            }

            throw new ArgumentException("Unknown cipher");
        }
    }
}
