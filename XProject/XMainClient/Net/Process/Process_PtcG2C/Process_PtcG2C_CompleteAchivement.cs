using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcG2C_CompleteAchivement
	{

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
