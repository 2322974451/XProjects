using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A34 RID: 2612
	internal class RecruitMemberHandler : RecruitListHandler
	{
		// Token: 0x06009F24 RID: 40740 RVA: 0x001A554D File Offset: 0x001A374D
		public override void OnReSelect()
		{
			this._doc.SendGroupChatFindRoleInfoList(this.m_titleBar.filter);
		}

		// Token: 0x06009F25 RID: 40741 RVA: 0x001A5568 File Offset: 0x001A3768
		protected override List<GroupMember> GetMemberList()
		{
			return this._doc.RecruitMember;
		}

		// Token: 0x06009F26 RID: 40742 RVA: 0x001A5588 File Offset: 0x001A3788
		protected override void Init()
		{
			base.Init();
			this.m_btnMember = (base.transform.Find("Info/Btn_Member").GetComponent("XUIButton") as IXUIButton);
			this.m_BubbleTips = (base.transform.Find("Info/Message/Btn_Member_LivenessTips").GetComponent("XUILabel") as IXUILabel);
			this.m_BubbleTips.SetText(XStringDefineProxy.GetString("GroupRecruit_MemberBubble"));
			this.m_btnMember.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnMemberClick));
			this._SelectGroupHandler = DlgHandlerBase.EnsureCreate<RecruitSelectGroupHandler>(ref this._SelectGroupHandler, base.transform.Find("SelectGroup").gameObject, null, false);
			this._SelectGroupHandler.Setup(new RecruitSelectGroupUpdate(this.OnSelectGroupHandle));
		}

		// Token: 0x06009F27 RID: 40743 RVA: 0x001A5658 File Offset: 0x001A3858
		protected override void OnHide()
		{
			bool flag = this._SelectGroupHandler != null && this._SelectGroupHandler.IsVisible();
			if (flag)
			{
				this._SelectGroupHandler.SetVisible(false);
			}
			base.OnHide();
		}

		// Token: 0x06009F28 RID: 40744 RVA: 0x001A5694 File Offset: 0x001A3894
		public override void RefreshData()
		{
			bool flag = this._doc.RecruitMember != null;
			if (flag)
			{
				GroupMember.dir = this.m_titleBar.direction;
				GroupMember.sortSeletor = this.m_titleBar.selector;
				this._doc.RecruitMember.Sort();
			}
			base.RefreshData();
		}

		// Token: 0x06009F29 RID: 40745 RVA: 0x001A56F0 File Offset: 0x001A38F0
		protected override void SetupOtherInfo(Transform t, GroupMember member)
		{
			base.SetupOtherInfo(t, member);
			IXUIButton ixuibutton = t.Find("BtnRecruit").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.SetVisible(false);
			ixuibutton.ID = member.issueIndex;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRecruitClick));
			ixuibutton.SetVisible(member.userID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
		}

		// Token: 0x06009F2A RID: 40746 RVA: 0x001A576C File Offset: 0x001A396C
		private bool OnRecruitClick(IXUIButton btn)
		{
			this._SelectIssueIndex = btn.ID;
			bool flag = this._SelectGroupHandler != null;
			if (flag)
			{
				this._SelectGroupHandler.SetVisible(true);
			}
			return true;
		}

		// Token: 0x06009F2B RID: 40747 RVA: 0x001A57A8 File Offset: 0x001A39A8
		private void OnSelectGroupHandle()
		{
			bool flag = this._SelectGroupHandler == null || this._SelectGroupHandler.SelectGroup == null;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("GroupChat_UnSelectGroup"), "fece00");
				bool flag2 = this._SelectGroupHandler != null;
				if (flag2)
				{
					this._SelectGroupHandler.SetVisible(false);
				}
			}
			else
			{
				this._doc.SendZMLeaderAddRole(this._SelectIssueIndex, this._SelectGroupHandler.SelectGroup.id);
				this._SelectGroupHandler.SetVisible(false);
			}
		}

		// Token: 0x06009F2C RID: 40748 RVA: 0x001A583C File Offset: 0x001A3A3C
		protected override void SetInfo(IXUILabel label)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GroupChatMaxZMRoleIssue");
			int curUserMemberCount = (int)this._doc.CurUserMemberCount;
			label.SetText(((curUserMemberCount < @int) ? (@int - curUserMemberCount) : 0).ToString());
			this.m_BubbleTips.SetVisible(this.bubbleValid);
		}

		// Token: 0x06009F2D RID: 40749 RVA: 0x001A5894 File Offset: 0x001A3A94
		private bool OnMemberClick(IXUIButton btn)
		{
			DlgBase<RecruitPlayerPublishView, RecruitPlayerPublishBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x17002ED5 RID: 11989
		// (get) Token: 0x06009F2E RID: 40750 RVA: 0x001A58B4 File Offset: 0x001A3AB4
		private bool bubbleValid
		{
			get
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				bool flag = specificDocument.GetValue(XOptionsDefine.OD_RECRUIT_FIRST_MEMBER) == 1;
				bool result;
				if (flag)
				{
					specificDocument.SetValue(XOptionsDefine.OD_RECRUIT_FIRST_MEMBER, 0, false);
					result = true;
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		// Token: 0x040038C3 RID: 14531
		private IXUIButton m_btnMember;

		// Token: 0x040038C4 RID: 14532
		private IXUILabel m_BubbleTips;

		// Token: 0x040038C5 RID: 14533
		private ulong _SelectIssueIndex = 0UL;

		// Token: 0x040038C6 RID: 14534
		private RecruitSelectGroupHandler _SelectGroupHandler;
	}
}
