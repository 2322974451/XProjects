using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XWeddingInviteBehavior : DlgBehaviourBase
	{

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

		public IXUIScrollView ScrollView;

		public IXUIWrapContent WrapContent;

		public Transform Tabs;

		public IXUIButton Close;

		public IXUICheckBox AllowStranger;

		public IXUILabel InviteNum;

		public GameObject ListRedPoint;
	}
}
