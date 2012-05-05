// <copyright file="LRUCache.cs" company="Michael Miceli">
// Copyright Michael Miceli.  All rights are reserved.
// </copyright>

namespace Cache
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A simple LRU implementation
    /// </summary>
    /// <typeparam name="T">The type the LRU can hold</typeparam>
    public class LRUCache<T> : ICollection<T>
    {
        /// <summary>
        /// The default capacity of the LRU cache
        /// </summary>
        private const int DefaultCapacity = 5;

        /// <summary>
        /// An internal collection that holds our LRU cache
        /// </summary>
        private LinkedList<T> cache;

        /// <summary>
        /// Initializes a new instance of <see cref="LRUCache"/> class.
        /// </summary>
        public LRUCache()
            : this(DefaultCapacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="LRUCache"/> class.
        /// </summary>
        /// <param name="capacity">The capacity of the LRU cache</param>
        public LRUCache(int capacity)
        {
            this.cache = new LinkedList<T>();
            this.Capacity = capacity;
        }

        /// <summary>
        /// Gets the capacity of the LRU cache
        /// </summary>
        public int Capacity { get; private set; }

        /// <summary>
        /// Gets the number of elements in the LRU cache
        /// </summary>
        public int Count
        {
            get { return this.cache.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether or not the list is read only
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Adds an element to the LRU cache.  If the cache is full, the oldest element is removed
        /// </summary>
        /// <param name="item">The element to add to the cache</param>
        public void Add(T item)
        {
            if (this.cache.Contains(item))
            {
                // the item is already in the list, just move to the newest
                this.cache.Remove(item);
                this.cache.AddLast(item);
            }
            else if (this.cache.Count < this.Capacity)
            {
                // the item can be added in this list as the newest element, because there is available room
                this.cache.AddLast(item);
            }
            else
            {
                // The LRU cache is at capacity and needs to remove the oldest item
                this.cache.RemoveFirst();
                this.cache.AddLast(item);
            }
        }

        /// <summary>
        /// Empties the cache
        /// </summary>
        public void Clear()
        {
            this.cache.Clear();
        }

        /// <summary>
        /// Determines whether or not the item is in the LRU cache
        /// </summary>
        /// <param name="item">The item to check for in the LRU cache</param>
        /// <returns>Whether or not the item is in the cache</returns>
        public bool Contains(T item)
        {
            return (this.cache.Contains(item));
        }

        /// <summary>
        /// Copies the elements of the LRUCache to an array, starting at index arrayIndex.
        /// </summary>
        /// <param name="array">The destination of items from the LRU cache.</param>
        /// <param name="arrayIndex">The index in array where the elements to insert start</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (T item in this)
            {
                array[arrayIndex] = item;

                // CA2233 overflow will cause an exception instead
                checked
                {
                    arrayIndex++;
                }
            }
        }

        /// <summary>
        /// Removes an element from the LRU caches
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>True if the item was successfully removed, false otherwise, e.g. the item is not in the list</returns>
        public bool Remove(T item)
        {
            return this.cache.Remove(item);
        }

        /// <summary>
        /// Gets an enumerator to traverse the LRU cache
        /// </summary>
        /// <returns>An enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.cache.GetEnumerator();
        }

        /// <summary>
        /// Gets an enumerator to traverse the LRU cache
        /// </summary>
        /// <returns>An enumerator</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.cache.GetEnumerator();
        }

        /// <summary>
        /// A convenient method for printing the LRU cache
        /// </summary>
        /// <returns>A string representation of the LRU cache</returns>
        public override string ToString()
        {
            StringBuilder retval = new StringBuilder("{ ");
            foreach (T item in this)
            {
                retval.Append(item.ToString()).Append(" ");
            }

            retval.Append("}");
            return retval.ToString();
        }
    }
}
