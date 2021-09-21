using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C87 RID: 3207
	internal class ProfessionChangeBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B526 RID: 46374 RVA: 0x0023A77C File Offset: 0x0023897C
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/Tabs/Tpl");
			this.m_TabPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.transform.Find("Bg/Right/Star/Tpl");
			this.m_StarPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = base.transform.Find("Bg/Right");
			this.m_ProfName = (transform.Find("Name").GetComponent("XUILabel") as IXUILabel);
			this.m_ProfIcon = (transform.Find("Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_Texture = (transform.Find("Texture").GetComponent("XUITexture") as IXUITexture);
			this.m_Desc = (transform.Find("Desc").GetComponent("XUILabel") as IXUILabel);
			this.m_TryProfBtn = (transform.Find("TryProfBtn").GetComponent("XUIButton") as IXUIButton);
			this.m_ChangeProfBtn = (transform.Find("ChangeProfBtn").GetComponent("XUIButton") as IXUIButton);
			transform = base.transform.Find("Bg/TipsWindow");
			this.m_TipsWindow = transform.gameObject;
			this.m_TipsClose = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_TipsType = (transform.Find("TypeTips").GetComponent("XUILabel") as IXUILabel);
			this.m_TipsDesc = (transform.Find("Text/Desc/T").GetComponent("XUILabel") as IXUILabel);
			this.m_TextScrollView = (transform.Find("Text/Desc").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_TipsUse = (transform.Find("Use/T").GetComponent("XUILabel") as IXUILabel);
			this.m_GetPathBtn = (transform.Find("GetPath").GetComponent("XUISprite") as IXUISprite);
			this.m_OKBtn = (transform.Find("OK").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x040046A5 RID: 18085
		public IXUIButton m_Close;

		// Token: 0x040046A6 RID: 18086
		public XUIPool m_TabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040046A7 RID: 18087
		public XUIPool m_StarPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x040046A8 RID: 18088
		public IXUILabel m_ProfName;

		// Token: 0x040046A9 RID: 18089
		public IXUISprite m_ProfIcon;

		// Token: 0x040046AA RID: 18090
		public IXUITexture m_Texture;

		// Token: 0x040046AB RID: 18091
		public IXUILabel m_Desc;

		// Token: 0x040046AC RID: 18092
		public IXUIButton m_TryProfBtn;

		// Token: 0x040046AD RID: 18093
		public IXUIButton m_ChangeProfBtn;

		// Token: 0x040046AE RID: 18094
		public GameObject m_TipsWindow;

		// Token: 0x040046AF RID: 18095
		public IXUIButton m_TipsClose;

		// Token: 0x040046B0 RID: 18096
		public IXUILabel m_TipsType;

		// Token: 0x040046B1 RID: 18097
		public IXUILabel m_TipsDesc;

		// Token: 0x040046B2 RID: 18098
		public IXUIScrollView m_TextScrollView;

		// Token: 0x040046B3 RID: 18099
		public IXUILabel m_TipsUse;

		// Token: 0x040046B4 RID: 18100
		public IXUISprite m_GetPathBtn;

		// Token: 0x040046B5 RID: 18101
		public IXUIButton m_OKBtn;
	}
}
