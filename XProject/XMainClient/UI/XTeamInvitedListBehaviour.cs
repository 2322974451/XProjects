using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XTeamInvitedListBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Bg2/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg");
			this.m_BtnIgnore = (transform.FindChild("BtnIgnore").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnDeny = (transform.FindChild("BtnDeny").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (transform.FindChild("Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (transform.FindChild("Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_NoInvitation = transform.Find("NoInvitation").gameObject;
		}

		public IXUIButton m_Close = null;

		public IXUIButton m_BtnIgnore;

		public IXUIButton m_BtnDeny;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public GameObject m_NoInvitation;
	}
}
