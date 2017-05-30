using System.Reflection;

namespace Giver.ValueGenerators {

    public class UInt32Generator : RandomGenerator<uint> {

        public override uint GetValue(MemberInfo memberInfo) {
            var thirtyBits = (uint)Random.Next(1 << 30);
            var twoBits = (uint)Random.Next(1 << 2);
            return (thirtyBits << 2) | twoBits;
        }
    }
}
