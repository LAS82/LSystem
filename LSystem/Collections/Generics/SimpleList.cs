using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LSystem.Collections.Generics
{
    [Serializable]
    public sealed class SimpleList<T> : IList<T>
    {
        #region [Properties]

        private T[] _items;

        private int _capacity;

        /// <summary>
        /// Indicates whether the list can be resized.
        /// </summary>
        private bool Resizable
        {
            get; set;
        }

        /// <summary>
        /// Indicates the max size of the SimpleList.
        /// </summary>
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (value < Count)
                    throw new ArgumentException("Capacity cannot be smaller then the actual list size.", "Capacity");

                if (!Resizable)
                    throw new InvalidOperationException("To change the initial capacity, set Resizable to true.");

                _capacity = value;

                ReallocateData();
            }
        }

        /// <summary>
        /// The actual list's length.
        /// </summary>
        public int Count { get; set; }

        #endregion

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #region [Private Methods]

        /// <summary>
        /// Reallocates the data to a new memory position.
        /// This just happens when the memory already contains
        /// items added.
        /// </summary>
        private void ReallocateData()
        {
            if (Count > 0)
            {
                T[] tempArr = new T[Capacity];
                Array.Copy(_items, 0, tempArr, 0, Count);
                _items = tempArr;
            }
            else
            {
                _items = new T[Capacity];
            }
        }

        #endregion
    }
}
