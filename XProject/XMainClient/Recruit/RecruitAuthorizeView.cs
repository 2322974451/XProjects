using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RecruitAuthorizeView : DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/RecruitAuthorizeView";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<GroupChatDocument>(GroupChatDocument.uuID);
			base.uiBehaviour._MemberWrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnWrapContentUpdate));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._doc.bShowMotion = false;
			this.StackRefresh();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			this._doc.SendGroupChatLeaderReviewList();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour._Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseHandler));
		}

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

		private bool OnCloseHandler(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		private bool OnApplyClick(IXUIButton btn)
		{
			this._doc.SendGroupChatLeaderReview((int)btn.ID, true);
			btn.SetEnable(false, false);
			return true;
		}

		private bool OnDenyClick(IXUIButton btn)
		{
			this._doc.SendGroupChatLeaderReview((int)btn.ID, false);
			btn.SetEnable(false, false);
			return true;
		}

		private GroupChatDocument _doc;

		private GroupMemberDisplay _memberDisplay;
	}
}
