using System;
using XMainClient.UI;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02001458 RID: 5208
	internal class Process_PtcG2C_QueryRoleStateAck
	{
		// Token: 0x0600E669 RID: 58985 RVA: 0x0033E698 File Offset: 0x0033C898
		public static void Process(PtcG2C_QueryRoleStateAck roPtc)
		{
			bool flag = DlgBase<BattleMain, BattleMainBehaviour>.singleton.IsVisible() && DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor != null;
			if (flag)
			{
				DlgBase<BattleMain, BattleMainBehaviour>.singleton.TeamMonitor.OnQueryRoleStates(roPtc.Data);
			}
			bool flag2 = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				XSpectateTeamMonitorHandler spectateTeamMonitor = DlgBase<SpectateSceneView, SpectateSceneBehaviour>.singleton.SpectateTeamMonitor;
				bool flag3 = spectateTeamMonitor != null;
				if (flag3)
				{
					bool flag4 = spectateTeamMonitor.m_TeamMonitor_Left.IsVisible();
					if (flag4)
					{
						spectateTeamMonitor.m_TeamMonitor_Left.OnQueryRoleStates(roPtc.Data);
					}
					bool flag5 = spectateTeamMonitor.m_TeamMonitor_Right.IsVisible();
					if (flag5)
					{
						spectateTeamMonitor.m_TeamMonitor_Right.OnQueryRoleStates(roPtc.Data);
					}
				}
			}
		}
	}
}
