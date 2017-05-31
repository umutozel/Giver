
using System;
using System.Reflection;

namespace Giver.ValueGenerators {

    public class DateTimeGenerator : RandomGenerator<DateTime> {

        public override DateTime GetValue(MemberInfo memberInfo) {
            var start = DateTime.MinValue;
            var range = DateTime.MaxValue - DateTime.MinValue;
            var date = start.AddHours(Random.Next(0, (int)range.TotalHours));
            date = date.AddMinutes(Random.Next(0, 60));
            date = date.AddSeconds(Random.Next(0, 60));
            return date.AddMilliseconds(Random.Next(0, 1000));
        }
    }
}
