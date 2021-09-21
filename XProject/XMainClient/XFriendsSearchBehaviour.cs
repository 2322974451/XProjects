using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E31 RID: 3633
	internal class XFriendsSearchBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600C33E RID: 49982 RVA: 0x002A37F8 File Offset: 0x002A19F8
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

		// Token: 0x0400543B RID: 21563
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400543C RID: 21564
		public IXUIButton m_Close;

		// Token: 0x0400543D RID: 21565
		public IXUIButton m_Refresh;

		// Token: 0x0400543E RID: 21566
		public IXUIButton m_AddFriend;

		// Token: 0x0400543F RID: 21567
		public IXUIInput m_SearchName;

		// Token: 0x04005440 RID: 21568
		public IXUILabel m_CountdownText;

		// Token: 0x04005441 RID: 21569
		public static readonly uint FUNCTION_NUM = 3U;

		// Token: 0x04005442 RID: 21570
		public XUIPool m_FriendRandomListPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
	}
}
