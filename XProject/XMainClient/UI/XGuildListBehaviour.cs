using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x020018B2 RID: 6322
	internal class XGuildListBehaviour : DlgBehaviourBase
	{
		// Token: 0x060107B3 RID: 67507 RVA: 0x00409068 File Offset: 0x00407268
		private void Awake()
		{
			this.m_Close = (base.transform.FindChild("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.m_ScrollView = (base.transform.FindChild("Bg/Panel").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_WrapContent = (base.transform.FindChild("Bg/Panel/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.m_Create = (base.transform.FindChild("Bg/Create").GetComponent("XUIButton") as IXUIButton);
			this.m_QuickJoin = (base.transform.FindChild("Bg/QuickJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_Search = (base.transform.FindChild("Bg/Search").GetComponent("XUIButton") as IXUIButton);
			this.m_SearchText = (base.transform.FindChild("Bg/SearchText").GetComponent("XUIInput") as IXUIInput);
			this.m_CreatePanel = base.transform.FindChild("Bg/CreatePanel").gameObject;
			Transform transform = base.transform.FindChild("Bg/HelpList");
			int i = 0;
			int childCount = transform.childCount;
			while (i < childCount)
			{
				Transform child = transform.GetChild(i);
				this.m_helpList.Add(child.GetComponent("XUIButton") as IXUIButton, child.name);
				i++;
			}
			Transform transform2 = base.transform.FindChild("Bg/Titles");
			DlgHandlerBase.EnsureCreate<XTitleBar>(ref this.m_TitleBar, transform2.gameObject, null, true);
		}

		// Token: 0x04007717 RID: 30487
		public IXUIButton m_Close = null;

		// Token: 0x04007718 RID: 30488
		public IXUIWrapContent m_WrapContent;

		// Token: 0x04007719 RID: 30489
		public IXUIScrollView m_ScrollView;

		// Token: 0x0400771A RID: 30490
		public IXUIButton m_Create;

		// Token: 0x0400771B RID: 30491
		public IXUIButton m_QuickJoin;

		// Token: 0x0400771C RID: 30492
		public IXUIButton m_Search;

		// Token: 0x0400771D RID: 30493
		public IXUIInput m_SearchText;

		// Token: 0x0400771E RID: 30494
		public GameObject m_CreatePanel;

		// Token: 0x0400771F RID: 30495
		public XTitleBar m_TitleBar;

		// Token: 0x04007720 RID: 30496
		public Dictionary<IXUIButton, string> m_helpList = new Dictionary<IXUIButton, string>();
	}
}
