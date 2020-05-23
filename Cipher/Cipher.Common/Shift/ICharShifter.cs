namespace Cipher.Common.Shift
{
	public interface ICharShifter
	{
		char Shift(char character, int shiftCount);
		char UnShift(char character, int shiftCount);
	}
}
