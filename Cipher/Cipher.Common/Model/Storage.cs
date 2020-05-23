using Cipher.Common.Model.Keys;

namespace Cipher.Common.Model
{
	public class Storage
	{
		public string ChosenCipher { get; set; }
		public string LastCommand { get; set; }
		public Encrypted Values { get; set; }
		public AffineKeys AffineKeys { get; set; }
		public bool Exit { get; set; }
	}
}
