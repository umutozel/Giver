using System.Reflection;

namespace Giver.ValueGenerators {

    public class ByteGenerator : RandomGenerator<byte> {

        public override byte GetValue(MemberInfo memberInfo) {
            return (byte) Random.Next(byte.MinValue, byte.MaxValue);
        }
    }
}
