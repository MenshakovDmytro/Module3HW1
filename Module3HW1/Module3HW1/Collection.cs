using System;
using System.Collections;
using System.Collections.Generic;

namespace Module3HW1
{
    public class Collection<T> : IEnumerable, IEnumerable<T>
    {
        private T[] _array;
        private int _count;
        private int _capacity;

        public Collection()
        {
            _array = new T[_capacity];
        }

        public Collection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _capacity = capacity;
            _array = new T[_capacity];
        }

        public int Count => _count;

        public int Capacity
        {
            get => _capacity;

            set
            {
                if (value < _count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _capacity = value;
                var array = new T[_capacity];
                Array.Copy(_array, array, _count);
                _array = array;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > _count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return _array[index];
            }

            set
            {
                if (index > _count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                _array[index] = value;
            }
        }

        public void Add(T item)
        {
            if (_count >= _capacity)
            {
                _capacity += 4;
                var array = new T[_capacity];
                Array.Copy(_array, array, _count);
                _array = array;
            }

            _array[_count] = item;
            _count++;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            var enumerator = collection.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Add(enumerator.Current);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator<T>(this);
        }

        public bool Remove(T item)
        {
            var pos = -1;
            for (var i = 0; i < _count; i++)
            {
                if (_array[i].Equals(item))
                {
                    pos = i;
                    break;
                }
            }

            if (pos == -1)
            {
                return false;
            }

            for (var i = pos + 1; i < _count; i++)
            {
                _array[i - 1] = _array[i];
            }

            _count--;
            _array[_count] = default(T);
            return true;
        }

        public void RemoveAt(int index)
        {
            if (index > _count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            for (var i = index + 1; i < _count; i++)
            {
                _array[i - 1] = _array[i];
            }

            _count--;
            _array[_count] = default(T);
        }

        public void Sort(IComparer comparer)
        {
            Array.Sort(_array, 0, _count, comparer);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CollectionEnumerator<T>(this);
        }
    }
}