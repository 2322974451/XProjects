using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamInvitedListView : DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/InviteListDlg";
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

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			this.doc.InvitedView = this;
		}

		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
			this.doc.InvitedView = null;
			base.OnUnload();
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnIgnore.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnIgnoreBtnClick));
			base.uiBehaviour.m_BtnDeny.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDenyBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
			this._AutoRefresh(null);
		}

		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
		}

		public override void StackRefresh()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
			this._AutoRefresh(null);
		}

		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.doc.ReqInvitedList();
				this.m_TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this._AutoRefresh), null);
			}
		}

		public void RefreshPage()
		{
			List<XTeamInviteData> invitedList = this.doc.InvitedList;
			base.uiBehaviour.m_WrapContent.SetContentCount(invitedList.Count, false);
			base.uiBehaviour.m_NoInvitation.SetActive(invitedList.Count == 0);
		}

		private void WrapContentItemUpdated(Transform t, int index)
		{
			List<XTeamInviteData> invitedList = this.doc.InvitedList;
			bool flag = index >= invitedList.Count;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Item index out of range: ", index.ToString(), null, null, null, null);
			}
			else
			{
				XTeamInviteData xteamInviteData = invitedList[index];
				IXUILabel ixuilabel = t.FindChild("DungeonName").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Name").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("PPT").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel4 = t.FindChild("Time").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel5 = t.FindChild("MemberCount").GetComponent("XUILabel") as IXUILabel;
				GameObject gameObject = t.Find("RewardHunt").gameObject;
				IXUISprite ixuisprite = t.Find("Regression").GetComponent("XUISprite") as IXUISprite;
				IXUIButton ixuibutton = t.FindChild("BtnJoin").GetComponent("XUIButton") as IXUIButton;
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnJoinBtnClick));
				bool flag2 = xteamInviteData.briefData.rift != null;
				if (flag2)
				{
					ixuilabel.SetText(xteamInviteData.briefData.rift.GetSceneName(xteamInviteData.briefData.dungeonName));
				}
				else
				{
					ixuilabel.SetText(xteamInviteData.briefData.dungeonName);
				}
				ixuilabel2.SetText(xteamInviteData.invitorName);
				ixuilabel3.SetText(xteamInviteData.briefData.GetStrTeamPPT(0.0));
				ixuilabel4.SetText(XSingleton<UiUtility>.singleton.TimeAgoFormatString((int)xteamInviteData.time));
				ixuilabel5.SetText(string.Format("{0}/{1}", xteamInviteData.briefData.currentMemberCount, xteamInviteData.briefData.totalMemberCount));
				ixuisprite.SetVisible(xteamInviteData.briefData.regression);
				xteamInviteData.briefData.goldGroup.SetUI(gameObject, true);
				XTeamView.SetTeamRelationUI(t.Find("Relation"), xteamInviteData.invitorRelation, false, XTeamRelation.Relation.TR_NONE);
				ixuibutton.ID = (ulong)((long)index);
			}
		}

		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnIgnoreBtnClick(IXUIButton go)
		{
			this.doc.ReqIgnoreAll();
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnDenyBtnClick(IXUIButton go)
		{
			this.doc.ReqDeny();
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		private bool _OnJoinBtnClick(IXUIButton go)
		{
			int num = (int)go.ID;
			bool flag = num >= this.doc.InvitedList.Count;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				XTeamInviteData xteamInviteData = this.doc.InvitedList[num];
				this.doc.ReqTeamInviteAck(true, xteamInviteData.inviteID);
				result = true;
			}
			return result;
		}

		private XTeamInviteDocument doc;

		private uint m_TimerID = 0U;
	}
}
