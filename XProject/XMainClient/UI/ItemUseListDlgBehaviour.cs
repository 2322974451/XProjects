using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018CE RID: 6350
	internal class ItemUseListDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x060108DC RID: 67804 RVA: 0x004115F4 File Offset: 0x0040F7F4
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/Title/Label");
			this.m_Title = (transform.GetComponent("XUILabel") as IXUILabel);
			transform = base.transform.FindChild("Bg/Close");
			this.m_Close = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg");
			this.m_Bg = (transform.GetComponent("XUISprite") as IXUISprite);
			transform = base.transform.Find("Bg/ScrollView");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			transform = base.transform.Find("Bg/ScrollView/WrapContent");
			this.m_WrapContent = (transform.GetComponent("XUIWrapContent") as IXUIWrapContent);
		}

		// Token: 0x040077E6 RID: 30694
		public IXUILabel m_Title = null;

		// Token: 0x040077E7 RID: 30695
		public IXUISprite m_Bg = null;

		// Token: 0x040077E8 RID: 30696
		public IXUISprite m_Close = null;

		// Token: 0x040077E9 RID: 30697
		public IXUIWrapContent m_WrapContent;

		// Token: 0x040077EA RID: 30698
		public IXUIScrollView m_ScrollView;
	}
}
