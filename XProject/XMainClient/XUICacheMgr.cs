using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D1D RID: 3357
	internal class XUICacheMgr : XSingleton<XUICacheMgr>
	{
		// Token: 0x0600BB1B RID: 47899 RVA: 0x00266A70 File Offset: 0x00264C70
		public void CacheUI(XSysDefine sys, EXStage stage = EXStage.Hall)
		{
			OpenSystemTable.RowData sysData = XSingleton<XGameSysMgr>.singleton.GetSysData(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys));
			bool flag = sysData == null;
			if (!flag)
			{
				bool flag2 = sysData.Priority >= this.m_CachedPriority || this.m_CachedSys == XSysDefine.XSys_Invalid;
				if (flag2)
				{
					this.m_CachedPriority = sysData.Priority;
					this.m_CachedSys = sys;
					this.m_eStage = stage;
				}
			}
		}

		// Token: 0x0600BB1C RID: 47900 RVA: 0x00266AD4 File Offset: 0x00264CD4
		public void RemoveCachedUI(XSysDefine sys)
		{
			bool flag = this.m_CachedSys == sys;
			if (flag)
			{
				this.m_CachedSys = XSysDefine.XSys_Invalid;
			}
		}

		// Token: 0x0600BB1D RID: 47901 RVA: 0x00266AF8 File Offset: 0x00264CF8
		public override bool Init()
		{
			this.m_CachedSys = XSysDefine.XSys_Invalid;
			return true;
		}

		// Token: 0x0600BB1E RID: 47902 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		public override void Uninit()
		{
		}

		// Token: 0x0600BB1F RID: 47903 RVA: 0x00266B14 File Offset: 0x00264D14
		public void TryShowCache()
		{
			bool flag = this.m_CachedSys == XSysDefine.XSys_Invalid;
			if (!flag)
			{
				bool flag2 = XSingleton<XGame>.singleton.CurrentStage.Stage != this.m_eStage;
				if (!flag2)
				{
					XSingleton<XGameSysMgr>.singleton.OpenSystem(this.m_CachedSys, 0UL);
					this.m_CachedSys = XSysDefine.XSys_Invalid;
				}
			}
		}

		// Token: 0x04004B75 RID: 19317
		private XSysDefine m_CachedSys;

		// Token: 0x04004B76 RID: 19318
		private int m_CachedPriority;

		// Token: 0x04004B77 RID: 19319
		private EXStage m_eStage;
	}
}
