using System;
using System.Reflection;

namespace Giver.ValueGenerators {

    public class SingleGenerator : RandomGenerator<float> {

        public override float GetValue(MemberInfo memberInfo) {
            var mantissa = Random.NextDouble() * 2.0 - 1.0;
            var exponent = Math.Pow(2.0, Random.Next(-126, 128));
            return (float) (mantissa * exponent);
        }
    }
}
