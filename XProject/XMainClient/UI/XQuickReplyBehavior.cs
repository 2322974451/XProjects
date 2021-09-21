using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001876 RID: 6262
	internal class XQuickReplyBehavior : DlgBehaviourBase
	{
		// Token: 0x060104CA RID: 66762 RVA: 0x003F1AD8 File Offset: 0x003EFCD8
		private void Awake()
		{
			this.m_SpeakPanel = base.transform.FindChild("Bg/SpeakPanel");
			this.m_Title = (base.transform.FindChild("Bg/Title/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_Voice = (base.transform.FindChild("Bg/BtnVoice").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_WrapScrollView = (base.transform.FindChild("Bg/ScrollView").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_WrapTemp = base.transform.FindChild("Bg/ScrollView/WrapContent/Content");
			this.m_ItemPool.SetupPool(this.m_WrapTemp.parent.gameObject, this.m_WrapTemp.gameObject, 2U, false);
		}

		// Token: 0x04007536 RID: 30006
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007537 RID: 30007
		public IXUIScrollView m_WrapScrollView = null;

		// Token: 0x04007538 RID: 30008
		public IXUIWrapContent m_WrapContent = null;

		// Token: 0x04007539 RID: 30009
		public IXUISprite m_Close = null;

		// Token: 0x0400753A RID: 30010
		public IXUILabel m_Title = null;

		// Token: 0x0400753B RID: 30011
		public IXUIButton m_Voice = null;

		// Token: 0x0400753C RID: 30012
		public Transform m_WrapTemp = null;

		// Token: 0x0400753D RID: 30013
		public Transform m_SpeakPanel = null;
	}
}
