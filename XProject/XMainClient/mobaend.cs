using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class mobaend
	{

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

		private static void Start()
		{
			float interval = float.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("MobaEndShowUITime"));
			mobaend._token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(mobaend.ShowResult), null);
		}

		private static void ShowResult(object o = null)
		{
			DlgBase<MobaEndDlg, MobaBehaviour>.singleton.SetVisible(true, true);
			XLevelRewardDocument specificDocument = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			DlgBase<MobaEndDlg, MobaBehaviour>.singleton.SetPic(specificDocument.MobaData.Result == HeroBattleOver.HeroBattleOver_Win);
		}

		private static void End()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(mobaend._token);
			DlgBase<MobaEndDlg, MobaBehaviour>.singleton.SetVisible(false, true);
			DlgBase<XLevelRewardView, XLevelRewardBehaviour>.singleton.CutSceneShowEnd();
		}

		private static uint _token = 0U;

		private static bool _started = false;
	}
}
