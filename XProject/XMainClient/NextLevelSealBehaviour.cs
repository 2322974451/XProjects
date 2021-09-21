using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000C47 RID: 3143
	internal class NextLevelSealBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B255 RID: 45653 RVA: 0x002265F8 File Offset: 0x002247F8
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_NextSealLabel = (base.transform.Find("Bg/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_NextSealTexL = (base.transform.Find("Bg/TexL").GetComponent("XUITexture") as IXUITexture);
			this.m_NextSealTexR = (base.transform.Find("Bg/TexR").GetComponent("XUITexture") as IXUITexture);
			this.m_NextSealTexM = (base.transform.Find("Bg/TexM").GetComponent("XUITexture") as IXUITexture);
			this.m_NewFunction = base.transform.Find("Bg/NewFunction");
			this.m_NewFunctionBg = (base.transform.Find("Bg/NewFunction/Bg").GetComponent("XUISprite") as IXUISprite);
			this.m_NewFunctionBgWidth = this.m_NewFunctionBg.spriteWidth;
			Transform transform = base.transform.Find("Bg/NewFunction/NewFunction/FunctionTpl");
			this.m_NewFunctionPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
		}

		// Token: 0x040044B4 RID: 17588
		public IXUIButton m_Close;

		// Token: 0x040044B5 RID: 17589
		public IXUILabel m_NextSealLabel;

		// Token: 0x040044B6 RID: 17590
		public IXUITexture m_NextSealTexL;

		// Token: 0x040044B7 RID: 17591
		public IXUITexture m_NextSealTexR;

		// Token: 0x040044B8 RID: 17592
		public IXUITexture m_NextSealTexM;

		// Token: 0x040044B9 RID: 17593
		public Transform m_NewFunction;

		// Token: 0x040044BA RID: 17594
		public IXUISprite m_NewFunctionBg;

		// Token: 0x040044BB RID: 17595
		public int m_NewFunctionBgWidth;

		// Token: 0x040044BC RID: 17596
		public XUIPool m_NewFunctionPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
