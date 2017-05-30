using System;

namespace Giver.ValueGenerators {

    public abstract class RandomGenerator<T>: ValueGenerator<T> {
        protected readonly Random Random = new Random();
    }
}
