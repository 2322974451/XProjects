using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001863 RID: 6243
	internal class XTeamBattleQuickConfirmBehaviour : DlgBehaviourBase
	{
		// Token: 0x06010412 RID: 66578 RVA: 0x003EE5F4 File Offset: 0x003EC7F4
		private void Awake()
		{
			this.m_Cancel = (base.transform.FindChild("Bg/Cancel").GetComponent("XUIButton") as IXUIButton);
			this.m_Time = (base.transform.Find("Bg/CountDown").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040074D9 RID: 29913
		public IXUIButton m_Cancel = null;

		// Token: 0x040074DA RID: 29914
		public IXUILabel m_Time;
	}
}
