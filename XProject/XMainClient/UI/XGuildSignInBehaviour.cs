using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XGuildSignInBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnLog = (base.transform.FindChild("Bg/BtnLog").GetComponent("XUIButton") as IXUIButton);
			this.m_LogPanel = base.transform.FindChild("Bg/LogPanel").gameObject;
			Transform transform = base.transform.FindChild("Bg/Progress/Chests/ChestTpl");
			this.m_ChestPool.SetupPool(transform.parent.gameObject, transform.gameObject, 2U, false);
			transform = base.transform.FindChild("Bg/SignInButtons/SignInButtonTpl");
			this.m_SignInButtonPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_ExpProgress = (base.transform.FindChild("Bg/Progress").GetComponent("XUIProgress") as IXUIProgress);
			this.m_MemberCount = (base.transform.FindChild("Bg/MemberCount").GetComponent("XUILabel") as IXUILabel);
			this.m_Exp = (base.transform.FindChild("Bg/CurrentExp").GetComponent("XUILabel") as IXUILabel);
			this.m_ExpTween = XNumberTween.Create(this.m_Exp);
			this.m_ExpTween.SetNumberWithTween(0UL, "", false, true);
		}

		public IXUIButton m_Close = null;

		public IXUIButton m_BtnLog;

		public IXUIProgress m_ExpProgress;

		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel m_MemberCount;

		public IXUILabel m_Exp;

		public XNumberTween m_ExpTween;

		public XUIPool m_SignInButtonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_LogPanel;
	}
}
