using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000199 RID: 409
	public class XAnimationPool
	{
		// Token: 0x060008DC RID: 2268 RVA: 0x0002F358 File Offset: 0x0002D558
		public static XAnimationClip Create()
		{
			return ScriptableObject.CreateInstance<XAnimationClip>();
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x0002F370 File Offset: 0x0002D570
		public static XAnimationClip Get()
		{
			return XAnimationPool.s_Pool.Get();
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x0002F38C File Offset: 0x0002D58C
		public static void Release(XAnimationClip toRelease)
		{
			bool flag = toRelease != null;
			if (flag)
			{
				toRelease.Reset();
			}
			XAnimationPool.s_Pool.Release(toRelease);
		}

		// Token: 0x04000403 RID: 1027
		private static readonly ObjectPool<XAnimationClip> s_Pool = new ObjectPool<XAnimationClip>(new ObjectPool<XAnimationClip>.CreateObj(XAnimationPool.Create), null, null);
	}
}
