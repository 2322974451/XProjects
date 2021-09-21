using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200158D RID: 5517
	internal class Process_PtcG2C_HeroBattleAncientPower
	{
		// Token: 0x0600EB55 RID: 60245 RVA: 0x00345940 File Offset: 0x00343B40
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
