using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000987 RID: 2439
	public abstract class XStaticDataBase<T> : XSingleton<T> where T : new()
	{
		// Token: 0x060092A4 RID: 37540 RVA: 0x001538CC File Offset: 0x00151ACC
		public override bool Init()
		{
			bool bLoaded = this.m_bLoaded;
			bool result;
			if (bLoaded)
			{
				result = false;
			}
			else
			{
				this.OnInit();
				result = true;
			}
			return result;
		}

		// Token: 0x060092A5 RID: 37541 RVA: 0x001538F4 File Offset: 0x00151AF4
		public override void Uninit()
		{
			this.m_bLoaded = false;
		}

		// Token: 0x060092A6 RID: 37542
		protected abstract void OnInit();

		// Token: 0x04003128 RID: 12584
		protected bool m_bLoaded;
	}
}
