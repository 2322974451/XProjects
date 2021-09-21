using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001449 RID: 5193
	internal class Process_PtcG2C_SpecialStateNtf
	{
		// Token: 0x0600E62F RID: 58927 RVA: 0x0033E0E4 File Offset: 0x0033C2E4
		public static void Process(PtcG2C_SpecialStateNtf roPtc)
		{
			XSingleton<XDebug>.singleton.AddLog(roPtc.Data.uid.ToString(), " got specialStateNtf state ", roPtc.Data.state.ToString(), " mask ", roPtc.Data.effectmask.ToString(), null, XDebugColor.XDebug_None);
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.uid);
			bool flag = entity != null;
			if (flag)
			{
				entity.UpdateSpecialStateFromServer(roPtc.Data.state, roPtc.Data.effectmask);
			}
		}
	}
}
