using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200100F RID: 4111
	internal class Process_PtcG2C_LevelChangeNtf
	{
		// Token: 0x0600D4E4 RID: 54500 RVA: 0x00322524 File Offset: 0x00320724
		public static void Process(PtcG2C_LevelChangeNtf roPtc)
		{
			XRole player = XSingleton<XEntityMgr>.singleton.Player;
			bool flag = player == null;
			if (!flag)
			{
				uint level = player.Attributes.Level;
				XLevelUpStatusDocument specificDocument = XDocuments.GetSpecificDocument<XLevelUpStatusDocument>(XLevelUpStatusDocument.uuID);
				specificDocument.CurLevel = roPtc.Data.level;
				specificDocument.PreLevel = level;
				specificDocument.Exp = roPtc.Data.exp;
				specificDocument.MaxExp = roPtc.Data.maxexp;
				bool flag2 = specificDocument.CurLevel > level;
				if (flag2)
				{
					specificDocument.AttrID.Clear();
					specificDocument.AttrNewValue.Clear();
					specificDocument.AttrOldValue.Clear();
					for (int i = 0; i < roPtc.Data.attrid.Count; i++)
					{
						specificDocument.AttrID.Add(roPtc.Data.attrid[i]);
						specificDocument.AttrOldValue.Add(roPtc.Data.attroldvalue[i]);
						specificDocument.AttrNewValue.Add(roPtc.Data.attrnewvalue[i]);
					}
				}
				XSingleton<XDebug>.singleton.AddLog("player levelup to ", roPtc.Data.level.ToString(), null, null, null, null, XDebugColor.XDebug_None);
				specificDocument.CheckLevelUp();
			}
		}
	}
}
