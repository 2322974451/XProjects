using System;

namespace XUtliPoolLib
{
	// Token: 0x020001C9 RID: 457
	public abstract class XSingleton<T> : XBaseSingleton where T : new()
	{
		// Token: 0x06000A82 RID: 2690 RVA: 0x000385DC File Offset: 0x000367DC
		protected XSingleton()
		{
			bool flag = XSingleton<T>._instance != null;
			if (flag)
			{
				T instance = XSingleton<T>._instance;
				throw new XDoubleNewException(instance.ToString() + " can not be created again.");
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x06000A83 RID: 2691 RVA: 0x00038628 File Offset: 0x00036828
		public static T singleton
		{
			get
			{
				return XSingleton<T>._instance;
			}
		}

		// Token: 0x06000A84 RID: 2692 RVA: 0x00038640 File Offset: 0x00036840
		public override bool Init()
		{
			return true;
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x00003284 File Offset: 0x00001484
		public override void Uninit()
		{
		}

		// Token: 0x040004FB RID: 1275
		private static readonly T _instance = Activator.CreateInstance<T>();
	}
}
