using System.Reflection;

namespace Giver.ValueGenerators {

    public class BooleanGenerator : RandomGenerator<bool> {

        public override bool GetValue(MemberInfo memberInfo) {
            return Random.NextDouble() >= 0.5;
        }
    }
}
