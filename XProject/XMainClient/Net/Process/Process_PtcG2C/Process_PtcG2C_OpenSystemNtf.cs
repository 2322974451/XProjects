using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_OpenSystemNtf
	{

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
