using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x0200179F RID: 6047
	internal class XActivityInviteBehavior : DlgBehaviourBase
	{
		// Token: 0x0600F9D2 RID: 63954 RVA: 0x003992A4 File Offset: 0x003974A4
		private void Awake()
		{
			Transform transform = base.transform.FindChild("Bg/BtnAddFriendMiddle");
			this.AddFriendBtn = (transform.GetComponent("XUIButton") as IXUIButton);
			this.JoinGuildBtn = (base.transform.Find("Bg/BtnJoinGuild").GetComponent("XUIButton") as IXUIButton);
			this.ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.Tabs = base.transform.FindChild("Tabs");
			this.Close = (base.transform.FindChild("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			this.EmptyFlag = base.transform.FindChild("Bg/Empty");
			this.FriendText = (base.transform.FindChild("Bg/Text").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x04006D5F RID: 27999
		public IXUIButton AddFriendBtn;

		// Token: 0x04006D60 RID: 28000
		public IXUIButton JoinGuildBtn;

		// Token: 0x04006D61 RID: 28001
		public IXUIScrollView ScrollView;

		// Token: 0x04006D62 RID: 28002
		public IXUIWrapContent WrapContent;

		// Token: 0x04006D63 RID: 28003
		public Transform Tabs;

		// Token: 0x04006D64 RID: 28004
		public IXUISprite Close;

		// Token: 0x04006D65 RID: 28005
		public Transform EmptyFlag;

		// Token: 0x04006D66 RID: 28006
		public IXUILabel FriendText;
	}
}
