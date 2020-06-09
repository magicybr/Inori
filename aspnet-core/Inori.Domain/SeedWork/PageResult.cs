using System.Collections;
using System.Collections.Generic;

namespace Inori.Domain.SeedWork
{
    public sealed class PageResult<T> : ICollection<T>
    {
        private PageResult()
        {

        }

        public PageResult(int? totalRecords, int? totalPages, int? pageSize, int? pageNumber, IList<T> data)
        {
            this._totalRecords = totalPages;
            this._totalPages = totalPages;
            this._pageSize = pageSize;
            this._pageNumber = pageNumber;
            this._data = data;
        }
        private int? _totalRecords;
        public int? TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }

        private int? _totalPages;
        public int? TotalPage
        {
            get { return _totalPages; }
            set { _totalPages = value; }
        }

        private int? _pageSize;
        public int? PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        private int? _pageNumber;
        public int? PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        private IList<T> _data;
        public IList<T> Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public int Count => this._data.Count;

        public bool IsReadOnly => false;
        public void Add(T item) => this._data.Add(item);

        public void Clear() => this._data.Clear();

        public bool Contains(T item) => this._data.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            this._data.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item) => this._data.Remove(item);

        public IEnumerator<T> GetEnumerator() => this._data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this._data.GetEnumerator();
    }
}