using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XNPCFavorBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_effect = base.transform.FindChild("Effect");
			this.m_Help = (base.transform.FindChild("Help").GetComponent("XUIButton") as IXUIButton);
			this.m_Close = (base.transform.FindChild("Close").GetComponent("XUIButton") as IXUIButton);
			this.m_handlersTra = base.transform.FindChild("Handler");
			this.m_SendTimesLabel = (base.transform.FindChild("Time").GetComponent("XUILabel") as IXUILabel);
			this.m_AddBtn = (base.transform.FindChild("Time/Add").GetComponent("XUIButton") as IXUIButton);
			this.m_SendTimesBtn = (base.transform.FindChild("Time/tq/p").GetComponent("XUISprite") as IXUISprite);
			this.m_PrivilegeSpr = (base.transform.FindChild("Time/tq").GetComponent("XUISprite") as IXUISprite);
			this.m_Tab0 = (base.transform.Find("Tabs/TabTpl0/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab1 = (base.transform.Find("Tabs/TabTpl1/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab2 = (base.transform.Find("Tabs/TabTpl2/Bg").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_Tab0_Redpoint = base.transform.Find("Tabs/TabTpl0/Bg/RedPoint").gameObject;
			this.m_Tab1_Redpoint = base.transform.Find("Tabs/TabTpl1/Bg/RedPoint").gameObject;
			this.m_Tab2_Redpoint = base.transform.Find("Tabs/TabTpl2/Bg/RedPoint").gameObject;
		}

		public Transform m_effect;

		public IXUIButton m_Help;

		public IXUIButton m_Close;

		public Transform m_handlersTra;

		public IXUILabel m_SendTimesLabel;

		public IXUIButton m_AddBtn;

		public IXUISprite m_PrivilegeSpr;

		public IXUISprite m_SendTimesBtn;

		public IXUICheckBox m_Tab0;

		public IXUICheckBox m_Tab1;

		public IXUICheckBox m_Tab2;

		public GameObject m_Tab0_Redpoint;

		public GameObject m_Tab1_Redpoint;

		public GameObject m_Tab2_Redpoint;
	}
}
