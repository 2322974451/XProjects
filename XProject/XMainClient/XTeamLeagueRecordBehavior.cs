using System;
using UILib;
using XMainClient.UI.UICommon;

namespace XMainClient
{

	internal class XTeamLeagueRecordBehavior : DlgBehaviourBase
	{

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

		public IXUIButton CloseBtn;

		public IXUIWrapContent WrapContent;

		public IXUILabel WinTimesLabel;

		public IXUILabel LostTimesLabel;

		public IXUILabel WinRateLabel;

		public IXUILabel ConsWinLabel;

		public IXUILabel ConsLoseLabel;
	}
}
