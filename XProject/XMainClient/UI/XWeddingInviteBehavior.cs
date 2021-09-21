using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018DE RID: 6366
	internal class XWeddingInviteBehavior : DlgBehaviourBase
	{
		// Token: 0x0601096F RID: 67951 RVA: 0x00416BFC File Offset: 0x00414DFC
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/BtnAddFriendMiddle");
			this.ScrollView = (base.transform.FindChild("FriendList").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.FindChild("FriendList/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.Tabs = base.transform.FindChild("Tabs");
			this.Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.AllowStranger = (base.transform.FindChild("pp/Normal").GetComponent("XUICheckBox") as IXUICheckBox);
			this.InviteNum = (base.transform.Find("InviteNum").GetComponent("XUILabel") as IXUILabel);
			this.ListRedPoint = base.transform.Find("Tabs/item3/Bg/redpoint").gameObject;
		}

		// Token: 0x0400786D RID: 30829
		public IXUIScrollView ScrollView;

		// Token: 0x0400786E RID: 30830
		public IXUIWrapContent WrapContent;

		// Token: 0x0400786F RID: 30831
		public Transform Tabs;

		// Token: 0x04007870 RID: 30832
		public IXUIButton Close;

		// Token: 0x04007871 RID: 30833
		public IXUICheckBox AllowStranger;

		// Token: 0x04007872 RID: 30834
		public IXUILabel InviteNum;

		// Token: 0x04007873 RID: 30835
		public GameObject ListRedPoint;
	}
}
