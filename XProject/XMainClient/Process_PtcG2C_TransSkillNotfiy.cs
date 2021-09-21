using System;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200153C RID: 5436
	internal class Process_PtcG2C_TransSkillNotfiy
	{
		// Token: 0x0600EA08 RID: 59912 RVA: 0x003438F8 File Offset: 0x00341AF8
		public static void Process(PtcG2C_TransSkillNotfiy roPtc)
		{
			bool flag = XSingleton<XEntityMgr>.singleton.Player == null || XSingleton<XEntityMgr>.singleton.Player.SkillMgr == null;
			if (!flag)
			{
				XBattleSkillDocument specificDocument = XDocuments.GetSpecificDocument<XBattleSkillDocument>(XBattleSkillDocument.uuID);
				for (int i = 0; i < roPtc.Data.skillhash.Count; i++)
				{
					bool flag2 = roPtc.Data.skilllevel[i] == 0U;
					if (!flag2)
					{
						specificDocument.SetSkillLevel(roPtc.Data.skillhash[i], roPtc.Data.skilllevel[i]);
						XSkillCore skill = XSingleton<XEntityMgr>.singleton.Player.SkillMgr.GetSkill(roPtc.Data.skillhash[i]);
						bool flag3 = skill != null;
						if (flag3)
						{
							skill.InitCoreData(false);
						}
					}
				}
				bool flag4 = XSingleton<XScene>.singleton.SceneType == SceneType.SCENE_MOBA && DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler != null;
				if (flag4)
				{
					DlgBase<BattleMain, BattleMainBehaviour>.singleton.SkillHandler.DelayRefreshAddBtn();
				}
			}
		}
	}
}
