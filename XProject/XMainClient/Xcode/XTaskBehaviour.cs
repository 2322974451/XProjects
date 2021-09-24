using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XTaskBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Close = (base.transform.Find("Bg/Close").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.Find("Bg/Right/Panel/RewardList/ItemTpl");
			this.m_ItemPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_Tabs.SetTabTpl(base.transform.Find("Bg/TabList/TabTpl"));
			transform = base.transform.Find("Bg/Left/TaskTpl");
			this.m_TasksPool.SetupPool(transform.parent.gameObject, transform.gameObject, 3U, false);
			this.m_SelectTask = base.transform.Find("Bg/Left/Select").gameObject;
			this.m_SelectTaskLabel = (this.m_SelectTask.transform.Find("SelectedTextLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_Target = (base.transform.Find("Bg/Right/Panel/Target").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_Description = (base.transform.Find("Bg/Right/Panel/Description").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this.m_TaskListScrollView = (base.transform.Find("Bg/Left").GetComponent("XUIScrollView") as IXUIScrollView);
			this.m_BtnGo = (base.transform.Find("Bg/Right/BtnGo").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnReward = (base.transform.Find("Bg/Right/BtnReward").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUISprite m_Close;

		public IXUILabelSymbol m_Target;

		public IXUILabelSymbol m_Description;

		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public XUITabControl m_Tabs = new XUITabControl();

		public XUIPool m_TasksPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		public GameObject m_SelectTask;

		public IXUILabel m_SelectTaskLabel;

		public IXUIScrollView m_TaskListScrollView;

		public IXUIButton m_BtnGo;

		public IXUIButton m_BtnReward;
	}
}
