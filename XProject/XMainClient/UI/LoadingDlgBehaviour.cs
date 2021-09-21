using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001922 RID: 6434
	internal class LoadingDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010DA0 RID: 69024 RVA: 0x00442DAC File Offset: 0x00440FAC
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Dynamics/LoadingProgress");
			this.m_LoadingProgress = (transform.GetComponent("XUIProgress") as IXUIProgress);
			this.m_Dog = (transform.FindChild("Dog/").GetComponent("XUISprite") as IXUISprite);
			this.m_Canvas = base.transform.FindChild("fade_canvas");
			this.m_LoadingTips = (base.transform.FindChild("Bg/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_LoadingBg = base.transform.FindChild("Bg");
			this.m_LoadingPic = (base.transform.FindChild("Bg").GetComponent("XUITexture") as IXUITexture);
			this.m_WaitForOthersTip = (base.transform.Find("Bg/WaitOthers").GetComponent("XUILabel") as IXUILabel);
			this.m_Canvas.gameObject.SetActive(false);
		}

		// Token: 0x04007BF2 RID: 31730
		public IXUIProgress m_LoadingProgress = null;

		// Token: 0x04007BF3 RID: 31731
		public Transform m_LoadingBg = null;

		// Token: 0x04007BF4 RID: 31732
		public Transform m_Canvas = null;

		// Token: 0x04007BF5 RID: 31733
		public IXUILabel m_LoadingTips = null;

		// Token: 0x04007BF6 RID: 31734
		public IXUITexture m_LoadingPic = null;

		// Token: 0x04007BF7 RID: 31735
		public IXUILabel m_WaitForOthersTip = null;

		// Token: 0x04007BF8 RID: 31736
		public IXUISprite m_Dog = null;
	}
}
