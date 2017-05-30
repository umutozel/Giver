using System.Reflection;

namespace Giver.ValueGenerators {

    public class Int32Generator : RandomGenerator<int> {

        public override int GetValue(MemberInfo memberInfo) {
            return Random.NextIntRange();
        }
    }
}
