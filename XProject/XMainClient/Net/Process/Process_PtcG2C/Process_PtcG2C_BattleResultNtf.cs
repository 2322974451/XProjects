using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_BattleResultNtf
	{

		public static void Process(PtcG2C_BattleResultNtf roPtc)
		{
			bool flag = roPtc.Data == null || roPtc.Data.stageInfo == null;
			if (!flag)
			{
				XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
				bool flag2 = !specificDocument.RequestServer && !XSingleton<XGame>.singleton.SyncMode;
				if (!flag2)
				{
					bool haveBattleResultData = XSingleton<XLevelFinishMgr>.singleton.HaveBattleResultData;
					if (!haveBattleResultData)
					{
						bool flag3 = specificDocument.CurrentScene != roPtc.Data.stageInfo.stageID;
						if (!flag3)
						{
							XSingleton<XLevelFinishMgr>.singleton.HaveBattleResultData = true;
							specificDocument.RequestServer = false;
							XSingleton<XCutScene>.singleton.Stop(true);
							bool isStageFailed = roPtc.Data.stageInfo.isStageFailed;
							if (isStageFailed)
							{
								XSingleton<XLevelFinishMgr>.singleton.OnLevelFailed();
							}
							else
							{
								bool flag4 = !XSingleton<XScene>.singleton.bSpectator;
								if (flag4)
								{
									specificDocument.SetBattleResultData(roPtc.Data);
								}
								XSingleton<XLevelFinishMgr>.singleton.IsCurrentLevelWin = true;
								XSingleton<XLevelFinishMgr>.singleton.StartLevelFinish();
							}
							XSingleton<XOperationRecord>.singleton.DoScriptRecord(roPtc.Data.stageInfo.stageID + "after");
							XStaticSecurityStatistics.OnEnd();
						}
					}
				}
			}
		}
	}
}
