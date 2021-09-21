using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C29 RID: 3113
	internal class HeroBattleMVPBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B066 RID: 45158 RVA: 0x0021AC50 File Offset: 0x00218E50
		private void Awake()
		{
			this.m_Name = (base.transform.Find("Bg/Board/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_Kill = (base.transform.Find("Bg/Board/Kill").GetComponent("XUILabel") as IXUILabel);
			this.m_Death = (base.transform.Find("Bg/Board/Death").GetComponent("XUILabel") as IXUILabel);
			this.m_Assit = (base.transform.Find("Bg/Board/Help").GetComponent("XUILabel") as IXUILabel);
			this.m_ShareBtn = (base.transform.Find("Bg/ShareBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.LogoWC = base.transform.Find("Bg/LogoWC").gameObject;
			this.LogoQQ = base.transform.Find("Bg/LogoQQ").gameObject;
			this.LogoDN = base.transform.Find("Bg/p").gameObject;
			this.LogoTX = base.transform.Find("Bg/gg").gameObject;
			this.m_HeroName = (base.transform.Find("Bg/Board/HeroName").GetComponent("XUILabel") as IXUILabel);
			this.m_HeroDesc = (base.transform.Find("Bg/Board/Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_HeroSay = (base.transform.Find("Bg/Board/Say").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040043C8 RID: 17352
		public IXUILabel m_Name;

		// Token: 0x040043C9 RID: 17353
		public IXUILabel m_Kill;

		// Token: 0x040043CA RID: 17354
		public IXUILabel m_Death;

		// Token: 0x040043CB RID: 17355
		public IXUILabel m_Assit;

		// Token: 0x040043CC RID: 17356
		public IXUIButton m_ShareBtn;

		// Token: 0x040043CD RID: 17357
		public IXUISprite m_Close;

		// Token: 0x040043CE RID: 17358
		public GameObject LogoWC;

		// Token: 0x040043CF RID: 17359
		public GameObject LogoQQ;

		// Token: 0x040043D0 RID: 17360
		public GameObject LogoDN;

		// Token: 0x040043D1 RID: 17361
		public GameObject LogoTX;

		// Token: 0x040043D2 RID: 17362
		public IXUILabel m_HeroName;

		// Token: 0x040043D3 RID: 17363
		public IXUILabel m_HeroDesc;

		// Token: 0x040043D4 RID: 17364
		public IXUILabel m_HeroSay;
	}
}
