using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C8B RID: 3211
	internal class PersonalCareerView : DlgBase<PersonalCareerView, PersonalCareerBehaviour>
	{
		// Token: 0x17003212 RID: 12818
		// (get) Token: 0x0600B556 RID: 46422 RVA: 0x0023C108 File Offset: 0x0023A308
		public override string fileName
		{
			get
			{
				return "GameSystem/PersonalCareer/PersonalCareer";
			}
		}

		// Token: 0x17003213 RID: 12819
		// (get) Token: 0x0600B557 RID: 46423 RVA: 0x0023C120 File Offset: 0x0023A320
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003214 RID: 12820
		// (get) Token: 0x0600B558 RID: 46424 RVA: 0x0023C134 File Offset: 0x0023A334
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003215 RID: 12821
		// (get) Token: 0x0600B559 RID: 46425 RVA: 0x0023C148 File Offset: 0x0023A348
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003216 RID: 12822
		// (get) Token: 0x0600B55A RID: 46426 RVA: 0x0023C15C File Offset: 0x0023A35C
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003217 RID: 12823
		// (get) Token: 0x0600B55B RID: 46427 RVA: 0x0023C170 File Offset: 0x0023A370
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003218 RID: 12824
		// (get) Token: 0x0600B55C RID: 46428 RVA: 0x0023C184 File Offset: 0x0023A384
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003219 RID: 12825
		// (get) Token: 0x0600B55D RID: 46429 RVA: 0x0023C198 File Offset: 0x0023A398
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Personal_Career);
			}
		}

		// Token: 0x0600B55E RID: 46430 RVA: 0x0023C1B4 File Offset: 0x0023A3B4
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XPersonalCareerDocument>(XPersonalCareerDocument.uuID);
			this.m_AllTabs.Clear();
			base.uiBehaviour.m_TabPool.FakeReturnAll();
			for (int i = 1; i <= XPersonalCareerDocument.CareerTable.Table.Length; i++)
			{
				GameObject gameObject = base.uiBehaviour.m_TabPool.FetchGameObject(false);
				gameObject.transform.localPosition = new Vector3(0f, (float)(-(float)base.uiBehaviour.m_TabPool.TplHeight * (i - 1)), 0f) + base.uiBehaviour.m_TabPool.TplPos;
				Career.RowData career = XPersonalCareerDocument.GetCareer(i);
				IXUILabel ixuilabel = gameObject.transform.Find("Bg/TextLabel").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(career.TabName);
				ixuilabel = (gameObject.transform.Find("Bg/Selected/TextLabel").GetComponent("XUILabel") as IXUILabel);
				ixuilabel.SetText(career.TabName);
				IXUICheckBox ixuicheckBox = gameObject.transform.Find("Bg").GetComponent("XUICheckBox") as IXUICheckBox;
				ixuicheckBox.ID = (ulong)((long)career.ID);
				ixuicheckBox.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this._CheckBoxChanged));
				this.m_AllTabs.Add((PersonalCareerView.CareerTab)career.ID, ixuicheckBox);
			}
			base.uiBehaviour.m_TabPool.ActualReturnAll(false);
		}

		// Token: 0x0600B55F RID: 46431 RVA: 0x0023C33C File Offset: 0x0023A53C
		private bool _CheckBoxChanged(IXUICheckBox iXUICheckBox)
		{
			bool flag = !iXUICheckBox.bChecked;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.OnTabChanged((PersonalCareerView.CareerTab)iXUICheckBox.ID);
				result = true;
			}
			return result;
		}

		// Token: 0x0600B560 RID: 46432 RVA: 0x0023C36E File Offset: 0x0023A56E
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B561 RID: 46433 RVA: 0x0023C390 File Offset: 0x0023A590
		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

		// Token: 0x0600B562 RID: 46434 RVA: 0x0023C3AC File Offset: 0x0023A5AC
		protected override void OnShow()
		{
			base.OnShow();
			this.CloseAllTab();
			bool flag = this.m_PrefabTab == PersonalCareerView.CareerTab.NONE;
			if (flag)
			{
				Career.RowData career = XPersonalCareerDocument.GetCareer(1);
				this.m_PrefabTab = (PersonalCareerView.CareerTab)career.ID;
			}
			this.OnTabChanged(this.m_PrefabTab);
		}

		// Token: 0x0600B563 RID: 46435 RVA: 0x0023C3F7 File Offset: 0x0023A5F7
		protected override void OnHide()
		{
			this.roleId = 0UL;
			this.doc.HasData.Clear();
			this.m_PrefabTab = PersonalCareerView.CareerTab.NONE;
			base.OnHide();
		}

		// Token: 0x0600B564 RID: 46436 RVA: 0x0023C421 File Offset: 0x0023A621
		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<CareerHomepageHandler>(ref this.HomepageHandler);
			DlgHandlerBase.EnsureUnload<CareerPVPDataHandler>(ref this.PVPHandler);
			DlgHandlerBase.EnsureUnload<CareerTrophyHandler>(ref this.TrophyHandler);
			base.OnUnload();
		}

		// Token: 0x0600B565 RID: 46437 RVA: 0x0023C450 File Offset: 0x0023A650
		private void CloseAllTab()
		{
			bool flag = this.HomepageHandler != null && this.HomepageHandler.IsVisible();
			if (flag)
			{
				this.HomepageHandler.SetVisible(false);
			}
			bool flag2 = this.PVPHandler != null && this.PVPHandler.IsVisible();
			if (flag2)
			{
				this.PVPHandler.SetVisible(false);
			}
			bool flag3 = this.TrophyHandler != null && this.TrophyHandler.IsVisible();
			if (flag3)
			{
				this.TrophyHandler.SetVisible(false);
			}
		}

		// Token: 0x0600B566 RID: 46438 RVA: 0x0023C4D4 File Offset: 0x0023A6D4
		public void OnTabChanged(PersonalCareerView.CareerTab handler)
		{
			XSingleton<XDebug>.singleton.AddGreenLog("Tab:" + handler.ToString(), null, null, null, null, null);
			this.m_CurrentTab = handler;
			IXUICheckBox ixuicheckBox;
			bool flag = this.m_AllTabs.TryGetValue(handler, out ixuicheckBox);
			if (flag)
			{
				ixuicheckBox.bChecked = true;
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("No Default Tabs", null, null, null, null, null);
			}
			PersonalCarrerReqType type = PersonalCarrerReqType.PCRT_HOME_PAGE;
			switch (this.m_CurrentTab)
			{
			case PersonalCareerView.CareerTab.Homepage:
			{
				bool flag2 = this.HomepageHandler == null;
				if (flag2)
				{
					DlgHandlerBase.EnsureCreate<CareerHomepageHandler>(ref this.HomepageHandler, base.uiBehaviour.transform, true, this);
					this.HomepageHandler.SetVisible(false);
				}
				type = PersonalCarrerReqType.PCRT_HOME_PAGE;
				break;
			}
			case PersonalCareerView.CareerTab.PVPInfo:
			{
				bool flag3 = this.PVPHandler == null;
				if (flag3)
				{
					DlgHandlerBase.EnsureCreate<CareerPVPDataHandler>(ref this.PVPHandler, base.uiBehaviour.transform, true, this);
					this.PVPHandler.SetVisible(false);
				}
				type = PersonalCarrerReqType.PCRT_PVP_PKINFO;
				break;
			}
			case PersonalCareerView.CareerTab.Trophy:
			{
				bool flag4 = this.TrophyHandler == null;
				if (flag4)
				{
					DlgHandlerBase.EnsureCreate<CareerTrophyHandler>(ref this.TrophyHandler, base.uiBehaviour.transform, true, this);
					this.TrophyHandler.SetVisible(false);
				}
				type = PersonalCarrerReqType.PCRT_TROPHY;
				break;
			}
			}
			bool flag5 = this.IsHasData(type);
			if (flag5)
			{
				this.OpenTab(this.m_CurrentTab);
			}
			else
			{
				this.doc.ReqGetCareer(type, this.roleId);
			}
		}

		// Token: 0x0600B567 RID: 46439 RVA: 0x0023C648 File Offset: 0x0023A848
		public bool IsHasData(PersonalCarrerReqType type)
		{
			bool flag2;
			bool flag = this.doc.HasData.TryGetValue(type, out flag2) && flag2;
			bool result;
			if (flag)
			{
				XSingleton<XDebug>.singleton.AddLog(type + " HasData", null, null, null, null, null, XDebugColor.XDebug_None);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600B568 RID: 46440 RVA: 0x0023C69C File Offset: 0x0023A89C
		public void SetCareer(PersonalCareerArg oArg, PersonalCareerRes oRes)
		{
			switch (oArg.quest_type)
			{
			case PersonalCarrerReqType.PCRT_HOME_PAGE:
				this.OpenTab(PersonalCareerView.CareerTab.Homepage);
				this.doc.HasData[oArg.quest_type] = true;
				this.HomepageHandler.SetData(oRes.home_page);
				break;
			case PersonalCarrerReqType.PCRT_PVP_PKINFO:
				this.OpenTab(PersonalCareerView.CareerTab.PVPInfo);
				this.doc.HasData[oArg.quest_type] = true;
				this.PVPHandler.SetData(oRes.pvp_info);
				break;
			case PersonalCarrerReqType.PCRT_TROPHY:
				this.OpenTab(PersonalCareerView.CareerTab.Trophy);
				this.doc.HasData[oArg.quest_type] = true;
				this.TrophyHandler.SetData(oRes.trophy_data);
				break;
			}
		}

		// Token: 0x0600B569 RID: 46441 RVA: 0x0023C768 File Offset: 0x0023A968
		public void OpenTab(PersonalCareerView.CareerTab tab)
		{
			this.CloseAllTab();
			switch (tab)
			{
			case PersonalCareerView.CareerTab.Homepage:
				this.HomepageHandler.SetVisible(true);
				break;
			case PersonalCareerView.CareerTab.PVPInfo:
				this.PVPHandler.SetVisible(true);
				break;
			case PersonalCareerView.CareerTab.Trophy:
				this.TrophyHandler.SetVisible(true);
				this.TrophyHandler.RefreshList(false);
				break;
			}
		}

		// Token: 0x0600B56A RID: 46442 RVA: 0x0023C7D0 File Offset: 0x0023A9D0
		public void OpenOtherPush(List<ulong> param)
		{
			for (int i = 0; i < param.Count; i++)
			{
				XSingleton<XDebug>.singleton.AddGreenLog(string.Concat(new object[]
				{
					"param",
					i,
					":",
					param[i]
				}), null, null, null, null, null);
			}
			bool flag = param.Count < 2;
			if (!flag)
			{
				this.roleId = ((param[0] == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID) ? 0UL : param[0]);
				this.m_PrefabTab = (PersonalCareerView.CareerTab)param[1];
				this.SetVisibleWithAnimation(true, null);
				bool flag2 = this.m_PrefabTab == PersonalCareerView.CareerTab.PVPInfo;
				if (flag2)
				{
					int index = 0;
					bool flag3 = param.Count > 2;
					if (flag3)
					{
						index = (int)param[2];
					}
					this.PVPHandler.OnTabChanged(index);
				}
			}
		}

		// Token: 0x0600B56B RID: 46443 RVA: 0x0023C8C4 File Offset: 0x0023AAC4
		public void ShareClick()
		{
			bool flag = this.roleId > 0UL;
			if (!flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("ShareClick", null, null, null, null, null);
				XSingleton<XScreenShotMgr>.singleton.SendStatisticToServer(ShareOpType.Share, DragonShareType.ShowGlory);
				XSingleton<XScreenShotMgr>.singleton.StartExternalScreenShotView(null);
			}
		}

		// Token: 0x0600B56C RID: 46444 RVA: 0x0023C910 File Offset: 0x0023AB10
		public void PushClick(ulong p1 = 0UL)
		{
			bool flag = this.roleId > 0UL;
			if (!flag)
			{
				XSingleton<XDebug>.singleton.AddGreenLog("PushClick", null, null, null, null, null);
				this.param1 = p1;
				DlgBase<XChatSmallView, XChatSmallBehaviour>.singleton.DoOpenChatWindow(null);
				XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
				DlgBase<XChatView, XChatBehaviour>.singleton.RegistLinkSend(specificDocument.GetOpenSysLinkString(this.GetNotice(), new object[0]), new Action(this.OnChatSend));
				DlgBase<PersonalCareerView, PersonalCareerBehaviour>.singleton.SetVisibleWithAnimation(false, null);
			}
		}

		// Token: 0x0600B56D RID: 46445 RVA: 0x0023C998 File Offset: 0x0023AB98
		private void OnChatSend()
		{
			XInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XInvitationDocument>(XInvitationDocument.uuID);
			specificDocument.SendOpenSysInvitation(this.GetNotice(), new ulong[]
			{
				XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID,
				(ulong)((long)XFastEnumIntEqualityComparer<PersonalCareerView.CareerTab>.ToInt(this.m_CurrentTab)),
				this.param1
			});
		}

		// Token: 0x0600B56E RID: 46446 RVA: 0x0023C9F0 File Offset: 0x0023ABF0
		private NoticeType GetNotice()
		{
			NoticeType result = NoticeType.NT_OPENSYS_CAREER_MAIN;
			switch (this.m_CurrentTab)
			{
			case PersonalCareerView.CareerTab.Homepage:
				result = NoticeType.NT_OPENSYS_CAREER_MAIN;
				break;
			case PersonalCareerView.CareerTab.PVPInfo:
				result = NoticeType.NT_OPENSYS_CAREER_PVP;
				break;
			case PersonalCareerView.CareerTab.Trophy:
				result = NoticeType.NT_OPENSYS_CAREER_Trophy;
				break;
			}
			return result;
		}

		// Token: 0x040046E4 RID: 18148
		private XPersonalCareerDocument doc = null;

		// Token: 0x040046E5 RID: 18149
		private Dictionary<PersonalCareerView.CareerTab, IXUICheckBox> m_AllTabs = new Dictionary<PersonalCareerView.CareerTab, IXUICheckBox>();

		// Token: 0x040046E6 RID: 18150
		private PersonalCareerView.CareerTab m_CurrentTab;

		// Token: 0x040046E7 RID: 18151
		private PersonalCareerView.CareerTab m_PrefabTab = PersonalCareerView.CareerTab.NONE;

		// Token: 0x040046E8 RID: 18152
		public CareerHomepageHandler HomepageHandler = null;

		// Token: 0x040046E9 RID: 18153
		public CareerPVPDataHandler PVPHandler = null;

		// Token: 0x040046EA RID: 18154
		public CareerTrophyHandler TrophyHandler = null;

		// Token: 0x040046EB RID: 18155
		public ulong roleId = 0UL;

		// Token: 0x040046EC RID: 18156
		private ulong param1 = 1UL;

		// Token: 0x020019AD RID: 6573
		public enum CareerTab
		{
			// Token: 0x04007F80 RID: 32640
			NONE,
			// Token: 0x04007F81 RID: 32641
			Homepage,
			// Token: 0x04007F82 RID: 32642
			PVPInfo,
			// Token: 0x04007F83 RID: 32643
			Trophy,
			// Token: 0x04007F84 RID: 32644
			MAX
		}
	}
}
