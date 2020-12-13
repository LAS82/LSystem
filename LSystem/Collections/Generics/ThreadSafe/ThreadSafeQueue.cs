using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSystem.Collections.Generics.ThreadSafe
{
    public class ThreadSafeQueue<T>
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

        private object makeItAtomic = new object();

        #endregion

        #region [Constructors]

        /// <summary>
        /// Constructor
        /// </summary>
        public ThreadSafeQueue()
        {
            this._items = new LinkedList<T>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="items">The items to initialize the container</param>
        public ThreadSafeQueue(IEnumerable<T> items) : this()
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
        public void Enqueue(T item)
        {
            lock (makeItAtomic)
            {
                this.AddItem(item);
            }
        }

        public void Enqueue(IEnumerable<T> items)
        {
            lock (makeItAtomic)
            {
                foreach(T item in items)
                    this.AddItem(item);
            }
        }

        /// <summary>
        /// Removes the front container's item
        /// </summary>
        /// <returns>Removed item</returns>
        public T Dequeue()
        {
            T front;

            lock (makeItAtomic)
            {
                if (this.IsEmpty())
                {
                    front = default(T);
                }
                else
                {
                    front = this.GetFirstItem();
                    this.RemoveFirstItem();
                }
            }

            return front;
        }

        /// <summary>
        /// Returns the front item
        /// </summary>
        /// <returns>Front item</returns>
        public T Front()
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
            this._items.AddLast(item);
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
