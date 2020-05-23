using Cipher.Command;

namespace Cipher
{
	public class Program
	{
		public static void Main()
		{
			var storage = CLICommandMessageGenerator.ConstructMessage();
			storage.Exit = false;
			
			while(!storage.Exit)
			{
				CLICommandMessageGenerator.ConstructMessage(storage.ChosenCipher, storage);
				CLICommand.Execute(storage.LastCommand, storage);
			}
		}
	}
}
