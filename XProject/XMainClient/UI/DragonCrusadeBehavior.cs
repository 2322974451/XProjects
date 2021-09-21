using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001737 RID: 5943
	internal class DragonCrusadeBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F571 RID: 62833 RVA: 0x00376854 File Offset: 0x00374A54
		private void Awake()
		{
			this.m_closed = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_myRankSpr = (base.transform.FindChild("Bg/MyRank").GetComponent("XUISprite") as IXUISprite);
			this.m_leftBtn = (base.transform.FindChild("Bg/Left").GetComponent("XUIButton") as IXUIButton);
			this.m_rightBtn = (base.transform.FindChild("Bg/Right").GetComponent("XUIButton") as IXUIButton);
			this.slideSprite = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.mMyRank = base.transform.Find("Bg/MyRank/My").gameObject;
			this.goLoading = base.transform.Find("Loading").gameObject;
			this.goLoadingTxt = (base.transform.FindChild("Loading/Bg/Slogan").GetComponent("XUILabel") as IXUILabel);
			this.goLoading.SetActive(false);
			this.m_Help = (base.transform.Find("Help").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04006A57 RID: 27223
		public IXUIButton m_Help;

		// Token: 0x04006A58 RID: 27224
		public IXUISprite slideSprite = null;

		// Token: 0x04006A59 RID: 27225
		public GameObject goLoading = null;

		// Token: 0x04006A5A RID: 27226
		public IXUILabel goLoadingTxt = null;

		// Token: 0x04006A5B RID: 27227
		public GameObject mMyRank = null;

		// Token: 0x04006A5C RID: 27228
		public IXUIButton m_closed = null;

		// Token: 0x04006A5D RID: 27229
		public IXUIButton m_leftBtn = null;

		// Token: 0x04006A5E RID: 27230
		public IXUIButton m_rightBtn = null;

		// Token: 0x04006A5F RID: 27231
		public IXUISprite m_myRankSpr = null;
	}
}
