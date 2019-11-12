using LSystem.Collections.Generics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Collections.Generics
{
    public struct SimpleEnumerator<T> : IEnumerator<T>
    {

        /// <summary>
        /// Gets the current item.
        /// </summary>
        public T Current { get; private set; }

        /// <summary>
        /// Gets the current item.
        /// </summary>
        object IEnumerator.Current  => Current;

        /// <summary>
        /// The simple list to iterate.
        /// </summary>
        private SimpleList<T> _simpleList { get; set; }

        /// <summary>
        /// The current position index.
        /// </summary>
        private int _index { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="list"></param>
        internal SimpleEnumerator(SimpleList<T> list)
        {
            _simpleList = list;
            _index = -1;
            Current = default(T);
        }

        /// <summary>
        /// Cleans the list.
        /// </summary>
        public void Dispose()
        {
            //No need to dispose.
        }

        /// <summary>
        /// Moves to the next list's element.
        /// </summary>
        /// <returns>Indicates the iteration's end.</returns>
        public bool MoveNext()
        {
            if (_index < (_simpleList.Count - 1))
            {
                Current = _simpleList[++_index];
                return true;
            }

            Reset();

            return false;
        }

        /// <summary>
        /// Resets the iteration
        /// </summary>
        public void Reset()
        {
            _index = -1;
            Current = default(T);
        }
    }
}
