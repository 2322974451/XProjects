using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XUICacheMgr : XSingleton<XUICacheMgr>
	{

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

		public void RemoveCachedUI(XSysDefine sys)
		{
			bool flag = this.m_CachedSys == sys;
			if (flag)
			{
				this.m_CachedSys = XSysDefine.XSys_Invalid;
			}
		}

		public override bool Init()
		{
			this.m_CachedSys = XSysDefine.XSys_Invalid;
			return true;
		}

		public override void Uninit()
		{
		}

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

		private XSysDefine m_CachedSys;

		private int m_CachedPriority;

		private EXStage m_eStage;
	}
}
