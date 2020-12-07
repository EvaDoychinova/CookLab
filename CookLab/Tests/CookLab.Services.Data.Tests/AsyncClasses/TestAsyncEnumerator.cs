namespace CookLab.Services.Data.Tests.AsyncClasses
{
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

        public async Task DisposeAsync()
        {
            this.inner.Dispose();
        }

        public T Current
        {
            get
            {
                return this.inner.Current;
            }
        }

        public async Task<bool> MoveNextAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.inner.MoveNext());
        }
    }
}