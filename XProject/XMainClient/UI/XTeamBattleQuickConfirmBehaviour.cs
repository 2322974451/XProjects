using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class XTeamBattleQuickConfirmBehaviour : DlgBehaviourBase
	{

		private void Awake()
		{
			this.m_Cancel = (base.transform.FindChild("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_Time = (base.transform.Find("Bg/CountDown").GetComponent("XUILabel") as IXUILabel);
		}

		public IXUIButton m_Cancel = null;

		public IXUILabel m_Time;
	}
}
