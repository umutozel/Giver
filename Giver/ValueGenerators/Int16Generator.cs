using System.Reflection;

namespace Giver.ValueGenerators {

    public class Int16Generator : RandomGenerator<short> {

        public override short GetValue(MemberInfo memberInfo) {
            return (short) Random.Next(short.MinValue, short.MaxValue);
        }
    }
}
