using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001883 RID: 6275
	internal class BattleContinueDlgBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010539 RID: 66873 RVA: 0x003F4B5C File Offset: 0x003F2D5C
		private void Awake()
		{
			this.m_Continue = (base.transform.FindChild("Bg/Continue").GetComponent("XUIButton") as IXUIButton);
			this.m_tween = (base.transform.FindChild("Bg/Continue").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Next = base.transform.FindChild("Bg/Next");
			this.m_lblNum = (this.m_Next.transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			Transform transform = base.transform.Find("Bg/Next/Item");
			this.m_NextItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
		}

		// Token: 0x04007592 RID: 30098
		public IXUIButton m_Continue;

		// Token: 0x04007593 RID: 30099
		public IXUITweenTool m_tween;

		// Token: 0x04007594 RID: 30100
		public Transform m_Next;

		// Token: 0x04007595 RID: 30101
		public IXUILabel m_lblNum;

		// Token: 0x04007596 RID: 30102
		public XUIPool m_NextItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
