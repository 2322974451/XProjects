using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{
	// Token: 0x02000BF7 RID: 3063
	internal class XTeamLeagueRecordBehavior : DlgBehaviourBase
	{
		// Token: 0x0600AE2E RID: 44590 RVA: 0x002093E8 File Offset: 0x002075E8
		private void Awake()
		{
			this.CloseBtn = (base.transform.Find("Bg/Close").GetComponent("XUIButton") as IXUIButton);
			this.WrapContent = (base.transform.Find("Bg/Bg/ScrollView/WrapContent").GetComponent("XUIWrapContent") as IXUIWrapContent);
			this.WinTimesLabel = (base.transform.Find("Bg/Message/Win/WinTimes").GetComponent("XUILabel") as IXUILabel);
			this.LostTimesLabel = (base.transform.Find("Bg/Message/Lose/LoseTimes").GetComponent("XUILabel") as IXUILabel);
			this.WinRateLabel = (base.transform.Find("Bg/Message/Rate/Label").GetComponent("XUILabel") as IXUILabel);
			this.ConsWinLabel = (base.transform.Find("Bg/Message/ConsWin/Label").GetComponent("XUILabel") as IXUILabel);
			this.ConsLoseLabel = (base.transform.Find("Bg/Message/ConsLose/Label").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x040041F5 RID: 16885
		public IXUIButton CloseBtn;

		// Token: 0x040041F6 RID: 16886
		public IXUIWrapContent WrapContent;

		// Token: 0x040041F7 RID: 16887
		public IXUILabel WinTimesLabel;

		// Token: 0x040041F8 RID: 16888
		public IXUILabel LostTimesLabel;

		// Token: 0x040041F9 RID: 16889
		public IXUILabel WinRateLabel;

		// Token: 0x040041FA RID: 16890
		public IXUILabel ConsWinLabel;

		// Token: 0x040041FB RID: 16891
		public IXUILabel ConsLoseLabel;
	}
}
