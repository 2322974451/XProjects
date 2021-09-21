using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018B0 RID: 6320
	internal class XGuildViewView : DlgBase<XGuildViewView, XGuildViewBehaviour>
	{
		// Token: 0x17003A26 RID: 14886
		// (get) Token: 0x06010781 RID: 67457 RVA: 0x0040826C File Offset: 0x0040646C
		public override string fileName
		{
			get
			{
				return "Guild/GuildViewDlg";
			}
		}

		// Token: 0x17003A27 RID: 14887
		// (get) Token: 0x06010782 RID: 67458 RVA: 0x00408284 File Offset: 0x00406484
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A28 RID: 14888
		// (get) Token: 0x06010783 RID: 67459 RVA: 0x00408298 File Offset: 0x00406498
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003A29 RID: 14889
		// (get) Token: 0x06010784 RID: 67460 RVA: 0x004082AC File Offset: 0x004064AC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A2A RID: 14890
		// (get) Token: 0x06010785 RID: 67461 RVA: 0x004082C0 File Offset: 0x004064C0
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A2B RID: 14891
		// (get) Token: 0x06010786 RID: 67462 RVA: 0x004082D4 File Offset: 0x004064D4
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003A2C RID: 14892
		// (get) Token: 0x06010787 RID: 67463 RVA: 0x004082E8 File Offset: 0x004064E8
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010788 RID: 67464 RVA: 0x004082FB File Offset: 0x004064FB
		protected override void Init()
		{
			this._GuildDoc = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this._ViewDoc = XDocuments.GetSpecificDocument<XGuildViewDocument>(XGuildViewDocument.uuID);
			this._ViewDoc.GuildViewView = this;
		}

		// Token: 0x06010789 RID: 67465 RVA: 0x0040832B File Offset: 0x0040652B
		protected override void OnUnload()
		{
			this._ViewDoc.GuildViewView = null;
		}

		// Token: 0x0601078A RID: 67466 RVA: 0x0040833C File Offset: 0x0040653C
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnApply.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnApplyBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this._WrapContentItemUpdated));
			base.uiBehaviour.m_WrapContent.RegisterItemInitEventHandler(new WrapItemInitEventHandler(this._WrapContentItemInit));
		}

		// Token: 0x0601078B RID: 67467 RVA: 0x004083BE File Offset: 0x004065BE
		protected override void OnShow()
		{
			base.uiBehaviour.m_BtnApply.SetEnable(XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_Guild) && !this._GuildDoc.bInGuild, false);
		}

		// Token: 0x0601078C RID: 67468 RVA: 0x004083F4 File Offset: 0x004065F4
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0601078D RID: 67469 RVA: 0x00408410 File Offset: 0x00406610
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

		// Token: 0x0601078E RID: 67470 RVA: 0x004084A8 File Offset: 0x004066A8
		public void RefreshAnnouncement()
		{
			XGuildBasicData basicData = this._ViewDoc.BasicData;
			base.uiBehaviour.m_Annoucement.SetText(basicData.announcement);
		}

		// Token: 0x0601078F RID: 67471 RVA: 0x004084DC File Offset: 0x004066DC
		public void RefreshBasicInfo()
		{
			XGuildBasicData basicData = this._ViewDoc.BasicData;
			base.uiBehaviour.m_BasicInfoDisplay.Set(basicData);
			this.RefreshAnnouncement();
		}

		// Token: 0x06010790 RID: 67472 RVA: 0x00408510 File Offset: 0x00406710
		public void RefreshMembers()
		{
			List<XGuildMemberBasicInfo> memberList = this._ViewDoc.MemberList;
			int count = memberList.Count;
			base.uiBehaviour.m_WrapContent.SetContentCount(count, false);
			base.uiBehaviour.m_ScrollView.ResetPosition();
		}

		// Token: 0x06010791 RID: 67473 RVA: 0x00408558 File Offset: 0x00406758
		private void _WrapContentItemInit(Transform t, int index)
		{
			IXUISprite ixuisprite = t.GetComponent("XUISprite") as IXUISprite;
			ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this._OnMemberClick));
		}

		// Token: 0x06010792 RID: 67474 RVA: 0x0040858C File Offset: 0x0040678C
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

		// Token: 0x06010793 RID: 67475 RVA: 0x00408604 File Offset: 0x00406804
		private void _OnMemberClick(IXUISprite iSp)
		{
			int num = (int)iSp.ID;
			bool flag = num < 0 || num >= this._ViewDoc.MemberList.Count;
			if (flag)
			{
			}
		}

		// Token: 0x0400770C RID: 30476
		private XGuildDocument _GuildDoc;

		// Token: 0x0400770D RID: 30477
		private XGuildViewDocument _ViewDoc;

		// Token: 0x0400770E RID: 30478
		private XGuildMemberInfoDisplay _MemberInfoDisplay = new XGuildMemberInfoDisplay();
	}
}
