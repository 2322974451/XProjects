using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000B80 RID: 2944
	internal class mobaend
	{
		// Token: 0x0600A95F RID: 43359 RVA: 0x001E261C File Offset: 0x001E081C
		public static bool Do(List<XActor> actors)
		{
			bool flag = !mobaend._started;
			if (flag)
			{
				mobaend._started = true;
				mobaend.Start();
			}
			else
			{
				bool flag2 = !XSingleton<XCutScene>.singleton.IsPlaying;
				if (flag2)
				{
					mobaend._started = false;
					mobaend.End();
				}
			}
			return true;
		}

		// Token: 0x0600A960 RID: 43360 RVA: 0x001E266C File Offset: 0x001E086C
		private static void Start()
		{
			float interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MobaEndShowUITime"));
			mobaend._token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(mobaend.ShowResult), null);
		}

		// Token: 0x0600A961 RID: 43361 RVA: 0x001E26AC File Offset: 0x001E08AC
		private static void ShowResult(object o = null)
		{
			DlgBase<MobaEndDlg, MobaBehaviour>.singleton.SetVisible(true, true);
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			DlgBase<MobaEndDlg, MobaBehaviour>.singleton.SetPic(specificDocument.MobaData.Result == HeroBattleOver.HeroBattleOver_Win);
		}

		// Token: 0x0600A962 RID: 43362 RVA: 0x001E26EB File Offset: 0x001E08EB
		private static void End()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(mobaend._token);
			DlgBase<MobaEndDlg, MobaBehaviour>.singleton.SetVisible(false, true);
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.CutSceneShowEnd();
		}

		// Token: 0x04003EA1 RID: 16033
		private static uint _token = 0U;

		// Token: 0x04003EA2 RID: 16034
		private static bool _started = false;
	}
}
