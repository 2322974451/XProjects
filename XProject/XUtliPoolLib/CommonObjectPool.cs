

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
