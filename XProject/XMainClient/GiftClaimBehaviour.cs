using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class GiftClaimBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_transRcv = base.transform.Find("recv");
			this.m_lblName = (base.transform.Find("recv/name").GetComponent("XUILabel") as IXUILabel);
			this.m_btnOpen = (base.transform.Find("recv/ok").GetComponent("XUIButton") as IXUIButton);
			this.m_transOpen = base.transform.Find("open");
			this.m_lblTitle = (base.transform.Find("open/name").GetComponent("XUILabel") as IXUILabel);
			this.m_lblDetail = (base.transform.Find("open/desc").GetComponent("XUILabel") as IXUILabel);
			this.m_btnThanks = (base.transform.Find("open/OK").GetComponent("XUIButton") as IXUIButton);
			this.m_objTpl = base.transform.Find("open/items/tmp").gameObject;
		}

		public Transform m_transRcv;

		public IXUILabel m_lblName;

		public IXUIButton m_btnOpen;

		public Transform m_transOpen;

		public IXUILabel m_lblTitle;

		public IXUILabel m_lblDetail;

		public IXUIButton m_btnThanks;

		public GameObject m_objTpl;
	}
}
