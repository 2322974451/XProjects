using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XQQWXGameCenterPrivilegeBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.Find("Bg/Title").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege1 = (base.transform.Find("Bg/P1").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege2 = (base.transform.Find("Bg/P2").GetComponent("XUILabel") as IXUILabel);
			this.m_Privilege3 = (base.transform.Find("Bg/P3").GetComponent("XUILabel") as IXUILabel);
			this.m_QQIcon = base.transform.Find("Bg/P1/qq").gameObject;
			this.m_WXIcon = base.transform.Find("Bg/P1/wc").gameObject;
		}

		public IXUIButton m_Close;

		public IXUILabel m_Title;

		public IXUILabel m_Privilege1;

		public IXUILabel m_Privilege2;

		public IXUILabel m_Privilege3;

		public GameObject m_QQIcon;

		public GameObject m_WXIcon;
	}
}
