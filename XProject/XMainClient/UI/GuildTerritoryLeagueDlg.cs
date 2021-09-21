using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001774 RID: 6004
	internal class GuildTerritoryLeagueDlg : DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>
	{
		// Token: 0x17003821 RID: 14369
		// (get) Token: 0x0600F7DD RID: 63453 RVA: 0x00388A5C File Offset: 0x00386C5C
		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryLeagueDlg";
			}
		}

		// Token: 0x0600F7DE RID: 63454 RVA: 0x00388A74 File Offset: 0x00386C74
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			base.uiBehaviour.mWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnTerritoryLeagueHandler));
			base.uiBehaviour.mCheckBox.SetVisible(false);
			base.uiBehaviour.mCheckBox.bChecked = this._Doc.mShowMessage;
		}

		// Token: 0x0600F7DF RID: 63455 RVA: 0x00388AE4 File Offset: 0x00386CE4
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildTerrAllianceInfo();
		}

		// Token: 0x0600F7E0 RID: 63456 RVA: 0x00388AFA File Offset: 0x00386CFA
		public void RefreshData()
		{
			this.RefreshWhenShow();
		}

		// Token: 0x0600F7E1 RID: 63457 RVA: 0x00388B04 File Offset: 0x00386D04
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.mClear.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClearClick));
		}

		// Token: 0x0600F7E2 RID: 63458 RVA: 0x00388B54 File Offset: 0x00386D54
		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600F7E3 RID: 63459 RVA: 0x00388B70 File Offset: 0x00386D70
		private bool OnClearClick(IXUIButton btn)
		{
			this._Doc.SendClearGuildTerrAlliance();
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x0600F7E4 RID: 63460 RVA: 0x00388B98 File Offset: 0x00386D98
		private bool OnCheckBoxClick(IXUICheckBox checkBox)
		{
			this._Doc.mShowMessage = checkBox.bChecked;
			return true;
		}

		// Token: 0x0600F7E5 RID: 63461 RVA: 0x00388BBC File Offset: 0x00386DBC
		private void OnTerritoryLeagueHandler(Transform t, int index)
		{
			IXUILabel ixuilabel = t.FindChild("GuildName").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel2 = t.FindChild("MemberCount").GetComponent("XUILabel") as IXUILabel;
			IXUILabel ixuilabel3 = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
			IXUIButton ixuibutton = t.FindChild("OK").GetComponent("XUIButton") as IXUIButton;
			IXUILabel ixuilabel4 = t.FindChild("nb").GetComponent("XUILabel") as IXUILabel;
			GuildTerrAllianceInfo guildTerrAllianceInfo = this._Doc.guildAllianceInfos[index];
			ixuilabel.SetText(guildTerrAllianceInfo.guildname);
			ixuilabel4.SetText(string.Format("Lv:{0}", guildTerrAllianceInfo.guildlvl));
			ixuilabel2.SetText(guildTerrAllianceInfo.guildRoleNum.ToString());
			ixuilabel3.SetText(XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)guildTerrAllianceInfo.time));
			ixuibutton.ID = guildTerrAllianceInfo.guildId;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSureClick));
		}

		// Token: 0x0600F7E6 RID: 63462 RVA: 0x00388CE4 File Offset: 0x00386EE4
		private bool OnSureClick(IXUIButton btn)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.SendRecAlliance(btn.ID);
			return true;
		}

		// Token: 0x0600F7E7 RID: 63463 RVA: 0x00388D10 File Offset: 0x00386F10
		private void RefreshWhenShow()
		{
			bool flag = this._Doc.guildAllianceInfos == null;
			if (flag)
			{
				base.uiBehaviour.mWrapContent.SetContentCount(0, false);
			}
			else
			{
				base.uiBehaviour.mWrapContent.SetContentCount(this._Doc.guildAllianceInfos.Count, false);
			}
			base.uiBehaviour.mScrollView.ResetPosition();
		}

		// Token: 0x04006C17 RID: 27671
		private XGuildTerritoryDocument _Doc;
	}
}
