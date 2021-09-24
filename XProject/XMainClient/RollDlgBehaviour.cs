using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RollDlgBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_ItemTpl = base.transform.Find("Bg/ItemTpl/Item").gameObject;
			this.m_TimeBar = (base.transform.Find("Bg/Bar").GetComponent("XUISlider") as IXUISlider);
			this.m_Level = (base.transform.Find("Bg/ItemTpl/Level").GetComponent("XUILabel") as IXUILabel);
			this.m_Prof = (base.transform.Find("Bg/ItemTpl/Prof").GetComponent("XUILabel") as IXUILabel);
			this.m_YesButton = (base.transform.Find("Bg/Yes").GetComponent("XUIButton") as IXUIButton);
			this.m_CancelButton = (base.transform.Find("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
		}

		public GameObject m_ItemTpl;

		public IXUISlider m_TimeBar;

		public IXUILabel m_Level;

		public IXUILabel m_Prof;

		public IXUIButton m_YesButton;

		public IXUIButton m_CancelButton;
	}
}
