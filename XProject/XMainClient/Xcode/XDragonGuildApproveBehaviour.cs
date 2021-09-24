using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XDragonGuildApproveBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnOneKeyCancel = (base.transform.FindChild("Bg/BtnOneKeyCancel").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSetting = (base.transform.FindChild("Bg/BtnSetting").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSendMessage = (base.transform.FindChild("Bg/BtnSendMessage").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_RequiredPPT = (base.transform.FindChild("Bg/PPTRequirement").GetComponent("XUILabel") as IXUILabel);
			this.m_NeedApprove = (base.transform.FindChild("Bg/NeedApprove").GetComponent("XUILabel") as IXUILabel);
			this.m_MemberCount = (base.transform.FindChild("Bg/MemberCount").GetComponent("XUILabel") as IXUILabel);
			this.m_SettingPanel = base.transform.FindChild("Bg/SettingPanel").gameObject;
		}

		public IXUIButton m_Close = null;

		public IXUIButton m_BtnOneKeyCancel;

		public IXUIButton m_BtnSetting;

		public IXUIButton m_BtnSendMessage;

		public IXUILabel m_RequiredPPT;

		public IXUILabel m_NeedApprove;

		public IXUILabel m_MemberCount;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public GameObject m_SettingPanel;
	}
}
