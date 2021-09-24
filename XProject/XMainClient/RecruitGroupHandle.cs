using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RecruitGroupHandle : RecruitListHandler
	{

		protected override void Init()
		{
			base.Init();
			this.m_Authorise = (base.transform.Find("Info/Btn_Authorise").GetComponent("XUIButton") as IXUIButton);
			this.m_Publish = (base.transform.Find("Info/Btn_Publish").GetComponent("XUIButton") as IXUIButton);
			this.m_Recruit = (base.transform.Find("Info/Btn_Recruit").GetComponent("XUIButton") as IXUIButton);
			this.m_redPoint = base.transform.Find("Info/Btn_Authorise/RedPoint").gameObject;
			this.m_BubbleTips = (base.transform.Find("Info/Message/Btn_Publish_LivenessTips").GetComponent("XUILabel") as IXUILabel);
			this.m_BubbleTips.SetText(XStringDefineProxy.GetString("GroupRecruit_GroupBubble"));
			this.m_RecruitTips = base.transform.Find("Info/Message/Btn_Recruit_LivenessTips").gameObject;
			this.m_Authorise.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnAuthoriseClick));
			this.m_Publish.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnPublishClick));
			this.m_Recruit.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRecruitClick));
		}

		protected override List<GroupMember> GetMemberList()
		{
			return this._doc.RecruitGroup;
		}

		public override void RefreshData()
		{
			this.RefreshVisibleRecruit();
			bool flag = this._doc.RecruitGroup != null;
			if (flag)
			{
				GroupMember.dir = this.m_titleBar.direction;
				GroupMember.sortSeletor = this.m_titleBar.selector;
				this._doc.RecruitGroup.Sort();
			}
			base.RefreshData();
		}

		private void RefreshVisibleRecruit()
		{
			bool flag = this._doc.CurGroupCount > 0U;
			this.m_Recruit.SetVisible(flag);
			this.m_RecruitTips.SetActive(flag);
		}

		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(this._doc.bShowMotion);
		}

		public override void OnReSelect()
		{
			this._doc.SendGroupChatFindTeamInfoList(this.m_titleBar.filter);
		}

		protected override void SetupOtherInfo(Transform t, GroupMember member)
		{
			IXUIButton ixuibutton = t.Find("BtnApply").GetComponent("XUIButton") as IXUIButton;
			Transform transform = t.Find("BtnApply/Applied");
			Transform transform2 = t.Find("BtnApply/T");
			ixuibutton.ID = member.issueIndex;
			bool flag = member.isselfingroup || member.userID == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID;
			if (flag)
			{
				ixuibutton.SetVisible(false);
			}
			else
			{
				ixuibutton.SetVisible(true);
				ixuibutton.SetEnable(true, false);
				ixuibutton.SetClickCD(1f);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnApplyClick));
				bool flag2 = member.state == 1U;
				if (flag2)
				{
					transform.gameObject.SetActive(true);
					transform2.gameObject.SetActive(false);
					ixuibutton.SetEnable(false, false);
				}
				else
				{
					transform.gameObject.SetActive(false);
					transform2.gameObject.SetActive(true);
					ixuibutton.SetEnable(true, false);
				}
			}
		}

		private bool OnRecruitClick(IXUIButton btn)
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			specificDocument.SendOpenSysInvitation(NoticeType.NT_GROUPCHAT_RECRUIT_WORLD, new ulong[0]);
			return true;
		}

		private bool OnApplyClick(IXUIButton btn)
		{
			ulong id = btn.ID;
			this._doc.SendGroupChatPlayerApply(id);
			Transform transform = btn.gameObject.transform.Find("Applied");
			Transform transform2 = btn.gameObject.transform.Find("T");
			transform.gameObject.SetActive(true);
			transform2.gameObject.SetActive(false);
			btn.SetEnable(false, false);
			return true;
		}

		private bool bubbleValid
		{
			get
			{
				XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
				int value = specificDocument.GetValue(XOptionsDefine.OD_RECRUIT_FIRST_GROUP);
				bool flag = value == 1;
				bool result;
				if (flag)
				{
					specificDocument.SetValue(XOptionsDefine.OD_RECRUIT_FIRST_GROUP, 0, false);
					result = true;
				}
				else
				{
					result = false;
				}
				return result;
			}
		}

		protected override void SetInfo(IXUILabel label)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GroupChatMaxZMGroupIssue");
			int curGroupCount = (int)this._doc.CurGroupCount;
			label.SetText(((curGroupCount < @int) ? (@int - curGroupCount) : 0).ToString());
			this.m_BubbleTips.SetVisible(this.bubbleValid);
		}

		private bool OnAuthoriseClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_GroupRecruitAuthorize, 0UL);
			return true;
		}

		private bool OnPublishClick(IXUIButton btn)
		{
			DlgBase<RecruitGroupPublishView, RecruitGroupPublishBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		private IXUIButton m_Authorise;

		private IXUIButton m_Publish;

		private IXUIButton m_Recruit;

		private IXUILabel m_BubbleTips;

		private GameObject m_redPoint;

		private GameObject m_RecruitTips;
	}
}
