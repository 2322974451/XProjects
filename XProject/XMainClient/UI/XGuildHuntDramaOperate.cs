using System;
using System.Collections.Generic;
using UILib;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildHuntDramaOperate : XDramaOperate
	{

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

		private bool CloseUI(IXUIButton button)
		{
			bool flag = DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<DramaDlg, DramaDlgBehaviour>.singleton.SetVisible(false, true);
			}
			return true;
		}

		private XDramaOperateParam _param;
	}
}
