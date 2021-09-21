using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000E30 RID: 3632
	internal class XFriendsBlockBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C33B RID: 49979 RVA: 0x002A37C8 File Offset: 0x002A19C8
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
		}

		// Token: 0x04005439 RID: 21561
		public IXUIButton m_Close;

		// Token: 0x0400543A RID: 21562
		public static readonly uint FUNCTION_NUM = 3U;
	}
}
