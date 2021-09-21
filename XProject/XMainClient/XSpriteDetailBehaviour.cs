using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000CB4 RID: 3252
	internal class XSpriteDetailBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B709 RID: 46857 RVA: 0x002460C0 File Offset: 0x002442C0
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_AvatarRoot = base.transform.Find("Bg/AvatarRoot");
			this.m_AttrFrameRoot = base.transform.Find("Bg/AttrFrameRoot");
		}

		// Token: 0x040047BD RID: 18365
		public IXUIButton m_Close;

		// Token: 0x040047BE RID: 18366
		public Transform m_AvatarRoot;

		// Token: 0x040047BF RID: 18367
		public Transform m_AttrFrameRoot;
	}
}
