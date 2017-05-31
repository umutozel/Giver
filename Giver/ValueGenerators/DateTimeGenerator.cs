
using System;
using System.Reflection;

namespace Giver.ValueGenerators {

    public class DateTimeGenerator : RandomGenerator<DateTime> {

        public override DateTime GetValue(MemberInfo memberInfo) {
            var start = DateTime.MinValue;
            var range = DateTime.MaxValue - DateTime.MinValue;
            return start
                .AddHours(Random.Next(0, (int)range.TotalHours))
                .AddMinutes(Random.Next(0, 60))
                .AddSeconds(Random.Next(0, 60))
                .AddMilliseconds(Random.Next(0, 1000));
        }
    }
}
