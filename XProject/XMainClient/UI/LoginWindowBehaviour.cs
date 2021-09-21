using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x020018B9 RID: 6329
	internal class LoginWindowBehaviour : DlgBehaviourBase
	{
		// Token: 0x060107EA RID: 67562 RVA: 0x0040A2CC File Offset: 0x004084CC
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

		// Token: 0x0400773C RID: 30524
		public GameObject m_normalFrame;

		// Token: 0x0400773D RID: 30525
		public GameObject m_ServerListFrame;

		// Token: 0x0400773E RID: 30526
		public GameObject m_QueueFrame;

		// Token: 0x0400773F RID: 30527
		public IXUIInput m_Account;

		// Token: 0x04007740 RID: 30528
		public IXUIInput m_Password;

		// Token: 0x04007741 RID: 30529
		public IXUIButton m_Login;

		// Token: 0x04007742 RID: 30530
		public IXUIButton m_GuestLogin;

		// Token: 0x04007743 RID: 30531
		public IXUIButton m_QQLogin;

		// Token: 0x04007744 RID: 30532
		public IXUIButton m_WXLogin;

		// Token: 0x04007745 RID: 30533
		public IXUITweenTool m_Tween;

		// Token: 0x04007746 RID: 30534
		public IXUITweenTool m_SelectPlatformTween;

		// Token: 0x04007747 RID: 30535
		public Transform m_BlockWindow;

		// Token: 0x04007748 RID: 30536
		public IXUILabel m_Version;

		// Token: 0x04007749 RID: 30537
		public IXUIButton m_Notice;

		// Token: 0x0400774A RID: 30538
		public IXUIButton m_CG;

		// Token: 0x0400774B RID: 30539
		public IXUIButton m_CustomerService;

		// Token: 0x0400774C RID: 30540
		public IXUIButton m_EnterToSelectChar;

		// Token: 0x0400774D RID: 30541
		public IXUIButton m_ReturnToLogin;

		// Token: 0x0400774E RID: 30542
		public IXUISprite m_ServerListButton;

		// Token: 0x0400774F RID: 30543
		public IXUILabel m_CurrentServer;

		// Token: 0x04007750 RID: 30544
		public Transform m_ServerList;

		// Token: 0x04007751 RID: 30545
		public IXUISprite m_CloseServerList;

		// Token: 0x04007752 RID: 30546
		public XUIPool m_AreaPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007753 RID: 30547
		public IXUIScrollView m_AreaScrollView;

		// Token: 0x04007754 RID: 30548
		public XUIPool m_ServerPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007755 RID: 30549
		public IXUIScrollView m_ServerScrollView;

		// Token: 0x04007756 RID: 30550
		public IXUIWrapContent m_FriendWrapContent;

		// Token: 0x04007757 RID: 30551
		public IXUIScrollView m_FriendScrollView;

		// Token: 0x04007758 RID: 30552
		public Transform m_ServerFrame;

		// Token: 0x04007759 RID: 30553
		public Transform m_FriendFrame;

		// Token: 0x0400775A RID: 30554
		public IXUILabel m_QueueTip;

		// Token: 0x0400775B RID: 30555
		public IXUIButton m_LeaveQueue;
	}
}
