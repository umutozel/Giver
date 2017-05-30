using System.Reflection;

namespace Giver.ValueGenerators {

    public class Int64Generator : RandomGenerator<long> {

        public override long GetValue(MemberInfo memberInfo) {
            return (long) (Random.NextDouble() * long.MaxValue);
        }
    }
}
