using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XQQVipDesBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.FindChild("Bg/Tpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 6U, false);
			this.m_Detail = (base.transform.Find("Bg/Detail").GetComponent("XUILabel") as IXUILabel);
			this.m_VipDesc = base.transform.Find("Bg/VipDesc");
			this.m_SVipDesc = base.transform.Find("Bg/SVipDesc");
			this.m_VipBtn = (base.transform.Find("Bg/VipDesc/Button").GetComponent("XUIButton") as IXUIButton);
			this.m_SVipBtn = (base.transform.Find("Bg/SVipDesc/Button").GetComponent("XUIButton") as IXUIButton);
			this.m_VipBtnText = (base.transform.Find("Bg/VipDesc/Button/text").GetComponent("XUILabel") as IXUILabel);
			this.m_SVipBtnText = (base.transform.Find("Bg/SVipDesc/Button/text").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Close;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_Detail;

		public Transform m_VipDesc;

		public Transform m_SVipDesc;

		public IXUILabel m_VipBtnText;

		public IXUILabel m_SVipBtnText;

		public IXUIButton m_VipBtn;

		public IXUIButton m_SVipBtn;
	}
}
