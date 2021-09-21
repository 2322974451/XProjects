using System;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x0200144B RID: 5195
	internal class Process_PtcM2C_ResWarEnemyTimeNtf
	{
		// Token: 0x0600E636 RID: 58934 RVA: 0x0033E1D4 File Offset: 0x0033C3D4
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
