using Cipher.Common.Model;

namespace Cipher.Interface
{
    public interface IComplexCipher: ISimpleCipher
    {
        void Set<T>(T values) where T : Common.Model.Keys.IKeys<int>;
    }
}
