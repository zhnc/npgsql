using System;
using System.Collections.Generic;


//#nullable enable
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using System.Runtime.Versioning;

#pragma warning disable 0809  //warning CS0809: Obsolete member 'Span<T>.Equals(object)' overrides non-obsolete member 'object.Equals(object)'


namespace Npgsql
{
    /// <summary>
    /// Span represents a contiguous region of arbitrary memory. Unlike arrays, it can point to either managed
    /// or native memory, or to memory allocated on the stack. It is type- and memory-safe.
    /// </summary>
    //[DebuggerTypeProxy(typeof(SpanDebugView<>))]
    [DebuggerDisplay("{ToString(),raw}")]
    public readonly ref partial struct Span<T>
    {
        private readonly int _length;
        private readonly T[] array;
        private readonly int count;

        public Span(T[] array, int offset) : this()
        {
            this.array = array;
        }

        public Span(T[] array) : this()
        {
            this.array = array;
        }

        public Span(T[] array, int offset, int count) : this(array, offset)
        {
            this.count = count;
        }

        /// <summary>
        /// The number of items in the span.
        /// </summary>
        public int Length
        {
            //[NonVersionable]
            get
            {
                return _length;
            }
        }

        /// <summary>
        /// Returns true if Length is 0.
        /// </summary>
        public bool IsEmpty
        {
            //[NonVersionable]
            get
            {
                // Workaround for https://github.com/dotnet/coreclr/issues/19620
                return 0 >= (uint)_length;
            }
        }

        /// <summary>
        /// Returns false if left and right point at the same memory and have the same length.  Note that
        /// this does *not* check to see if the *contents* are equal.
        /// </summary>
        public static bool operator !=(Span<T> left, Span<T> right) => !(left == right);
        public static bool operator ==(Span<T> left, Span<T> right)
        {
            throw new NotSupportedException();

        }

        /// <summary>
        /// This method is not supported as spans cannot be boxed. To compare two spans, use operator==.
        /// <exception cref="System.NotSupportedException">
        /// Always thrown by this method.
        /// </exception>
        /// </summary>
        [Obsolete("Equals() on Span will always throw an exception. Use == instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            throw new NotSupportedException("SR.NotSupported_CannotCallEqualsOnSpan");
        }

        /// <summary>
        /// This method is not supported as spans cannot be boxed.
        /// <exception cref="System.NotSupportedException">
        /// Always thrown by this method.
        /// </exception>
        /// </summary>
        [Obsolete("GetHashCode() on Span will always throw an exception.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            throw new NotSupportedException("SR.NotSupported_CannotCallGetHashCodeOnSpan");
        }

        /// <summary>
        /// Defines an implicit conversion of an array to a <see cref="Span{T}"/>
        /// </summary>
        public static implicit operator Span<T>(T[] array) => new Span<T>(array);

        /// <summary>
        /// Defines an implicit conversion of a <see cref="ArraySegment{T}"/> to a <see cref="Span{T}"/>
        /// </summary>
        public static implicit operator Span<T>(ArraySegment<T> segment)
            => new Span<T>(segment.Array, segment.Offset, segment.Count);

        /// <summary>
        /// Returns an empty <see cref="Span{T}"/>
        /// </summary>
        public static Span<T> Empty => default;

        /// <summary>Gets an enumerator for this span.</summary>
        public Enumerator GetEnumerator() => new Enumerator(this);

        public ref T this[int index] { get
            {
                return ref array[index];
            }
        }

        /// <summary>Enumerates the elements of a <see cref="Span{T}"/>.</summary>
        public ref struct Enumerator
        {
            /// <summary>The span being enumerated.</summary>
            private readonly Span<T> _span;
            /// <summary>The next index to yield.</summary>
            private int _index;

            /// <summary>Initialize the enumerator.</summary>
            /// <param name="span">The span to enumerate.</param>
            [MethodImpl(MethodImplOptions.NoInlining)]
            internal Enumerator(Span<T> span)
            {
                _span = span;
                _index = -1;
            }

            /// <summary>Advances the enumerator to the next element of the span.</summary>
            [MethodImpl(MethodImplOptions.NoInlining)]
            public bool MoveNext()
            {
                var index = _index + 1;
                if (index < _span.Length)
                {
                    _index = index;
                    return true;
                }

                return false;
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            public ref T Current
            {
                [MethodImpl(MethodImplOptions.NoInlining)]
                get => ref _span[_index];
            }
        }
    }
}
