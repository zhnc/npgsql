using System;

namespace Npgsql
{
    internal class Unsafe
    {
        internal static T2 As<T1, T2>(ref T1 result)
        {
            throw new NotImplementedException();
        }

        internal static int SizeOf<T>()
        {
            throw new NotImplementedException();
        }

        internal static T ReadUnaligned<T>(ref byte v)
        {
            throw new NotImplementedException();
        }

        //
        // Summary:
        //     Writes a value of type T to the given location without assuming architecture
        //     dependent alignment of the addresses.
        //
        // Parameters:
        //   destination:
        //     The location to write to.
        //
        //   value:
        //     The value to write.
        //
        // Type parameters:
        //   T:
        //     The type of value to write.
        public static void WriteUnaligned<T>(ref byte destination, T value)
        {
            throw new NotImplementedException();
        }

    }
}
