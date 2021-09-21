using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001841 RID: 6209
	internal class XShowGetItemUIBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010216 RID: 66070 RVA: 0x003DC350 File Offset: 0x003DA550
		private void Awake()
		{
			this.m_itemTpl = base.transform.FindChild("Bg/TipTpl/ItemTpl").gameObject;
			this.m_ShowItemPool.SetupPool(this.m_itemTpl.transform.parent.gameObject, this.m_itemTpl, 4U, false);
			this.m_sprBgTip = (base.transform.FindChild("Bg/TipTpl").GetComponent("XUISprite") as IXUISprite);
			this.m_tweenBg = (base.transform.Find("Bg/TipTpl").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_tweener = (base.transform.Find("Bg/TipTpl").GetComponent("XUITweener") as IXUITweener);
		}

		// Token: 0x0400731D RID: 29469
		public XUIPool m_ShowItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x0400731E RID: 29470
		public GameObject m_itemTpl;

		// Token: 0x0400731F RID: 29471
		public IXUISprite m_sprBgTip;

		// Token: 0x04007320 RID: 29472
		public IXUITweenTool m_tweenBg;

		// Token: 0x04007321 RID: 29473
		public IXUITweener m_tweener;
	}
}
