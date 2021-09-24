using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class Process_PtcM2C_ResWarEnemyTimeNtf
	{

		public static void Process(PtcM2C_ResWarEnemyTimeNtf roPtc)
		{
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
				DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.CurExploreLeftTime = 0f;
				bool flag2 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
				if (flag2)
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshExploreTime();
				}
				bool flag3 = DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.RefreshButton();
				}
				DlgBase<GuildMinePVPBeginView, GuildMinePVPBeginBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			}
		}
	}
}
