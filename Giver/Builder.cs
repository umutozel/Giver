using System;
using System.Collections.Generic;

namespace Giver {

    public class Builder<T> where T : new() {
        private readonly Give _give;
        internal readonly List<Action<T>> _buildActions = new List<Action<T>>();

        public Builder(Give give) {
            _give = give;
        }

        public Builder<T> With(Action<T> buildAction) {
            _buildActions.Add(buildAction);
            return this;
        }

        public T Now() {
            var t = _give.Now<T>();
            RunBuildActions(t);
            return t;
        }

        public List<T> Now(int count) {
            var list = new List<T>(count);
            if (count == 0) return list;

            var members = Helper.GetPrimitiveMembers(typeof(T));
            for (var i = 0; i < count; i++) {
                var t = _give.Now<T>(members);
                RunBuildActions(t);
                list.Add(t);
            }
            return list;
        }

        private void RunBuildActions(T value) {
            foreach (var ba in _buildActions) {
                ba(value);
            }
        }

        public static implicit operator T(Builder<T> builder) {
            return builder.Now();
        }
    }
}
