using System;
using Either;
using Cipher.Interface;
using Cipher.Common.Model;

namespace Cipher.Command
{
	public static class CLICommand
	{
		internal static Either<ISimpleCipher, IComplexCipher> _cipherContainer;

		public static void Execute(string command, Storage storage)
		{
			_cipherContainer = GetCipher(storage);
			var cipher = _cipherContainer.GetValue<ISimpleCipher>();

			if(cipher == null)
			{
				cipher = _cipherContainer.GetValue<IComplexCipher>();
			}

			switch (command)
			{
				case "exit":
					storage.Exit = true;
					break;
				case "encode":
					storage.Values.Encoded = cipher.Encode(storage.Values.Original);
					break;
				case "decode":
					storage.Values.Decoded = cipher.Decode(storage.Values.Encoded);
					break;
				default: throw new ArgumentException("Unkown command");
			}

			OutputValue(command, storage);
		}

		public static void OutputValue(string command, Storage storage)
		{
			switch (command)
			{
				case "encode":
					Console.WriteLine($"Encoded Value: {storage.Values.Encoded}");
					break;
				case "decode":
					Console.WriteLine($"Encoded Value: {storage.Values.Decoded}");
					break;
				default: return;
			}
		}

		private static Either<ISimpleCipher, IComplexCipher> GetCipher(Storage storage)
		{
			if(storage.ChosenCipher == "affine")
			{
				return AvailableCiphers.GetCipher(storage.ChosenCipher, storage.AffineKeys);
			}

			return AvailableCiphers.GetCipher(storage.ChosenCipher);
		}
	}
}
