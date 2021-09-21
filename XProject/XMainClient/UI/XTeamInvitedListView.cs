using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001866 RID: 6246
	internal class XTeamInvitedListView : DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>
	{
		// Token: 0x1700399A RID: 14746
		// (get) Token: 0x06010422 RID: 66594 RVA: 0x003EE970 File Offset: 0x003ECB70
		public override string fileName
		{
			get
			{
				return "Team/InviteListDlg";
			}
		}

		// Token: 0x1700399B RID: 14747
		// (get) Token: 0x06010423 RID: 66595 RVA: 0x003EE988 File Offset: 0x003ECB88
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700399C RID: 14748
		// (get) Token: 0x06010424 RID: 66596 RVA: 0x003EE99C File Offset: 0x003ECB9C
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700399D RID: 14749
		// (get) Token: 0x06010425 RID: 66597 RVA: 0x003EE9B0 File Offset: 0x003ECBB0
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x1700399E RID: 14750
		// (get) Token: 0x06010426 RID: 66598 RVA: 0x003EE9C4 File Offset: 0x003ECBC4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010427 RID: 66599 RVA: 0x003EE9D7 File Offset: 0x003ECBD7
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamInviteDocument>(XTeamInviteDocument.uuID);
			this.doc.InvitedView = this;
		}

		// Token: 0x06010428 RID: 66600 RVA: 0x003EE9F6 File Offset: 0x003ECBF6
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
			this.doc.InvitedView = null;
			base.OnUnload();
		}

		// Token: 0x06010429 RID: 66601 RVA: 0x003EEA20 File Offset: 0x003ECC20
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCloseBtnClick));
			base.uiBehaviour.m_BtnIgnore.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnIgnoreBtnClick));
			base.uiBehaviour.m_BtnDeny.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnDenyBtnClick));
			base.uiBehaviour.m_WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0601042A RID: 66602 RVA: 0x003EEAA2 File Offset: 0x003ECCA2
		protected override void OnShow()
		{
			base.OnShow();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
			this._AutoRefresh(null);
		}

		// Token: 0x0601042B RID: 66603 RVA: 0x003EEAC5 File Offset: 0x003ECCC5
		protected override void OnHide()
		{
			base.OnHide();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
		}

		// Token: 0x0601042C RID: 66604 RVA: 0x003EEAE0 File Offset: 0x003ECCE0
		public override void StackRefresh()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_TimerID);
			this._AutoRefresh(null);
		}

		// Token: 0x0601042D RID: 66605 RVA: 0x003EEAFC File Offset: 0x003ECCFC
		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				this.doc.ReqInvitedList();
				this.m_TimerID = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this._AutoRefresh), null);
			}
		}

		// Token: 0x0601042E RID: 66606 RVA: 0x003EEB44 File Offset: 0x003ECD44
		public void RefreshPage()
		{
			List<XTeamInviteData> invitedList = this.doc.InvitedList;
			base.uiBehaviour.m_WrapContent.SetContentCount(invitedList.Count, false);
			base.uiBehaviour.m_NoInvitation.SetActive(invitedList.Count == 0);
		}

		// Token: 0x0601042F RID: 66607 RVA: 0x003EEB90 File Offset: 0x003ECD90
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

		// Token: 0x06010430 RID: 66608 RVA: 0x003EEDD4 File Offset: 0x003ECFD4
		private bool _OnCloseBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010431 RID: 66609 RVA: 0x003EEDF0 File Offset: 0x003ECFF0
		private bool _OnIgnoreBtnClick(IXUIButton go)
		{
			this.doc.ReqIgnoreAll();
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010432 RID: 66610 RVA: 0x003EEE18 File Offset: 0x003ED018
		private bool _OnDenyBtnClick(IXUIButton go)
		{
			this.doc.ReqDeny();
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x06010433 RID: 66611 RVA: 0x003EEE40 File Offset: 0x003ED040
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

		// Token: 0x040074E5 RID: 29925
		private XTeamInviteDocument doc;

		// Token: 0x040074E6 RID: 29926
		private uint m_TimerID = 0U;
	}
}
