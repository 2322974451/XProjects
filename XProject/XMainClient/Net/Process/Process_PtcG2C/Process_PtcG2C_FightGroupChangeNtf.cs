using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_FightGroupChangeNtf
	{

		public static void Process(PtcG2C_FightGroupChangeNtf roPtc)
		{
			XEntity entity = XSingleton<XEntityMgr>.singleton.GetEntity(roPtc.Data.uid);
			bool flag = entity != null;
			if (flag)
			{
				entity.Attributes.OnFightGroupChange(roPtc.Data.fightgroup);
			}
		}
	}
}
