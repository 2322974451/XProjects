using System;

namespace XUtliPoolLib
{
	// Token: 0x0200008B RID: 139
	internal interface IXRedpointDirtyMgr
	{
		// Token: 0x0600049B RID: 1179
		void RecalculateRedPointState(int sys, bool bImmUpdateUI = true);
	}
}
