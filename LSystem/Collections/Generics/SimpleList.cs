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
        public bool Resizable
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

        #region Constructors

        /// <summary>
        /// Constructor that receives the capacity value.
        /// </summary>
        /// <param name="capacity">Indicates the max size of the SimpleList.</param>
        public SimpleList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("The capacity of a SimpleList must be greater than 0.", "capacity");

            _capacity = capacity;
            Count = 0;
            _items = new T[Capacity];
        }

        /// <summary>
        /// Constructor that receives the capacity and the resizable.
        /// </summary>
        /// <param name="capacity">Indicates the max size of the SimpleList.</param>
        /// <param name="resizable">Indicates if the list could be resized.</param>
        public SimpleList(int capacity, bool resizable) : this(capacity)
        {
            Resizable = resizable;
        }

        #endregion

        public T this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadOnly => throw new NotImplementedException();

        /// <summary>
        /// Add a new item to the list.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        public void Add(T item)
        {
            if (!Resizable && Count == Capacity)
                throw new InvalidOperationException("SimpleList is full. To add more items than the capacity, set Resizable to true.");

            if (Count == Capacity)
                Capacity = Capacity * 2;

            _items[Count++] = item;
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
        /// Reallocates the data to a new memory location.
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
