using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020017EE RID: 6126
	internal class PandoraBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600FDEE RID: 65006 RVA: 0x003B97BC File Offset: 0x003B79BC
		private void Awake()
		{
			this.m_DisplayFrame = base.transform.Find("Bg/DisplayFrame");
			this.m_RewardFrame = base.transform.Find("Bg/RewardFrame");
			this.m_FxPoint = base.transform.Find("Bg/FxPoint");
			this.m_OnceButton = (this.m_DisplayFrame.Find("Once").GetComponent("XUIButton") as IXUIButton);
			this.m_TenButton = (this.m_DisplayFrame.Find("Ten").GetComponent("XUIButton") as IXUIButton);
			for (int i = 0; i < 3; i++)
			{
				this.m_DisplayLabel[i] = (this.m_DisplayFrame.Find(string.Format("Display{0}/Label", i)).GetComponent("XUILabel") as IXUILabel);
				this.m_DisplayPoint[i] = (this.m_DisplayFrame.Find(string.Format("Display{0}/Bg/Point", i)).GetComponent("XUISprite") as IXUISprite);
				this.m_DisplayAvatar[i] = (this.m_DisplayFrame.Find(string.Format("Display{0}/Bg/avatar", i)).GetComponent("UIDummy") as IUIDummy);
			}
			this.m_BackButton = (this.m_DisplayFrame.Find("Back").GetComponent("XUISprite") as IXUISprite);
			this.m_ItemListButton = (this.m_DisplayFrame.Find("ItemList").GetComponent("XUIButton") as IXUIButton);
			this.m_OKButton = (this.m_RewardFrame.Find("OK").GetComponent("XUIButton") as IXUIButton);
			Transform transform = this.m_RewardFrame.Find("ResultTpl");
			this.m_ResultPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
		}

		// Token: 0x04007013 RID: 28691
		public Transform m_DisplayFrame;

		// Token: 0x04007014 RID: 28692
		public Transform m_RewardFrame;

		// Token: 0x04007015 RID: 28693
		public Transform m_FxPoint;

		// Token: 0x04007016 RID: 28694
		public IXUIButton m_OnceButton;

		// Token: 0x04007017 RID: 28695
		public IXUIButton m_TenButton;

		// Token: 0x04007018 RID: 28696
		public IXUILabel[] m_DisplayLabel = new IXUILabel[3];

		// Token: 0x04007019 RID: 28697
		public IXUISprite[] m_DisplayPoint = new IXUISprite[3];

		// Token: 0x0400701A RID: 28698
		public IUIDummy[] m_DisplayAvatar = new IUIDummy[3];

		// Token: 0x0400701B RID: 28699
		public IXUISprite m_BackButton;

		// Token: 0x0400701C RID: 28700
		public IXUIButton m_ItemListButton;

		// Token: 0x0400701D RID: 28701
		public IXUIButton m_OKButton;

		// Token: 0x0400701E RID: 28702
		public XUIPool m_ResultPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
