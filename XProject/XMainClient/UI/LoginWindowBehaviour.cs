using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class LoginWindowBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_normalFrame = base.transform.FindChild("Bg/NormalFrame").gameObject;
			this.m_ServerListFrame = base.transform.Find("Bg/SelectServerFrame").gameObject;
			this.m_QueueFrame = base.transform.Find("Bg/Queue").gameObject;
			this.m_Tween = (this.m_normalFrame.GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_Account = (this.m_normalFrame.transform.FindChild("iptAccount").GetComponent("XUIInput") as IXUIInput);
			this.m_Password = (this.m_normalFrame.transform.FindChild("iptPassword").GetComponent("XUIInput") as IXUIInput);
			this.m_Login = (this.m_normalFrame.transform.FindChild("SelectPlatform/btnLogin").GetComponent("XUIButton") as IXUIButton);
			this.m_GuestLogin = (this.m_normalFrame.transform.Find("SelectPlatform/btnGuest").GetComponent("XUIButton") as IXUIButton);
			this.m_QQLogin = (this.m_normalFrame.transform.Find("SelectPlatform/btnQQ").GetComponent("XUIButton") as IXUIButton);
			this.m_WXLogin = (this.m_normalFrame.transform.Find("SelectPlatform/btnWX").GetComponent("XUIButton") as IXUIButton);
			this.m_SelectPlatformTween = (this.m_normalFrame.transform.FindChild("SelectPlatform").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_BlockWindow = base.transform.FindChild("Bg/Block");
			this.m_Version = (base.transform.FindChild("Bg/Version").GetComponent("XUILabel") as IXUILabel);
			this.m_Notice = (this.m_ServerListFrame.transform.Find("Notice").GetComponent("XUIButton") as IXUIButton);
			this.m_CG = (this.m_ServerListFrame.transform.Find("CG").GetComponent("XUIButton") as IXUIButton);
			this.m_CustomerService = (this.m_ServerListFrame.transform.Find("CustomerService").GetComponent("XUIButton") as IXUIButton);
			this.m_EnterToSelectChar = (this.m_ServerListFrame.transform.Find("Enter").GetComponent("XUIButton") as IXUIButton);
			this.m_ReturnToLogin = (this.m_ServerListFrame.transform.Find("Back").GetComponent("XUIButton") as IXUIButton);
			this.m_ServerListButton = (this.m_ServerListFrame.transform.Find("CurrentServer").GetComponent("XUISprite") as IXUISprite);
			this.m_CurrentServer = (this.m_ServerListFrame.transform.Find("CurrentServer/Label").GetComponent("XUILabel") as IXUILabel);
			this.m_ServerList = this.m_ServerListFrame.transform.Find("SelectServer");
			this.m_CloseServerList = (this.m_ServerListFrame.transform.Find("SelectServer/Close").GetComponent("XUISprite") as IXUISprite);
			this.m_AreaScrollView = (this.m_ServerListFrame.transform.Find("SelectServer/AreaList").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_ServerScrollView = (this.m_ServerListFrame.transform.Find("SelectServer/ServerList").GetComponent("XUIScrollView") as IXUIScrollView);
			Transform transform = this.m_ServerListFrame.transform.Find("SelectServer/AreaList/AreaTpl");
			this.m_AreaPool.SetupPool(transform.parent.gameObject, transform.gameObject, 5U, false);
			transform = this.m_ServerListFrame.transform.Find("SelectServer/ServerList/ServerTpl");
			this.m_ServerPool.SetupPool(transform.parent.gameObject, transform.gameObject, 10U, false);
			this.m_FriendScrollView = (this.m_ServerListFrame.transform.Find("SelectServer/FriendList").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_FriendWrapContent = (this.m_ServerListFrame.transform.Find("SelectServer/FriendList/List").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_ServerFrame = this.m_ServerListFrame.transform.Find("SelectServer/ServerList");
			this.m_FriendFrame = this.m_ServerListFrame.transform.Find("SelectServer/FriendList");
			this.m_QueueTip = (this.m_QueueFrame.transform.Find("Tip").GetComponent("XUILabel") as IXUILabel);
			this.m_LeaveQueue = (this.m_QueueFrame.transform.Find("Leave").GetComponent("XUIButton") as IXUIButton);
			this.m_normalFrame.SetActive(false);
			this.m_ServerListFrame.SetActive(false);
			this.m_QueueFrame.SetActive(false);
			this.m_BlockWindow.gameObject.SetActive(false);
		}

		public GameObject m_normalFrame;

		public GameObject m_ServerListFrame;

		public GameObject m_QueueFrame;

		public IXUIInput m_Account;

		public IXUIInput m_Password;

		public IXUIButton m_Login;

		public IXUIButton m_GuestLogin;

		public IXUIButton m_QQLogin;

		public IXUIButton m_WXLogin;

		public IXUITweenTool m_Tween;

		public IXUITweenTool m_SelectPlatformTween;

		public Transform m_BlockWindow;

		public IXUILabel m_Version;

		public IXUIButton m_Notice;

		public IXUIButton m_CG;

		public IXUIButton m_CustomerService;

		public IXUIButton m_EnterToSelectChar;

		public IXUIButton m_ReturnToLogin;

		public IXUISprite m_ServerListButton;

		public IXUILabel m_CurrentServer;

		public Transform m_ServerList;

		public IXUISprite m_CloseServerList;

		public XUIPool m_AreaPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_AreaScrollView;

		public XUIPool m_ServerPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public IXUIScrollView m_ServerScrollView;

		public IXUIWrapContent m_FriendWrapContent;

		public IXUIScrollView m_FriendScrollView;

		public Transform m_ServerFrame;

		public Transform m_FriendFrame;

		public IXUILabel m_QueueTip;

		public IXUIButton m_LeaveQueue;
	}
}
