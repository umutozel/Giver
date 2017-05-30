using System.Reflection;

namespace Giver.ValueGenerators {

    public class DecimalGenerator : RandomGenerator<decimal> {

        public override decimal GetValue(MemberInfo memberInfo) {
            var scale = (byte)Random.Next(29);
            var sign = Random.Next(2) == 1;
            return new decimal(Random.NextIntRange(), Random.NextIntRange(), Random.NextIntRange(), sign, scale);
        }
    }
}
