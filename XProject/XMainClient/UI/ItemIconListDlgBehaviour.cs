using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018CA RID: 6346
	internal class ItemIconListDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x060108C0 RID: 67776 RVA: 0x00410F44 File Offset: 0x0040F144
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Title");
			this.m_Title = (transform.GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Close");
			this.m_Close = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg");
			this.m_Bg = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg/MinFrame");
			this.m_MinFrame = (transform.GetComponent("XUISprite") as IXUISprite);
			this.m_ItemPool.SetupPool(base.transform.FindChild("Bg/ListPanel").gameObject, base.transform.FindChild("Bg/ListPanel/ItemTpl").gameObject, 3U, false);
			this.m_BorderWidth = this.m_Bg.spriteWidth - this.m_MinFrame.spriteWidth;
			this.m_Arrow = base.transform.Find("Bg/Arrow");
			this.m_ArrowDown = base.transform.Find("Bg/ArrowDown");
			this.m_Split = (base.transform.Find("Bg/Split").GetComponent("XUISprite") as IXUISprite);
			this.m_SplitPos = base.transform.Find("Bg/Split/Sprite");
		}

		// Token: 0x040077D3 RID: 30675
		public IXUILabel m_Title = null;

		// Token: 0x040077D4 RID: 30676
		public IXUISprite m_Bg = null;

		// Token: 0x040077D5 RID: 30677
		public IXUISprite m_Close = null;

		// Token: 0x040077D6 RID: 30678
		public IXUISprite m_MinFrame = null;

		// Token: 0x040077D7 RID: 30679
		public Transform m_Arrow = null;

		// Token: 0x040077D8 RID: 30680
		public Transform m_ArrowDown = null;

		// Token: 0x040077D9 RID: 30681
		public IXUISprite m_Split = null;

		// Token: 0x040077DA RID: 30682
		public Transform m_SplitPos = null;

		// Token: 0x040077DB RID: 30683
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040077DC RID: 30684
		public int m_BorderWidth;
	}
}
