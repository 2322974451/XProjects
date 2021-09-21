// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.XFastEnumIntEqualityComparer`1
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

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
