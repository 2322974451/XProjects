using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000C93 RID: 3219
	internal class RandomGiftBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600B5DC RID: 46556 RVA: 0x0024000C File Offset: 0x0023E20C
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_Share = (base.transform.FindChild("Share").GetComponent("XUIButton") as IXUIButton);
			this.m_WX = base.transform.FindChild("WX");
			this.m_WXFriend = (this.m_WX.FindChild("WXFriend").GetComponent("XUIButton") as IXUIButton);
			this.m_WXTimeline = (this.m_WX.FindChild("WXTimeline").GetComponent("XUIButton") as IXUIButton);
			this.m_QQ = base.transform.FindChild("QQ");
			this.m_QQFriend = (this.m_QQ.FindChild("QQFriend").GetComponent("XUIButton") as IXUIButton);
			this.m_QQZone = (this.m_QQ.FindChild("QQZone").GetComponent("XUIButton") as IXUIButton);
			this.m_Title = (base.transform.FindChild("Title").GetComponent("XUILabel") as IXUILabel);
			this.m_Description = (base.transform.FindChild("Description").GetComponent("XUILabel") as IXUILabel);
			this.m_BoxQQ = base.transform.FindChild("BoxQQ");
			this.m_BoxWX = base.transform.FindChild("BoxWX");
		}

		// Token: 0x0400473C RID: 18236
		public IXUIButton m_Close;

		// Token: 0x0400473D RID: 18237
		public IXUIButton m_Share;

		// Token: 0x0400473E RID: 18238
		public Transform m_WX;

		// Token: 0x0400473F RID: 18239
		public IXUIButton m_WXFriend;

		// Token: 0x04004740 RID: 18240
		public IXUIButton m_WXTimeline;

		// Token: 0x04004741 RID: 18241
		public Transform m_QQ;

		// Token: 0x04004742 RID: 18242
		public IXUIButton m_QQFriend;

		// Token: 0x04004743 RID: 18243
		public IXUIButton m_QQZone;

		// Token: 0x04004744 RID: 18244
		public IXUILabel m_Title;

		// Token: 0x04004745 RID: 18245
		public IXUILabel m_Description;

		// Token: 0x04004746 RID: 18246
		public Transform m_BoxQQ;

		// Token: 0x04004747 RID: 18247
		public Transform m_BoxWX;
	}
}
