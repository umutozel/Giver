using System;
using System.Collections.Generic;

namespace Giver {

    public class Builder<T> where T : new() {
        private readonly Give _give;
        private readonly List<Action<T>> _buildActions = new List<Action<T>>();

        public Builder(Give give) {
            _give = give;
        }

        public Builder<T> With(Action<T> buildAction) {
            _buildActions.Add(buildAction);
            return this;
        }

        public T Now() {
            return _give.GenerateInstance(_buildActions);
        }

        public List<T> Now(int count) {
            return _give.GenerateList(count, _buildActions);
        }
        
        public static implicit operator T(Builder<T> builder) {
            return builder.Now();
        }
    }
}
