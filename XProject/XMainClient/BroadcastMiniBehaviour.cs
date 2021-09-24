using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class BroadcastMiniBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_btn = (base.transform.Find("Btn").GetComponent("XUIButton") as IXUIButton);
		}

		public IXUIButton m_btn;
	}
}
