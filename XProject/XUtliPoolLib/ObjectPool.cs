

using System.Collections.Generic;
using UnityEngine.Events;

namespace XUtliPoolLib
{
    public class ObjectPool<T> : IObjectPool
    {
        private readonly Stack<T> m_Stack = new Stack<T>();
        private readonly UnityAction<T> m_ActionOnGet;
        private readonly UnityAction<T> m_ActionOnRelease;
        private ObjectPool<T>.CreateObj m_objCreator = (ObjectPool<T>.CreateObj)null;

        public int countAll { get; private set; }

        public int countActive => this.countAll - this.countInactive;

        public int countInactive => this.m_Stack.Count;

        public ObjectPool(
          ObjectPool<T>.CreateObj creator,
          UnityAction<T> actionOnGet,
          UnityAction<T> actionOnRelease)
        {
            this.m_objCreator = creator;
            this.m_ActionOnGet = actionOnGet;
            this.m_ActionOnRelease = actionOnRelease;
            ObjectPoolCache.s_AllPool.Add((IObjectPool)this);
        }

        public T Get()
        {
            T obj;
            if (this.m_Stack.Count == 0)
            {
                obj = this.m_objCreator();
                ++this.countAll;
            }
            else
                obj = this.m_Stack.Pop();
            if (this.m_ActionOnGet != null)
                this.m_ActionOnGet(obj);
            return obj;
        }

        public void Release(T element)
        {
            if ((object)element == null)
                return;
            if (this.m_ActionOnRelease != null)
                this.m_ActionOnRelease(element);
            this.m_Stack.Push(element);
        }

        public delegate T CreateObj();
    }
}
