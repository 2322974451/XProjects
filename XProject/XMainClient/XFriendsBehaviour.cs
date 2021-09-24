using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFriendsBehaviour : DlgBehaviourBase
	{

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

		private void OnApplicationPause(bool pause)
		{
			XDragonGuildDocument.Doc.QueryWXGroup();
		}

		public XUIPool FriendTabPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUILabel lbButtonR;

		public IXUILabel lbButtonL;

		public IXUIButton btnClose;

		public IXUIButton btnRight;

		public IXUIButton btnLeft;

		public IXUIButton btnHint;

		public IXUILabel lbFriendsNum;

		public IXUILabel lbFriendsNumLabel;

		public IXUIWrapContent FriendListWrapContent;

		public IXUIScrollView FriendListScrollView;

		public IXUIPanel FriendListPanel;

		public IXUIList TabList;

		public GameObject goFriendListTitle;

		public GameObject goFriendListZero;

		public GameObject goFriendListBrockZero;

		public Transform FriendTabTpl;

		public Transform content;

		public static readonly uint FUNCTION_NUM = 3U;
	}
}
