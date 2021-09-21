using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x02000195 RID: 405
	public class DictionaryPool<K, V>
	{
		// Token: 0x060008C8 RID: 2248 RVA: 0x0002F178 File Offset: 0x0002D378
		public static Dictionary<K, V> Create()
		{
			return new Dictionary<K, V>();
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x0002F190 File Offset: 0x0002D390
		public static Dictionary<K, V> Get()
		{
			return DictionaryPool<K, V>.s_Pool.Get();
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0002F1AC File Offset: 0x0002D3AC
		public static void Release(Dictionary<K, V> toRelease)
		{
			DictionaryPool<K, V>.s_Pool.Release(toRelease);
		}

		// Token: 0x040003FF RID: 1023
		private static readonly ObjectPool<Dictionary<K, V>> s_Pool = new ObjectPool<Dictionary<K, V>>(new ObjectPool<Dictionary<K, V>>.CreateObj(DictionaryPool<K, V>.Create), delegate(Dictionary<K, V> l)
		{
			l.Clear();
		}, delegate(Dictionary<K, V> l)
		{
			l.Clear();
		});
	}
}
