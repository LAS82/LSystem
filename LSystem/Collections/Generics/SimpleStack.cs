using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Collections.Generics
{
    [Serializable]
    [DebuggerDisplay("Count = {Count}")]
    /// <summary>
    /// A stack container implemented using a LinkedList
    /// </summary>
    /// <typeparam name="T">Any object</typeparam>
    public class SimpleStack<T>
    {

        #region [Properties]

        /// <summary>
        /// Data
        /// </summary>
        LinkedList<T> _items;

        /// <summary>
        /// Container length.
        /// </summary>
        public int Count => this._items.Count;

        #endregion

        #region [Constructors]

        /// <summary>
        /// Constructor
        /// </summary>
        public SimpleStack()
        {
            this._items = new LinkedList<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The items to initialize the container</param>
        public SimpleStack(IEnumerable<T> items) : this()
        {
            foreach (T item in items)
                AddItem(item);
        }

        #endregion

        #region [Public methods]

        /// <summary>
        /// Indicates wether the container is empty
        /// </summary>
        /// <returns>Indicates wether the container is empty</returns>
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        /// <summary>
        /// Adds an item in the container
        /// </summary>
        /// <param name="item">item to be added</param>
        public void Push(T item)
        {
            this.AddItem(item);
        }

        /// <summary>
        /// Removes the top container's item
        /// </summary>
        /// <returns>Removed item</returns>
        public T Pop()
        {
            T top = this.GetFirstItem();
            this.RemoveFirstItem();

            return top;
        }

        /// <summary>
        /// Returns the top item
        /// </summary>
        /// <returns>Top item</returns>
        public T Top()
        {
            return this.GetFirstItem();
        }

        /// <summary>
        /// Removes all container data
        /// </summary>
        public void Clear()
        {
            this._items.Clear();
        }

        #endregion

        #region [Private methods]

        /// <summary>
        /// Adds an item in the linked list
        /// </summary>
        /// <param name="item">item to be added</param>
        private void AddItem(T item)
        {
            this._items.AddFirst(item);
        }

        /// <summary>
        /// Removes the first item in the linked list
        /// </summary>
        private void RemoveFirstItem()
        {
            this._items.RemoveFirst();
        }

        /// <summary>
        /// Gets the first item in the container
        /// </summary>
        /// <returns></returns>
        private T GetFirstItem()
        {
            return this._items.First();
        }

        #endregion
    }
}
