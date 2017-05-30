using System.Reflection;

namespace Giver.ValueGenerators {

    public class UInt16Generator : RandomGenerator<ushort> {

        public override ushort GetValue(MemberInfo memberInfo) {
            return (ushort) Random.Next(ushort.MinValue, ushort.MaxValue);
        }
    }
}
