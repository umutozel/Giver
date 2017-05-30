using System.Reflection;

namespace Giver.ValueGenerators {

    public class SByteGenerator : RandomGenerator<sbyte> {

        public override sbyte GetValue(MemberInfo memberInfo) {
            return (sbyte) Random.Next(sbyte.MinValue, sbyte.MaxValue);
        }
    }
}
