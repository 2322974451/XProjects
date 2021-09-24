using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XGuildRedPacketBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_root = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Empty = base.transform.FindChild("Bg/Empty").gameObject;
		}

		public Transform m_root;

		public IXUIButton m_Close;

		public IXUIButton m_Help;

		public IXUIScrollView m_ScrollView;

		public IXUIWrapContent m_WrapContent;

		public GameObject m_Empty;
	}
}
