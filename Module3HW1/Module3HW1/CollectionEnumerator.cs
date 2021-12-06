using System;
using System.Collections;
using System.Collections.Generic;

namespace Module3HW1
{
    public class CollectionEnumerator<T> : IEnumerator, IEnumerator<T>
    {
        private Collection<T> _collection;
        private int _position = -1;

        public CollectionEnumerator(Collection<T> collection)
        {
            _collection = collection;
        }

        public T Current
        {
            get
            {
                if (_position == -1 || _position >= _collection.Count)
                {
                    throw new InvalidOperationException();
                }

                return _collection[_position];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                if (_position == -1 || _position >= _collection.Count)
                {
                    throw new InvalidOperationException();
                }

                return _collection[_position];
            }
        }

        public void Dispose()
        {
            _position = -1;
        }

        public bool MoveNext()
        {
            if (_position < _collection.Count - 1)
            {
                _position++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}