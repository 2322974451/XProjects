using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CB6 RID: 3254
	internal class XSpriteShowBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B718 RID: 46872 RVA: 0x00246354 File Offset: 0x00244554
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_AvatarRoot = base.transform.Find("Bg/AvatarRoot");
			this.m_FxPoint = base.transform.Find("Bg/Fx");
			this.m_Quality = (base.transform.Find("Bg/Quality").GetComponent("XUISprite") as IXUISprite);
			this.m_QualityTween = (base.transform.Find("Bg").GetComponent("XUIPlayTween") as IXUITweenTool);
		}

		// Token: 0x040047C5 RID: 18373
		public IXUISprite m_Close;

		// Token: 0x040047C6 RID: 18374
		public Transform m_AvatarRoot;

		// Token: 0x040047C7 RID: 18375
		public Transform m_FxPoint;

		// Token: 0x040047C8 RID: 18376
		public IXUISprite m_Quality;

		// Token: 0x040047C9 RID: 18377
		public IXUITweenTool m_QualityTween;
	}
}
