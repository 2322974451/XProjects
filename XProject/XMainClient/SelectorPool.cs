using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BDC RID: 3036
	internal class SelectorPool
	{
		// Token: 0x0600AD25 RID: 44325 RVA: 0x00201064 File Offset: 0x001FF264
		public static Selector Create()
		{
			return new Selector();
		}

		// Token: 0x0600AD26 RID: 44326 RVA: 0x0020107C File Offset: 0x001FF27C
		public static Selector Get()
		{
			return SelectorPool.selectors.Get();
		}

		// Token: 0x0600AD27 RID: 44327 RVA: 0x00201098 File Offset: 0x001FF298
		public static void Release(Selector selector)
		{
			SelectorPool.selectors.Release(selector);
		}

		// Token: 0x04004135 RID: 16693
		private static ObjectPool<Selector> selectors = new ObjectPool<Selector>(new ObjectPool<Selector>.CreateObj(SelectorPool.Create), null, null);
	}
}
