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

        /// <summary>
        /// Initializes the simple list with some items.
        /// </summary>
        /// <param name="items">Items to be added to the list.</param>
        public SimpleList(IEnumerable<T> items)
        {
            if (items == null)
                throw new ArgumentNullException("items", "Items parameter cannot be null.");

            ICollection<T> itemsCol = items as ICollection<T>;

            if (itemsCol != null)
                _capacity = itemsCol.Count;                

            Count = 0;
            _items = new T[Capacity];

            IEnumerator<T> enumerator = items.GetEnumerator();

            while (enumerator.MoveNext())
                Add(enumerator.Current);
        }

        #endregion

        /// <summary>
        /// Return the item's list based on the index
        /// </summary>
        /// <param name="index">Index of the list</param>
        /// <returns>The item based on the index</returns>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > Count - 1)
                    throw new ArgumentOutOfRangeException("index", "Index was out of range. Must be non-negative and less than the size of the collection.");

                return _items[index];
            }

            set
            {
                _items[index] = value;
            }
        }

        /// <summary>
        /// The SimpleList will never be read only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a new item to the list.
        /// </summary>
        /// <param name="item">Item to be added.</param>
        public void Add(T item)
        {
            if (!Resizable && Count == Capacity)
                throw new InvalidOperationException("SimpleList is full. To add more items than the capacity, set Resizable to true.");

            if (Count == Capacity)
                Capacity *= 2;

            _items[Count++] = item;
        }

        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(_items, 0, Count);
                Count = 0;
            }
        }

        /// <summary>
        /// Uses the Equals implementation to find the item.
        /// </summary>
        /// <param name="item">The item to search.</param>
        /// <returns>Indicates if the item was found.</returns>
        public bool Contains(T item)
        {
            for(int i = 0; i < Count; ++i)
                if (_items[i].Equals(item))
                    return true;

            return false;
        }

        /// <summary>
        /// Copies the list to the given array.
        /// </summary>
        /// <param name="array">The given array.</param>
        /// <param name="arrayIndex">The given array start index.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_items, 0, array, arrayIndex, Count);
        }

        /// <summary>
        /// Returns the list enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new SimpleEnumerator<T>(this);
        }

        /// <summary>
        /// Find the index of the first element that matches the item to search.
        /// </summary>
        /// <param name="item">Item to search.</param>
        /// <returns>The index.</returns>
        public int IndexOf(T item)
        {
            return Array.IndexOf<T>(_items, item, 0, Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            if (Count == Capacity)
                Capacity *= 2;

            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException("index", "Index was out of range. Must be non-negative and less than the size of the collection.");

            Array.Copy(_items, index, _items, index + 1, Count - index);
            _items[index] = item;
            Count++;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the list enumerator.
        /// </summary>
        /// <returns>The enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
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
