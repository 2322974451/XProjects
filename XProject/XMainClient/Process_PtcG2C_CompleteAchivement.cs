using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02001018 RID: 4120
	internal class Process_PtcG2C_CompleteAchivement
	{
		// Token: 0x0600D505 RID: 54533 RVA: 0x00322D4C File Offset: 0x00320F4C
		public static void Process(PtcG2C_CompleteAchivement roPtc)
		{
			XAchievementDocument specificDocument = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
			specificDocument.SetAchivementState(roPtc.Data.achivementID, roPtc.Data.state);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_Reward_Achivement, true);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_ServerActivity, true);
			XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_LevelReward, true);
		}
	}
}
