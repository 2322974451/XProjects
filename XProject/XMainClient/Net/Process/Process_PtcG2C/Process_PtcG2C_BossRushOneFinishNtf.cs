using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_BossRushOneFinishNtf
	{

		public static void Process(PtcG2C_BossRushOneFinishNtf roPtc)
		{
			XBossBushDocument specificDocument = XDocuments.GetSpecificDocument<XBossBushDocument>(XBossBushDocument.uuID);
			bool win = roPtc.Data.win;
			if (win)
			{
				bool flag = specificDocument.respData.currank < 5;
				if (flag)
				{
					DlgBase<BattleContinueDlg, BattleContinueDlgBehaviour>.singleton.ShowBossrushResult();
				}
			}
			else
			{
				bool flag2 = specificDocument.respData.currank <= 1;
				if (flag2)
				{
					XSingleton<XLevelFinishMgr>.singleton.ForceLevelFinish(false);
				}
			}
		}
	}
}
