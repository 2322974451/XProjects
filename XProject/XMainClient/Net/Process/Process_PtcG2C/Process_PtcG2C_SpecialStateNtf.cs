using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SpecialStateNtf
	{

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
