using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000A45 RID: 2629
	internal class RecruitAuthorizeView : DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>
	{
		// Token: 0x17002EE0 RID: 12000
		// (get) Token: 0x06009FAB RID: 40875 RVA: 0x001A794C File Offset: 0x001A5B4C
		public override string fileName
		{
			get
			{
				return "Team/RecruitAuthorizeView";
			}
		}

		// Token: 0x06009FAC RID: 40876 RVA: 0x001A7963 File Offset: 0x001A5B63
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			base.uiBehaviour._MemberWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		// Token: 0x06009FAD RID: 40877 RVA: 0x001A799A File Offset: 0x001A5B9A
		protected override void OnShow()
		{
			base.OnShow();
			this._doc.bShowMotion = false;
			this.StackRefresh();
		}

		// Token: 0x06009FAE RID: 40878 RVA: 0x001A79B8 File Offset: 0x001A5BB8
		public override void StackRefresh()
		{
			base.StackRefresh();
			this._doc.SendGroupChatLeaderReviewList();
		}

		// Token: 0x06009FAF RID: 40879 RVA: 0x001A79CE File Offset: 0x001A5BCE
		public override void RegisterEvent()
		{
			base.uiBehaviour._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseHandler));
		}

		// Token: 0x06009FB0 RID: 40880 RVA: 0x001A79F0 File Offset: 0x001A5BF0
		protected override void OnUnload()
		{
			bool flag = this._memberDisplay != null;
			if (flag)
			{
				this._memberDisplay.Release();
				this._memberDisplay = null;
			}
			base.OnUnload();
		}

		// Token: 0x06009FB1 RID: 40881 RVA: 0x001A7A28 File Offset: 0x001A5C28
		public void RefreshData()
		{
			List<GroupMember> leaderReviewList = this._doc.LeaderReviewList;
			bool flag = leaderReviewList == null || leaderReviewList.Count == 0;
			if (flag)
			{
				base.uiBehaviour._MemberWrapContent.SetContentCount(0, false);
			}
			else
			{
				base.uiBehaviour._MemberWrapContent.SetContentCount(leaderReviewList.Count, false);
			}
			base.uiBehaviour._Empty.gameObject.SetActive(leaderReviewList.Count == 0);
			base.uiBehaviour._MemberScrollView.ResetPosition();
		}

		// Token: 0x06009FB2 RID: 40882 RVA: 0x001A7AB4 File Offset: 0x001A5CB4
		private bool OnCloseHandler(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06009FB3 RID: 40883 RVA: 0x001A7AD0 File Offset: 0x001A5CD0
		private void OnWrapContentUpdate(Transform t, int index)
		{
			bool flag = index < 0 || index >= this._doc.LeaderReviewList.Count;
			if (!flag)
			{
				bool flag2 = this._memberDisplay == null;
				if (flag2)
				{
					this._memberDisplay = new GroupMemberDisplay();
				}
				this._memberDisplay.Init(t);
				GroupMember member = this._doc.LeaderReviewList[index];
				this._memberDisplay.Setup(member);
				IXUIButton ixuibutton = t.Find("BtnApply").GetComponent("XUIButton") as IXUIButton;
				IXUIButton ixuibutton2 = t.Find("BtnDeny").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.SetEnable(true, false);
				ixuibutton2.ID = (ulong)((long)index);
				ixuibutton2.SetEnable(true, false);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnApplyClick));
				ixuibutton2.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnDenyClick));
				IXUISprite ixuisprite = t.Find("Bg").GetComponent("XUISprite") as IXUISprite;
				ixuisprite.ID = (ulong)((long)index);
				ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPlayerClick));
			}
		}

		// Token: 0x06009FB4 RID: 40884 RVA: 0x001A7C04 File Offset: 0x001A5E04
		private void OnPlayerClick(IXUISprite sprite)
		{
			int num = (int)sprite.ID;
			bool flag = num < this._doc.LeaderReviewList.Count;
			if (flag)
			{
				GroupMember groupMember = this._doc.LeaderReviewList[num];
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(groupMember.userID, groupMember.userName, new List<uint>(), 0U, 1U);
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowTab(Player_Info.Equip, 0UL, 0UL);
			}
		}

		// Token: 0x06009FB5 RID: 40885 RVA: 0x001A7C80 File Offset: 0x001A5E80
		private bool OnApplyClick(IXUIButton btn)
		{
			this._doc.SendGroupChatLeaderReview((int)btn.ID, true);
			btn.SetEnable(false, false);
			return true;
		}

		// Token: 0x06009FB6 RID: 40886 RVA: 0x001A7CB0 File Offset: 0x001A5EB0
		private bool OnDenyClick(IXUIButton btn)
		{
			this._doc.SendGroupChatLeaderReview((int)btn.ID, false);
			btn.SetEnable(false, false);
			return true;
		}

		// Token: 0x04003906 RID: 14598
		private GroupChatDocument _doc;

		// Token: 0x04003907 RID: 14599
		private GroupMemberDisplay _memberDisplay;
	}
}
