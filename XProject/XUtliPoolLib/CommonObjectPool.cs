// Decompiled with JetBrains decompiler
// Type: XUtliPoolLib.CommonObjectPool`1
// Assembly: XUtliPoolLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D0B5E37-6957-4C11-AC8A-5F5BE652A435
// Assembly location: F:\龙之谷\Client\Assets\Lib\XUtliPoolLib.dll

using UnityEngine.Events;

namespace XUtliPoolLib
{
    public class CommonObjectPool<T> where T : new()
    {
        private static readonly ObjectPool<object> s_Pool = new ObjectPool<object>(new ObjectPool<object>.CreateObj(CommonObjectPool<T>.Create), (UnityAction<object>)null, (UnityAction<object>)null);

        public static object Create() => (object)new T();

        public static T Get() => (T)CommonObjectPool<T>.s_Pool.Get();

        public static void Release(T toRelease) => CommonObjectPool<T>.s_Pool.Release((object)toRelease);
    }
}
