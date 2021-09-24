using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_HeroBattleAncientPower
	{

		public static void Process(PtcG2C_HeroBattleAncientPower roPtc)
		{
			bool flag = XSingleton<XAttributeMgr>.singleton.XPlayerData == null;
			if (!flag)
			{
				ulong roleID = XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
				XHeroBattleDocument specificDocument = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
				for (int i = 0; i < roPtc.Data.roleids.Count; i++)
				{
					bool flag2 = roPtc.Data.roleids[i] == roleID;
					if (flag2)
					{
						specificDocument.OnAncientPercentGet((float)roPtc.Data.ancientpower[i]);
						break;
					}
				}
			}
		}
	}
}
