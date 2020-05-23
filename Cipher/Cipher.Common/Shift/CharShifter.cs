using System;

namespace Cipher.Common.Shift
{
    public class CharShifter: ICharShifter
    {
		private int _minUpper = 65;
		private int _maxUpper = 90;
		private int _minLower = 97;
		private int _maxLower = 122;

		public char Shift(char character, int shiftCount)
		{
			int charOrdinal = character;
			int shiftedOrdinal = charOrdinal + shiftCount;

			if ((charOrdinal < _minUpper && charOrdinal > _maxUpper)
				&& (charOrdinal < _minLower && charOrdinal > _maxLower))
			{
				throw new ArgumentException("Invalid character in string");
			}

			if (char.IsUpper(character))
			{
				if (shiftedOrdinal > _maxUpper)
				{
					return (char)(_minUpper + (shiftedOrdinal - _maxUpper));
				}
			}

			if (char.IsLower(character))
			{
				if (shiftedOrdinal > _maxLower)
				{
					return (char)(_minLower + (shiftedOrdinal - _maxLower));
				}
			}

			return (char)shiftedOrdinal;
		}

		public char UnShift(char character, int shiftCount)
		{
			int charOrdinal = character;
			int unShiftedOrdinal = charOrdinal - shiftCount;

			if ((charOrdinal < _minUpper && charOrdinal > _maxUpper)
				&& (charOrdinal < _minLower && charOrdinal > _maxLower))
			{
				throw new ArgumentException("Invalid character in string");
			}

			if (char.IsUpper(character))
			{
				if (unShiftedOrdinal < _minUpper)
				{
					var newOrdinal = _maxUpper - (_minUpper - unShiftedOrdinal);
					return (char)newOrdinal;
				}

			}

			if (char.IsLower(character))
			{
				if (unShiftedOrdinal < _minUpper)
				{
					return (char)(_maxLower - (_minLower - unShiftedOrdinal));
				}
			}

			return (char)unShiftedOrdinal;
		}
	}
}
