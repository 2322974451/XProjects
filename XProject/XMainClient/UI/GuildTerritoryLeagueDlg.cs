using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class GuildTerritoryLeagueDlg : DlgBase<GuildTerritoryLeagueDlg, GuildTerritoryLeagueBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildTerritory/GuildTerritoryLeagueDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			base.uiBehaviour.mWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnTerritoryLeagueHandler));
			base.uiBehaviour.mCheckBox.SetVisible(false);
			base.uiBehaviour.mCheckBox.bChecked = this._Doc.mShowMessage;
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendGuildTerrAllianceInfo();
		}

		public void RefreshData()
		{
			this.RefreshWhenShow();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.mClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClick));
			base.uiBehaviour.mClear.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClearClick));
		}

		private bool OnCloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool OnClearClick(IXUIButton btn)
		{
			this._Doc.SendClearGuildTerrAlliance();
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		private bool OnCheckBoxClick(IXUICheckBox checkBox)
		{
			this._Doc.mShowMessage = checkBox.bChecked;
			return true;
		}

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

		private bool OnSureClick(IXUIButton btn)
		{
			XGuildTerritoryDocument specificDocument = XDocuments.GetSpecificDocument<XGuildTerritoryDocument>(XGuildTerritoryDocument.uuID);
			specificDocument.SendRecAlliance(btn.ID);
			return true;
		}

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

		private XGuildTerritoryDocument _Doc;
	}
}
