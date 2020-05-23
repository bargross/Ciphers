namespace Cipher.Interface
{
	public interface ISimpleCipher
	{
		string Encode(string value);
		string Decode(string encodedString);
	}
}
