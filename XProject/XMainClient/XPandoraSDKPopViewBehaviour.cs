using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C62 RID: 3170
	internal class XPandoraSDKPopViewBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B389 RID: 45961 RVA: 0x0022F332 File Offset: 0x0022D532
		private void Awake()
		{
			this.m_Close = (base.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
		}

		// Token: 0x0400458B RID: 17803
		public IXUISprite m_Close;
	}
}
