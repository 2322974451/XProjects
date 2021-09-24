using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitMemberHandler : RecruitListHandler
	{

		public override void OnReSelect()
		{
			this._doc.SendGroupChatFindRoleInfoList(this.m_titleBar.filter);
		}

		protected override List<GroupMember> GetMemberList()
		{
			return this._doc.RecruitMember;
		}

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

		protected override void OnHide()
		{
			bool flag = this._SelectGroupHandler != null && this._SelectGroupHandler.IsVisible();
			if (flag)
			{
				this._SelectGroupHandler.SetVisible(false);
			}
			base.OnHide();
		}

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

		protected override void SetupOtherInfo(Transform t, GroupMember member)
		{
			base.SetupOtherInfo(t, member);
			IXUIButton ixuibutton = t.Find("BtnRecruit").GetComponent("XUIButton") as IXUIButton;
			ixuibutton.SetVisible(false);
			ixuibutton.ID = member.issueIndex;
			ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRecruitClick));
			ixuibutton.SetVisible(member.userID != XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID);
		}

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

		protected override void SetInfo(IXUILabel label)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GroupChatMaxZMRoleIssue");
			int curUserMemberCount = (int)this._doc.CurUserMemberCount;
			label.SetText(((curUserMemberCount < @int) ? (@int - curUserMemberCount) : 0).ToString());
			this.m_BubbleTips.SetVisible(this.bubbleValid);
		}

		private bool OnMemberClick(IXUIButton btn)
		{
			DlgBase<RecruitPlayerPublishView, RecruitPlayerPublishBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

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

		private IXUIButton m_btnMember;

		private IXUILabel m_BubbleTips;

		private ulong _SelectIssueIndex = 0UL;

		private RecruitSelectGroupHandler _SelectGroupHandler;
	}
}
