using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E38 RID: 3640
	internal class XGuildRedPacketBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C3C3 RID: 50115 RVA: 0x002A8E84 File Offset: 0x002A7084
		private void Awake()
		{
			this.m_root = base.transform.FindChild("Bg");
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Help = (base.transform.Find("Bg/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Empty = base.transform.FindChild("Bg/Empty").gameObject;
		}

		// Token: 0x040054B5 RID: 21685
		public Transform m_root;

		// Token: 0x040054B6 RID: 21686
		public IXUIButton m_Close;

		// Token: 0x040054B7 RID: 21687
		public IXUIButton m_Help;

		// Token: 0x040054B8 RID: 21688
		public IXUIScrollView m_ScrollView;

		// Token: 0x040054B9 RID: 21689
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040054BA RID: 21690
		public GameObject m_Empty;
	}
}
