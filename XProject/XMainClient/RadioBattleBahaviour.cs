using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class RadioBattleBahaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_btnOpen = (base.transform.Find("Select/Play").GetComponent("XUIButton") as IXUIButton);
			this.m_btnClose = (base.transform.Find("Select/Pause").GetComponent("XUIButton") as IXUIButton);
			this.m_btnRadio = (base.transform.Find("Radio").GetComponent("XUIButton") as IXUIButton);
			this.m_objSelect = base.transform.Find("Select").gameObject;
		}

		public IXUIButton m_btnOpen;

		public IXUIButton m_btnClose;

		public IXUIButton m_btnRadio;

		public GameObject m_objSelect;
	}
}
