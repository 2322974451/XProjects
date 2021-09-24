using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XFriendsSearchBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			Transform transform = base.transform.Find("Bg/List");
			Transform transform2 = transform.Find("tpl");
			this.m_ScrollView = (transform.GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_Refresh = (base.transform.Find("Bg/change").GetComponent("XUIButton") as IXUIButton);
			this.m_AddFriend = (base.transform.Find("Bg/add").GetComponent("XUIButton") as IXUIButton);
			this.m_SearchName = (base.transform.Find("Bg/textinput").GetComponent("XUIInput") as IXUIInput);
			this.m_CountdownText = (base.transform.Find("Bg/changeLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_FriendRandomListPool.SetupPool(transform.gameObject, transform2.gameObject, 4U, false);
		}

		public IXUIScrollView m_ScrollView;

		public IXUIButton m_Close;

		public IXUIButton m_Refresh;

		public IXUIButton m_AddFriend;

		public IXUIInput m_SearchName;

		public IXUILabel m_CountdownText;

		public static readonly uint FUNCTION_NUM = 3U;

		public XUIPool m_FriendRandomListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
