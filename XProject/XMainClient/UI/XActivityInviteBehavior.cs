using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XActivityInviteBehavior : DlgBehaviourBase
	{

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

		public IXUIButton AddFriendBtn;

		public IXUIButton JoinGuildBtn;

		public IXUIScrollView ScrollView;

		public IXUIWrapContent WrapContent;

		public Transform Tabs;

		public IXUISprite Close;

		public Transform EmptyFlag;

		public IXUILabel FriendText;
	}
}
