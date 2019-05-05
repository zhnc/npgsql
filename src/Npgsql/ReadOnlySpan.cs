using System;

namespace Npgsql
{
    public class ReadOnlySpan<T> 
    {
        private byte[] buf;
        private int offset;
        private int count;

        public ReadOnlySpan(byte[] buf, int offset, int count)
        {
            this.buf = buf;
            this.offset = offset;
            this.count = count;
        }

        public int Length { get; internal set; }

        internal void CopyTo(Span<byte> span)
        {
            throw new NotImplementedException();
        }

        public static implicit operator ReadOnlySpan<T>(T[] array)
        {
            throw new NotImplementedException();

        }
        public static implicit operator ReadOnlySpan<T>(ArraySegment<T> segment)
        {
            throw new NotImplementedException();

        }
    }
}
