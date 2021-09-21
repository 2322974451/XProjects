using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000A31 RID: 2609
	internal class RecruitGroupHandle : RecruitListHandler
	{
		// Token: 0x06009F0C RID: 40716 RVA: 0x001A4DC4 File Offset: 0x001A2FC4
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

		// Token: 0x06009F0D RID: 40717 RVA: 0x001A4F04 File Offset: 0x001A3104
		protected override List<GroupMember> GetMemberList()
		{
			return this._doc.RecruitGroup;
		}

		// Token: 0x06009F0E RID: 40718 RVA: 0x001A4F24 File Offset: 0x001A3124
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

		// Token: 0x06009F0F RID: 40719 RVA: 0x001A4F88 File Offset: 0x001A3188
		private void RefreshVisibleRecruit()
		{
			bool flag = this._doc.CurGroupCount > 0U;
			this.m_Recruit.SetVisible(flag);
			this.m_RecruitTips.SetActive(flag);
		}

		// Token: 0x06009F10 RID: 40720 RVA: 0x001A4FBF File Offset: 0x001A31BF
		public override void RefreshRedPoint()
		{
			this.m_redPoint.SetActive(this._doc.bShowMotion);
		}

		// Token: 0x06009F11 RID: 40721 RVA: 0x001A4FD9 File Offset: 0x001A31D9
		public override void OnReSelect()
		{
			this._doc.SendGroupChatFindTeamInfoList(this.m_titleBar.filter);
		}

		// Token: 0x06009F12 RID: 40722 RVA: 0x001A4FF4 File Offset: 0x001A31F4
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

		// Token: 0x06009F13 RID: 40723 RVA: 0x001A5104 File Offset: 0x001A3304
		private bool OnRecruitClick(IXUIButton btn)
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			specificDocument.SendOpenSysInvitation(NoticeType.NT_GROUPCHAT_RECRUIT_WORLD, new ulong[0]);
			return true;
		}

		// Token: 0x06009F14 RID: 40724 RVA: 0x001A5134 File Offset: 0x001A3334
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

		// Token: 0x17002ED3 RID: 11987
		// (get) Token: 0x06009F15 RID: 40725 RVA: 0x001A51AC File Offset: 0x001A33AC
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

		// Token: 0x06009F16 RID: 40726 RVA: 0x001A51F4 File Offset: 0x001A33F4
		protected override void SetInfo(IXUILabel label)
		{
			int @int = XSingleton<XGlobalConfig>.singleton.GetInt("GroupChatMaxZMGroupIssue");
			int curGroupCount = (int)this._doc.CurGroupCount;
			label.SetText(((curGroupCount < @int) ? (@int - curGroupCount) : 0).ToString());
			this.m_BubbleTips.SetVisible(this.bubbleValid);
		}

		// Token: 0x06009F17 RID: 40727 RVA: 0x001A524C File Offset: 0x001A344C
		private bool OnAuthoriseClick(IXUIButton btn)
		{
			XSingleton<XGameSysMgr>.singleton.OpenSystem(XSysDefine.XSys_GroupRecruitAuthorize, 0UL);
			return true;
		}

		// Token: 0x06009F18 RID: 40728 RVA: 0x001A5274 File Offset: 0x001A3474
		private bool OnPublishClick(IXUIButton btn)
		{
			DlgBase<RecruitGroupPublishView, RecruitGroupPublishBehaviour>.singleton.SetVisibleWithAnimation(true, null);
			return true;
		}

		// Token: 0x040038B8 RID: 14520
		private IXUIButton m_Authorise;

		// Token: 0x040038B9 RID: 14521
		private IXUIButton m_Publish;

		// Token: 0x040038BA RID: 14522
		private IXUIButton m_Recruit;

		// Token: 0x040038BB RID: 14523
		private IXUILabel m_BubbleTips;

		// Token: 0x040038BC RID: 14524
		private GameObject m_redPoint;

		// Token: 0x040038BD RID: 14525
		private GameObject m_RecruitTips;
	}
}
