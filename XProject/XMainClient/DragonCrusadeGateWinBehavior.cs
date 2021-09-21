using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BE6 RID: 3046
	internal class DragonCrusadeGateWinBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AD92 RID: 44434 RVA: 0x00203BE4 File Offset: 0x00201DE4
		private void Awake()
		{
			this.m_ContinueBtn = (base.transform.FindChild("Win/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_ReturnSpr = (base.transform.FindChild("Failed/Bg/Return").GetComponent("XUISprite") as IXUISprite);
			this.m_ShareBtn = (base.transform.FindChild("Win/Share").GetComponent("XUIButton") as IXUIButton);
			this.goWin = base.transform.Find("Win").gameObject;
			this.goFailed = base.transform.Find("Failed").gameObject;
			this.m_WinPool.SetupPool(base.transform.FindChild("Win/Next").gameObject, base.transform.FindChild("Win/Next/Item").gameObject, 5U, false);
			this.m_WinFrame = (base.transform.FindChild("Win/Next").GetComponent("XUISprite") as IXUISprite);
			this.m_FailedPool.SetupPool(base.transform.FindChild("Failed/Bg/ItemList").gameObject, base.transform.FindChild("Failed/Bg/ItemList/Item").gameObject, 5U, false);
			this.m_FailedFrame = (base.transform.FindChild("Failed/Bg/ItemList").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x04004167 RID: 16743
		public GameObject goWin = null;

		// Token: 0x04004168 RID: 16744
		public GameObject goFailed = null;

		// Token: 0x04004169 RID: 16745
		public XUIPool m_WinPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400416A RID: 16746
		public XUIPool m_FailedPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400416B RID: 16747
		public IXUISprite m_FailedFrame = null;

		// Token: 0x0400416C RID: 16748
		public IXUISprite m_WinFrame = null;

		// Token: 0x0400416D RID: 16749
		public IXUIButton m_ContinueBtn;

		// Token: 0x0400416E RID: 16750
		public IXUISprite m_ReturnSpr;

		// Token: 0x0400416F RID: 16751
		public IXUIButton m_ShareBtn;
	}
}
