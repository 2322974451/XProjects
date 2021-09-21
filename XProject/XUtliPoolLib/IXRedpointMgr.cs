using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200008F RID: 143
	internal interface IXRedpointMgr : IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		// Token: 0x060004AB RID: 1195
		void AddSysRedpointUI(int sys, GameObject go, SetRedpointUIHandler callback = null);

		// Token: 0x060004AC RID: 1196
		void RemoveSysRedpointUI(int sys, GameObject go);

		// Token: 0x060004AD RID: 1197
		void RemoveAllSysRedpointsUI(int sys);

		// Token: 0x060004AE RID: 1198
		void ClearAllSysRedpointsUI();

		// Token: 0x060004AF RID: 1199
		void SetSysRedpointState(int sys, bool redpoint, bool bImmUpdateUI = true);
	}
}
