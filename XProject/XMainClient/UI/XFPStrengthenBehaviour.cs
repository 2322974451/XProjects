using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001896 RID: 6294
	internal class XFPStrengthenBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010630 RID: 67120 RVA: 0x003FE8CC File Offset: 0x003FCACC
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Scroll = (base.transform.FindChild("Bg/Content/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = base.transform.FindChild("Bg/Top");
			this.m_MyFightLab = (transform.FindChild("MyFightLab").GetComponent("XUILabel") as IXUILabel);
			this.m_RecommendFightLab = (transform.FindChild("RecommendFightLab").GetComponent("XUILabel") as IXUILabel);
			this.m_MyLevelLab = (transform.FindChild("RecommendFightLab/LevelLab").GetComponent("XUILabel") as IXUILabel);
			this.m_RateTex = (transform.FindChild("RateTex").GetComponent("XUITexture") as IXUITexture);
			this.m_tabParentGo = base.transform.FindChild("Bg/functions/scroll").gameObject;
		}

		// Token: 0x0400763A RID: 30266
		public GameObject m_tabParentGo;

		// Token: 0x0400763B RID: 30267
		public IXUIButton m_Close;

		// Token: 0x0400763C RID: 30268
		public IXUIScrollView m_Scroll;

		// Token: 0x0400763D RID: 30269
		public IXUILabel m_MyFightLab;

		// Token: 0x0400763E RID: 30270
		public IXUILabel m_MyLevelLab;

		// Token: 0x0400763F RID: 30271
		public IXUILabel m_RecommendFightLab;

		// Token: 0x04007640 RID: 30272
		public IXUITexture m_RateTex;

		// Token: 0x04007641 RID: 30273
		public static readonly uint FUNCTION_NUM = 4U;
	}
}
