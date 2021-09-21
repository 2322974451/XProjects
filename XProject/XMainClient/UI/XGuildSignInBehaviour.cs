using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018AC RID: 6316
	internal class XGuildSignInBehaviour : DlgBehaviourBase
	{
		// Token: 0x0601075D RID: 67421 RVA: 0x00407128 File Offset: 0x00405328
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

		// Token: 0x040076EA RID: 30442
		public IXUIButton m_Close = null;

		// Token: 0x040076EB RID: 30443
		public IXUIButton m_BtnLog;

		// Token: 0x040076EC RID: 30444
		public IXUIProgress m_ExpProgress;

		// Token: 0x040076ED RID: 30445
		public XUIPool m_ChestPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040076EE RID: 30446
		public IXUILabel m_MemberCount;

		// Token: 0x040076EF RID: 30447
		public IXUILabel m_Exp;

		// Token: 0x040076F0 RID: 30448
		public XNumberTween m_ExpTween;

		// Token: 0x040076F1 RID: 30449
		public XUIPool m_SignInButtonPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040076F2 RID: 30450
		public GameObject m_LogPanel;
	}
}
