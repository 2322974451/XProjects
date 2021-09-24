using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_SceneStateNtf
	{

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
