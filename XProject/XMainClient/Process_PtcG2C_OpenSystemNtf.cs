using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001014 RID: 4116
	internal class Process_PtcG2C_OpenSystemNtf
	{
		// Token: 0x0600D4F7 RID: 54519 RVA: 0x003229D8 File Offset: 0x00320BD8
		public static void Process(PtcG2C_OpenSystemNtf roPtc)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			bool flag = xplayerData == null;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("XPlayerData == null", null, null, null, null, null);
			}
			else
			{
				int i = 0;
				int count = roPtc.Data.sysIDs.Count;
				while (i < count)
				{
					xplayerData.CacheOpenSystem(roPtc.Data.sysIDs[i]);
					i++;
				}
				i = 0;
				count = roPtc.Data.closeSysIDs.Count;
				while (i < count)
				{
					xplayerData.CloseSystem(roPtc.Data.closeSysIDs[i]);
					i++;
				}
				XOperatingActivityDocument.Doc.OnSystemChanged(roPtc.Data.sysIDs, roPtc.Data.closeSysIDs);
				XActivityDocument.Doc.OnSystemChanged(roPtc.Data.sysIDs, roPtc.Data.closeSysIDs);
				WeekEndNestDocument.Doc.OnSystemChanged(roPtc.Data.sysIDs, roPtc.Data.closeSysIDs);
				XThemeActivityDocument specificDocument = XDocuments.GetSpecificDocument<XThemeActivityDocument>(XThemeActivityDocument.uuID);
				specificDocument.OnSystemChanged(roPtc.Data.sysIDs, roPtc.Data.closeSysIDs);
				XFPStrengthenDocument specificDocument2 = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
				specificDocument2.SetNew(roPtc.Data.sysIDs);
				XWelfareDocument.Doc.SetBackFlowOpenSystem(roPtc.Data.sysIDs, roPtc.Data.closeSysIDs);
			}
		}
	}
}
