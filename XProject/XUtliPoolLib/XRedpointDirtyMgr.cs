using System;
using System.Collections.Generic;

namespace XUtliPoolLib
{
	// Token: 0x020001B4 RID: 436
	public abstract class XRedpointDirtyMgr
	{
		// Token: 0x060009C9 RID: 2505
		public abstract void RecalculateRedPointSelfState(int sys, bool bImmUpdateUI = true);

		// Token: 0x060009CA RID: 2506
		public abstract void RefreshAllSysRedpoints();

		// Token: 0x060009CB RID: 2507
		protected abstract void _RefreshSysRedpointUI(int sys, bool redpoint);

		// Token: 0x060009CC RID: 2508 RVA: 0x00033448 File Offset: 0x00031648
		protected bool _GetSysRedpointState(int sys)
		{
			bool result = false;
			this.mSysRedpointStateDic.TryGetValue(sys, out result);
			return result;
		}

		// Token: 0x040004A7 RID: 1191
		protected HashSet<int> mDirtySysList = new HashSet<int>();

		// Token: 0x040004A8 RID: 1192
		protected Dictionary<int, bool> mSysRedpointStateDic = new Dictionary<int, bool>();
	}
}
