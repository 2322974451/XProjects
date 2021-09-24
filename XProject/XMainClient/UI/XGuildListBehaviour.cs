using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XGuildListBehaviour : DlgBehaviourBase
	{

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

		public IXUIButton m_Close = null;

		public IXUIWrapContent m_WrapContent;

		public IXUIScrollView m_ScrollView;

		public IXUIButton m_Create;

		public IXUIButton m_QuickJoin;

		public IXUIButton m_Search;

		public IXUIInput m_SearchText;

		public GameObject m_CreatePanel;

		public XTitleBar m_TitleBar;

		public Dictionary<IXUIButton, string> m_helpList = new Dictionary<IXUIButton, string>();
	}
}
