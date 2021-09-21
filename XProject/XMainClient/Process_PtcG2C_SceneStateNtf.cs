using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001455 RID: 5205
	internal class Process_PtcG2C_SceneStateNtf
	{
		// Token: 0x0600E65D RID: 58973 RVA: 0x0033E59C File Offset: 0x0033C79C
		public static void Process(PtcG2C_SceneStateNtf roPtc)
		{
			XSingleton<XScene>.singleton.SceneStarted = roPtc.Data.state.isready;
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.UpdateSpecialStateFromServer(roPtc.Data.rolespecialstate, uint.MaxValue);
			}
		}
	}
}
