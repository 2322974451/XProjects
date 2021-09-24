using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class CapacityBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_closeSpr = (base.transform.Find("Bg/Black").GetComponent("XUISprite") as IXUISprite);
			this.m_checkBox = (base.transform.Find("ItemBlock").GetComponent("XUICheckBox") as IXUICheckBox);
			this.m_lable = (base.transform.Find("Bg/Tip").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUISprite m_closeSpr;

		public IXUICheckBox m_checkBox;

		public IXUILabel m_lable;
	}
}
