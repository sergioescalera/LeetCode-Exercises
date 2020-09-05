using System;
using System.Collections.Generic;

namespace LeetCode.Data
{
    public class BinarySearchTreeNode<T>
    {
        protected readonly IComparer<T> _comparer;

        public BinarySearchTreeNode<T> Left
        {
            get; protected set;
        }

        public BinarySearchTreeNode<T> Right
        {
            get; protected set;
        }

        public T Value
        {
            get; private set;
        }

        public BinarySearchTreeNode(T value, IComparer<T> comparer = null)
        {
            EnsureNotNull(value);

            Value = value;

            _comparer = comparer ?? Comparer<T>.Default;
        }

        private void EnsureNotNull(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
        }

        public virtual void Insert(T value)
        {
            EnsureNotNull(value);

            if (_comparer.Compare(value, Value) <= 0)
            {
                if (Left == null)
                {
                    Left = new BinarySearchTreeNode<T>(value, _comparer);
                }
                else
                {
                    Left.Insert(value);
                }
            }

            else
            {
                if (Right == null)
                {
                    Right = new BinarySearchTreeNode<T>(value, _comparer);
                }
                else
                {
                    Right.Insert(value);
                }
            }
        }

        public virtual Boolean Find(T value)
        {
            this.EnsureNotNull(value);

            var compare = _comparer.Compare(value, Value);

            if (compare == 0)
            {
                return true;
            }

            if (compare < 0)
            {
                return Left != null && Left.Find(value);
            }
            else
            {
                return Right != null && Right.Find(value);
            }
        }
    }
}
