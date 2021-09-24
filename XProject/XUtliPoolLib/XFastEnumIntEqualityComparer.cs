

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace XUtliPoolLib
{
    [StructLayout(LayoutKind.Sequential, Size = 1)]
    public struct XFastEnumIntEqualityComparer<TEnum> : IEqualityComparer<TEnum> where TEnum : struct
    {
        public static int ToInt(TEnum en) => EnumInt32ToInt.Convert<TEnum>(en);

        public bool Equals(TEnum lhs, TEnum rhs) => XFastEnumIntEqualityComparer<TEnum>.ToInt(lhs) == XFastEnumIntEqualityComparer<TEnum>.ToInt(rhs);

        public int GetHashCode(TEnum en) => XFastEnumIntEqualityComparer<TEnum>.ToInt(en);
    }
    public class EnumInt32ToInt
    {
        public static int Convert<TEnum>(TEnum value) where TEnum : struct => XFastEnumIntEqualityComparer<TEnum>.ToInt(value);
    }

}
