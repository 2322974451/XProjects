using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildViewView : DlgBase<XGuildViewView, XGuildViewBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildViewDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._ViewDoc = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
			this._ViewDoc.GuildViewView = this;
		}

		protected override void OnUnload()
		{
			this._ViewDoc.GuildViewView = null;
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnApply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnApplyBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentItemInit));
		}

		protected override void OnShow()
		{
			base.uiBehaviour.m_BtnApply.SetEnable(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild) && !this._GuildDoc.bInGuild, false);
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		private bool _OnApplyBtnClick(IXUIButton go)
		{
			bool bInGuild = this._GuildDoc.bInGuild;
			bool result;
			if (bInGuild)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(ErrorCode.ERR_GUILD_ALREADY_IN_GUILD, "fece00");
				result = true;
			}
			else
			{
				DlgBase<XGuildApplyView, XGuildApplyBehaviour>.singleton.ShowApply(this._ViewDoc.BasicData.uid, this._ViewDoc.BasicData.guildName, (uint)this._ViewDoc.ApproveSetting.PPT, !this._ViewDoc.ApproveSetting.autoApprove, this._ViewDoc.BasicData.announcement);
				result = true;
			}
			return result;
		}

		public void RefreshAnnouncement()
		{
			XGuildBasicData basicData = this._ViewDoc.BasicData;
			base.uiBehaviour.m_Annoucement.SetText(basicData.announcement);
		}

		public void RefreshBasicInfo()
		{
			XGuildBasicData basicData = this._ViewDoc.BasicData;
			base.uiBehaviour.m_BasicInfoDisplay.Set(basicData);
			this.RefreshAnnouncement();
		}

		public void RefreshMembers()
		{
			List<XGuildMemberBasicInfo> memberList = this._ViewDoc.MemberList;
			int count = memberList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		private void _WrapContentItemInit(Transform t, int index)
		{
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClick));
		}

		private void _WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._ViewDoc.MemberList.Count;
			if (!flag)
			{
				XGuildMemberBasicInfo data = this._ViewDoc.MemberList[index];
				IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
				this._MemberInfoDisplay.Init(t, false);
				this._MemberInfoDisplay.Set(data);
				ixuisprite.ID = (ulong)((long)index);
			}
		}

		private void _OnMemberClick(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			bool flag = num < 0 || num >= this._ViewDoc.MemberList.Count;
			if (flag)
			{
			}
		}

		private XGuildDocument _GuildDoc;

		private XGuildViewDocument _ViewDoc;

		private XGuildMemberInfoDisplay _MemberInfoDisplay = new XGuildMemberInfoDisplay();
	}
}
