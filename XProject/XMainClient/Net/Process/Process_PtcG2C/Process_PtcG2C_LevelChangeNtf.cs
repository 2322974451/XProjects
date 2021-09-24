using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_LevelChangeNtf
	{

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
