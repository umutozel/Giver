using System.Linq;
using System.Reflection;

namespace Giver.ValueGenerators {

    public class StringGenerator : RandomGenerator<string> {
        private readonly string _seed = "abcdefghijklmnopqrstuvwxyz0123456789";

        public override string GetValue(MemberInfo memberInfo) {
            var size = Random.Next(0, 100);
            var chars = Enumerable.Range(0, size)
                .Select(x => _seed[Random.Next(0, _seed.Length)]);
            return new string(chars.ToArray());
        }
    }
}
