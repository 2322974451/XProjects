using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E2F RID: 3631
	internal class XFriendsBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C337 RID: 49975 RVA: 0x002A3518 File Offset: 0x002A1718
		private void Awake()
		{
			Transform transform = base.transform.Find("Bg");
			this.btnClose = (transform.Find("Close").GetComponent("XUIButton") as IXUIButton);
			this.btnRight = (transform.Find("ButtonR").GetComponent("XUIButton") as IXUIButton);
			this.lbButtonR = (this.btnRight.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.btnLeft = (transform.Find("ButtonL").GetComponent("XUIButton") as IXUIButton);
			this.lbButtonL = (this.btnLeft.gameObject.transform.Find("T").GetComponent("XUILabel") as IXUILabel);
			this.btnHint = (transform.Find("Hint").GetComponent("XUIButton") as IXUIButton);
			this.lbFriendsNum = (transform.Find("FriendNum").GetComponent("XUILabel") as IXUILabel);
			this.lbFriendsNumLabel = (transform.Find("FriendNumLabel").GetComponent("XUILabel") as IXUILabel);
			this.FriendListScrollView = (transform.Find("Content/FriendList").GetComponent("XUIScrollView") as IXUIScrollView);
			this.content = transform.Find("Content");
			this.FriendListPanel = (this.FriendListScrollView.gameObject.transform.GetComponent("XUIPanel") as IXUIPanel);
			this.FriendListWrapContent = (this.FriendListScrollView.gameObject.transform.Find("WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.goFriendListZero = transform.Find("NoFriend").gameObject;
			this.goFriendListBrockZero = transform.Find("NoBlockFriend").gameObject;
			this.goFriendListTitle = transform.Find("Content/Titles").gameObject;
			this.goFriendListZero.SetActive(false);
			this.goFriendListBrockZero.SetActive(false);
			this.FriendTabTpl = transform.Find("Tabs/Tpl");
			this.FriendTabPool.SetupPool(this.FriendTabTpl.parent.gameObject, this.FriendTabTpl.gameObject, (uint)XFriendsDocument.FriendsTabCount, false);
			this.TabList = (this.FriendTabTpl.parent.GetComponent("XUIList") as IXUIList);
		}

		// Token: 0x0600C338 RID: 49976 RVA: 0x002A3794 File Offset: 0x002A1994
		private void OnApplicationPause(bool pause)
		{
			XDragonGuildDocument.Doc.QueryWXGroup();
		}

		// Token: 0x04005426 RID: 21542
		public XUIPool FriendTabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04005427 RID: 21543
		public IXUILabel lbButtonR;

		// Token: 0x04005428 RID: 21544
		public IXUILabel lbButtonL;

		// Token: 0x04005429 RID: 21545
		public IXUIButton btnClose;

		// Token: 0x0400542A RID: 21546
		public IXUIButton btnRight;

		// Token: 0x0400542B RID: 21547
		public IXUIButton btnLeft;

		// Token: 0x0400542C RID: 21548
		public IXUIButton btnHint;

		// Token: 0x0400542D RID: 21549
		public IXUILabel lbFriendsNum;

		// Token: 0x0400542E RID: 21550
		public IXUILabel lbFriendsNumLabel;

		// Token: 0x0400542F RID: 21551
		public IXUIWrapContent FriendListWrapContent;

		// Token: 0x04005430 RID: 21552
		public IXUIScrollView FriendListScrollView;

		// Token: 0x04005431 RID: 21553
		public IXUIPanel FriendListPanel;

		// Token: 0x04005432 RID: 21554
		public IXUIList TabList;

		// Token: 0x04005433 RID: 21555
		public GameObject goFriendListTitle;

		// Token: 0x04005434 RID: 21556
		public GameObject goFriendListZero;

		// Token: 0x04005435 RID: 21557
		public GameObject goFriendListBrockZero;

		// Token: 0x04005436 RID: 21558
		public Transform FriendTabTpl;

		// Token: 0x04005437 RID: 21559
		public Transform content;

		// Token: 0x04005438 RID: 21560
		public static readonly uint FUNCTION_NUM = 3U;
	}
}
