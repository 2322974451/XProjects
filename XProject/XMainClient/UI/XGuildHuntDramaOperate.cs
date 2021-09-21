using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020016FE RID: 5886
	internal class XGuildHuntDramaOperate : XDramaOperate
	{
		// Token: 0x0600F2BF RID: 62143 RVA: 0x0035DEC4 File Offset: 0x0035C0C4
		public override void ShowNpc(XNpc npc)
		{
			base.ShowNpc(npc);
			this._param = XDataPool<XDramaOperateParam>.GetData();
			this._param.Npc = npc;
			this._param.Text = XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("GuildGrowthHuntText"));
			this._param.AppendButton(XStringDefineProxy.GetString("GuildGrowthHuntOK"), new ButtonClickEventHandler(this.ToDoSomething), 0UL);
			this._param.AppendButton(XStringDefineProxy.GetString("GuildGrowthHuntRefuse"), new ButtonClickEventHandler(this.CloseUI), 0UL);
			base._FireEvent(this._param);
		}

		// Token: 0x0600F2C0 RID: 62144 RVA: 0x0035DF68 File Offset: 0x0035C168
		private bool ToDoSomething(IXUIButton button)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			}
			XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
			List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(TeamLevelType.TeamLevelGuildHunt);
			XTeamDocument specificDocument2 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			bool flag2 = expeditionList.Count > 0;
			if (flag2)
			{
				specificDocument2.SetAndMatch(expeditionList[0].DNExpeditionID);
			}
			return true;
		}

		// Token: 0x0600F2C1 RID: 62145 RVA: 0x0035DFDC File Offset: 0x0035C1DC
		private bool CloseUI(IXUIButton button)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			}
			return true;
		}

		// Token: 0x0400680E RID: 26638
		private XDramaOperateParam _param;
	}
}
