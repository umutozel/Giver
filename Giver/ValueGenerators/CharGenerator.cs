using System.Reflection;

namespace Giver.ValueGenerators {

    public class CharGenerator : RandomGenerator<char> {

        public override char GetValue(MemberInfo memberInfo) {
            return (char) Random.Next(char.MinValue, char.MaxValue);
        }
    }
}
