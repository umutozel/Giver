using System;
using System.Reflection;

namespace Giver.ValueGenerators {

    public class DoubleGenerator : RandomGenerator<double> {

        public override double GetValue(MemberInfo memberInfo) {
            var bytes = new byte[sizeof(double)];
            Random.NextBytes(bytes);
            return (double)BitConverter.ToUInt64(bytes, 0) / ulong.MaxValue;
        }
    }
}
