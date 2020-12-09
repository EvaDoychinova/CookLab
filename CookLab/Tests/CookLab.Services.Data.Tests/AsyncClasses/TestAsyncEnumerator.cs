namespace CookLab.Services.Data.Tests.AsyncClasses
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            this.inner = inner;
        }
        public T Current
        {
            get
            {
                return this.inner.Current;
            }
        }

        public async ValueTask DisposeAsync()
        {
            this.inner.Dispose();
        }

        public async ValueTask<bool> MoveNextAsync()
        {
            return await Task.FromResult(this.inner.MoveNext());
        }
    }
}
