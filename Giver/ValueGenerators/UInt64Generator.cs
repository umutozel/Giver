using System;
using System.Reflection;

namespace Giver.ValueGenerators {

    public class UInt64Generator : RandomGenerator<ulong> {

        public override ulong GetValue(MemberInfo memberInfo) {
            var buffer = new byte[8];
            Random.NextBytes(buffer);
            return BitConverter.ToUInt64(buffer, 0);
        }
    }
}
