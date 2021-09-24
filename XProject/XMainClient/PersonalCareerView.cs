using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class PersonalCareerView : DlgBase<PersonalCareerView, PersonalCareerBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/PersonalCareer/PersonalCareer";
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

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
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

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Personal_Career);
			}
		}

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

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCloseClicked));
		}

		public bool OnCloseClicked(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return true;
		}

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

		protected override void OnHide()
		{
			this.roleId = 0UL;
			this.doc.HasData.Clear();
			this.m_PrefabTab = PersonalCareerView.CareerTab.NONE;
			base.OnHide();
		}

		protected override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<CareerHomepageHandler>(ref this.HomepageHandler);
			DlgHandlerBase.EnsureUnload<CareerPVPDataHandler>(ref this.PVPHandler);
			DlgHandlerBase.EnsureUnload<CareerTrophyHandler>(ref this.TrophyHandler);
			base.OnUnload();
		}

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

		private XPersonalCareerDocument doc = null;

		private Dictionary<PersonalCareerView.CareerTab, IXUICheckBox> m_AllTabs = new Dictionary<PersonalCareerView.CareerTab, IXUICheckBox>();

		private PersonalCareerView.CareerTab m_CurrentTab;

		private PersonalCareerView.CareerTab m_PrefabTab = PersonalCareerView.CareerTab.NONE;

		public CareerHomepageHandler HomepageHandler = null;

		public CareerPVPDataHandler PVPHandler = null;

		public CareerTrophyHandler TrophyHandler = null;

		public ulong roleId = 0UL;

		private ulong param1 = 1UL;

		public enum CareerTab
		{

			NONE,

			Homepage,

			PVPInfo,

			Trophy,

			MAX
		}
	}
}
