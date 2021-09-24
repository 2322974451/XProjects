using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class SelectorPool
	{

		public static Selector Create()
		{
			return new Selector();
		}

		public static Selector Get()
		{
			return SelectorPool.selectors.Get();
		}

		public static void Release(Selector selector)
		{
			SelectorPool.selectors.Release(selector);
		}

		private static ObjectPool<Selector> selectors = new ObjectPool<Selector>(new ObjectPool<Selector>.CreateObj(SelectorPool.Create), null, null);
	}
}
