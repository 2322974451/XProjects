using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XMainClient.Utility;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000D10 RID: 3344
	internal class XTaskBehaviour : DlgBehaviourBase
	{
		// Token: 0x0600BAA9 RID: 47785 RVA: 0x002628F0 File Offset: 0x00260AF0
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

		// Token: 0x04004B0D RID: 19213
		public IXUISprite m_Close;

		// Token: 0x04004B0E RID: 19214
		public IXUILabelSymbol m_Target;

		// Token: 0x04004B0F RID: 19215
		public IXUILabelSymbol m_Description;

		// Token: 0x04004B10 RID: 19216
		public XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004B11 RID: 19217
		public XUITabControl m_Tabs = new XUITabControl();

		// Token: 0x04004B12 RID: 19218
		public XUIPool m_TasksPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04004B13 RID: 19219
		public GameObject m_SelectTask;

		// Token: 0x04004B14 RID: 19220
		public IXUILabel m_SelectTaskLabel;

		// Token: 0x04004B15 RID: 19221
		public IXUIScrollView m_TaskListScrollView;

		// Token: 0x04004B16 RID: 19222
		public IXUIButton m_BtnGo;

		// Token: 0x04004B17 RID: 19223
		public IXUIButton m_BtnReward;
	}
}
